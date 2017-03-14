using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Mail;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

namespace TestWcfCommon
{
    public class Logger
    {
        private const string ExceptionForm = "{0}";
        private const string ExceptionWeb = "{0}";
        private const string MethodEnter = ">> {0}";
        private const string MethodLeave = "<< {0} : {1}";
        private const string MethodLeaveVoid = "<< {0}";
        private const string MethodTrace = "Trace {0}";
        private const string MethodInfo = "Info {0}";
        private static volatile Logger _instance;
        private static readonly object Lock = new object();

        private readonly List<string> _messages;
        private readonly Thread _worker;
        private DateTime _curLogFileDate;
        private Level _level;
        private string _logDir;
        private EventWaitHandle _logEvent;
        private string _logPrefix;
        private string _mailTo, _mailFrom, _mailMsgName;
        private string _smtpClientHost;
        private int _smtpClientPort;
        private bool _stop;
        private StreamWriter _writer;

        private Logger()
        {
            _logPrefix = string.Empty;
            _mailTo = _mailFrom = _mailMsgName = string.Empty;
            _smtpClientHost = string.Empty;
            _smtpClientPort = 0;
            _curLogFileDate = DateTime.MinValue;
            _writer = null;
            _messages = new List<string>();
            _logEvent = new EventWaitHandle(false, EventResetMode.AutoReset);
            _stop = false;
            _worker = new Thread(WorkerProc);
        }

        public static Logger Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (Lock)
                    {
                        if (_instance == null)
                            _instance = new Logger();
                    }
                }

