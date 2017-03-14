using System;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using TestWcfCommon;

namespace SergeyDerkoLibrary
{
    [DataContract]
    public class ReadLog : IReadLog
    {

       [DataMember]
        public string ReadLogInServise = Read();

           public static string Read()
            {
                string path = Logger.Dir + "\\" + Logger.Prefix + DateTime.Now.Date.ToString(@"\-yyyy\-MM\-dd") + ".txt";
                Stream stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                //File.OpenRead(seclogPath1);
                StreamReader streamReader = new StreamReader(stream, Encoding.Default);
                string str = streamReader.ReadToEnd();
                return str;
            }
            

        public ReadLog ReadServiseLog()
        {
            return  new ReadLog();
        }
    }
}
