using System;
using System.IO;
using System.ServiceProcess;
using System.Threading;
using SergeyDerkoLibrary.MyLibrary;
using TestWcfCommon;

namespace TestWcfService
{
    class Program
    {
        /// <summary>
        ///     Главная точка входа в программу
        /// </summary>
        static void Main(string[] args)
        {
            Thread addInScanPcDb = new Thread(AvtoAddInDb.AddInDb);// создание потока для заполнения БД данными из ScanPc
            addInScanPcDb.Start();
            AppDomain currentDomain = AppDomain.CurrentDomain;
            currentDomain.UnhandledException += UnhandledExceptionHandler;
            Init();
            var svc = new MainService();
                if (Array.IndexOf(args, "console") != -1 || Array.IndexOf(args, "c") != -1)
            {
                svc.StartSvc();
                Console.WriteLine("Press a key for stop services...");
                Console.ReadKey(true);
                svc.StopSvc();
                Console.WriteLine("Press a key for exit...");
                Console.ReadKey(true);
              //  return;
            }
            ServiceBase.Run(svc);
        }

        private static void Init()
        {
            #region Инициализация логгера

            Logger.Level = Config.Get.Log.Level;

            // Определение пути доступа к журналу событий

            try
            {
                Logger.Dir = Config.Get.Log.Dir;
                if (!Directory.Exists(Logger.Dir))
                {
                    Directory.CreateDirectory(Logger.Dir);
                }
            }
            catch
            {
            }

            Logger.Prefix = Config.Get.Log.Prefix;
            Logger.Start();

            Logger.Write(Level.Info, "Старт сервера");

            #endregion

        }

        private static void UnhandledExceptionHandler(object sender, UnhandledExceptionEventArgs args)
        {
            const string method = "UnhandledExceptionHandler";
            var ex = (Exception)args.ExceptionObject;
            if (ex == null)
            {
                Logger.Error(method, "Undefined error!");
            }
            else
            {
                Logger.Exception(ex);
            }
        }

        //sc create TestService binPath="w:\repos\GroupProject\CW\501\501_srv\bin\Debug\501_srv.exe" DisplayName= "TestServiceDisplayName"
    }
}
    