                return _instance;
            }
        }

        public static Level Level
        {
            get { return Instance._level; }
            set { Instance._level = value; }
        }

        public static string Dir
        {
            get { return Instance._logDir; }
            set { Instance._logDir = value; }
        }

        public static string Prefix
        {
            get { return Instance._logPrefix; }
            set { Instance._logPrefix = value; }
        }

        public static void Write(Level level, string textmail, bool sendmail, string msg, params object[] args)
        {
            if ((int) Level < (int) level || Level == Level.Off)
                return;

            var text = new StringBuilder();
            text.Append("#" + DateTime.Now.ToString(@"dd\.MM\.yy HH\:mm\:ss\.fff "));
            text.Append(Thread.CurrentThread.ManagedThreadId.ToString("X8"));
            text.Append(" ");
            text.Append(level.ToString().PadRight(8, ' '));

            try
            {
                if (!string.IsNullOrEmpty(msg))
                    text.Append(string.Format(msg, args));
            }
            catch
            {
                text.Append(msg);
            }

            lock (Instance._messages)
            {
                Instance._messages.Add(text.ToString());
                Instance._logEvent.Set();
                if (sendmail)
                    SendMail(MailTo, MailMsgName, MailFrom,
                        string.IsNullOrEmpty(textmail) ? text.ToString() : textmail, Encoding.UTF8, Encoding.UTF8, true,
                        null);
            }
        }

        public static void Write(Level level, string msg, params object[] args)
        {
            Write(level, null, false, msg, args);
        }

        public static void Enter([CallerMemberName] string method = "")
        {
            Write(Level.Trace, null, false, MethodEnter, method);
        }

        public static void Leave([CallerMemberName] string method = "")
        {
            Write(Level.Trace, null, false, MethodLeaveVoid, method);
        }

        public static T Leave<T>(T ret, [CallerMemberName] string method = "")
        {
            Write(Level.Trace, null, false, MethodLeave, method, ret);
            return ret;
        }

        public static void Exception(Exception e, bool sendmail, string textmail, [CallerMemberName] string method = "")
        {
            Write(Level.Error, textmail, sendmail, ExceptionForm, method + " " + e);
        }

        public static void Exception(Exception e, bool sendmail, [CallerMemberName] string method = "")
        {
            Exception(e, sendmail, null, method);
        }

        public static void Exception(Exception e, [CallerMemberName] string method = "")
        {
            Exception(e, false, null, method);
        }

        public static void WebException(string method, WebException e, bool sendmail, string textmail)
        {
            Write(Level.Error, textmail, sendmail, ExceptionWeb, method + " " + e);
        }

        public static void WebException(string method, WebException e, bool sendmail)
        {
            WebException(method, e, sendmail, null);
        }

        public static void WebException(string method, WebException e)
        {
            WebException(method, e, false, null);
        }

        public static void Error(string s, bool sendmail, string textmail, [CallerMemberName] string method = "")
        {
            Write(Level.Error, textmail, sendmail, ExceptionForm,
                method + (string.IsNullOrEmpty(method) ? string.Empty : " ") + s);
        }

        public static void Error(string s, bool sendmail, [CallerMemberName] string method = "")
        {
            Error(s, sendmail, null, method);
        }

        public static void Error(string s, [CallerMemberName] string method = "")
        {
            Error(s, false, null, method);
        }

        public static void Trace(string s, bool sendmail, string textmail, [CallerMemberName] string method = "")
        {
            Write(Level.Trace, textmail, sendmail, MethodTrace, method + " " + s);
        }

        public static void Trace(string s, bool sendmail, [CallerMemberName] string method = "")
        {
            Write(Level.Trace, null, sendmail, MethodTrace, method + " " + s);
        }

        public static void Trace(string s, [CallerMemberName] string method = "")
        {
            Write(Level.Trace, null, false, MethodTrace, method + " " + s);
        }

        public static void Info(string s, bool sendmail, string textmail, [CallerMemberName] string method = "")
        {
            Write(Level.Info, textmail, sendmail, MethodInfo, method + " " + s);
        }

        public static void Info(string s, bool sendmail, [CallerMemberName] string method = "")
        {
            Write(Level.Info, null, sendmail, MethodInfo, method + " " + s);
        }

        public static void Info(string s, [CallerMemberName] string method = "")
        {
            Write(Level.Info, null, false, MethodInfo, method + " " + s);
        }

        public static void Start()
        {
            Instance._stop = false;
            Instance._worker.Start();
        }

        public static void Stop()
        {
            try
            {
                Instance._stop = true;
                Instance._logEvent.Set();
                Instance._worker.Join();
                Instance._logEvent = null;

                try
                {
                    if (Instance._writer != null)
                    {
                        Instance._writer.Dispose();
                        Instance._writer = null;
                    }
                }
                catch
                {
                    // ignored
                }
            }
            catch
            {
                // ignored
            }
        }

        private void WorkerProc()
        {
            var msg = string.Empty;

            do
            {
                _logEvent.WaitOne();

                CheckWriter();

                bool hasMsg;
                do
                {
                    lock (_messages)
                    {
                        hasMsg = _messages.Count > 0;

                        if (hasMsg)
                        {
                            msg = _messages[0];
                            _messages.RemoveAt(0);
                        }
                    }

                    if (_writer != null && hasMsg)
                    {
                        try
                        {
                            _writer.WriteLine(msg);
                        }
                        catch
                        {
                            // ignored
                        }
                    }
                } while (hasMsg);

                _writer?.Flush();
            } while (!_stop);
        }

        private void CheckWriter()
        {
            var createWriter = _writer == null
                               || _curLogFileDate.Date != DateTime.Now.Date
                               || Level == Level.Off;

            if (!createWriter)
                return;

            _writer?.Dispose();

            try
            {
                var fname = Prefix
                            + DateTime.Now.Date.ToString(@"\-yyyy\-MM\-dd")
                            + ".txt";

                _writer = new StreamWriter(Path.Combine(Dir,
                    fname),
                    true,
                    Encoding.GetEncoding(1251));
            }
            catch
            {
                _writer = null;
            }
        }

        /// <summary>
        ///     Отправить почту
        /// </summary>
        /// <param name="to">Получатели</param>
        /// <param name="subject">Тема</param>
        /// <param name="from">Отправитель</param>
        /// <param name="msg">Сообщение</param>
        /// <param name="subjectEncoding">Кодировка темы</param>
        /// <param name="bodyEncoding">Кодировка сообщения</param>
        /// <param name="isBodyHtml">Признак html-формата сообщения</param>
        /// <param name="attach">Список вложений</param>
        private static void SendMail(string to, string subject, string from, string msg,
            Encoding subjectEncoding, Encoding bodyEncoding, bool isBodyHtml,
            List<Attachment> attach)
        {
            if (string.IsNullOrEmpty(SmtpClientHost) || string.IsNullOrEmpty(to) ||
                string.IsNullOrEmpty(from) || string.IsNullOrEmpty(msg))
                return;

            try
            {
                var addr = to.Split(',');

                var message = new MailMessage();
                foreach (var t in addr)
                    message.To.Add(t);
                message.Subject = subject;
                message.From = new MailAddress(from);
                message.Body = msg;
                message.SubjectEncoding = subjectEncoding;
                message.BodyEncoding = bodyEncoding;
                message.IsBodyHtml = isBodyHtml;
                if (attach != null)
                    foreach (var item in attach)
                        message.Attachments.Add(item);
                var smtp = SmtpClientPort != 0
                    ? new SmtpClient(SmtpClientHost, SmtpClientPort)
                    : new SmtpClient(SmtpClientHost);
                smtp.Send(message);
            }
            catch
            {
                // ignored
            }
        }

        #region Реквизиты службы отправки почтовых сообщений

        public static string MailTo
        {
            get { return Instance._mailTo; }
            set { Instance._mailTo = value; }
        }

        public static string MailFrom
        {
            get { return Instance._mailFrom; }
            set { Instance._mailFrom = value; }
        }

        public static string MailMsgName
        {
            get { return Instance._mailMsgName; }
            set { Instance._mailMsgName = value; }
        }

        public static string SmtpClientHost
        {
            get { return Instance._smtpClientHost; }
            set { Instance._smtpClientHost = value; }
        }

        public static int SmtpClientPort
        {
            get { return Instance._smtpClientPort; }
            set { Instance._smtpClientPort = value; }
        }

        #endregion
    }
}