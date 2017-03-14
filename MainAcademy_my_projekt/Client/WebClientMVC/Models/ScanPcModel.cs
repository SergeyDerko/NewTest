using System;
using System.Collections.Generic;
using System.ServiceModel;
using SergeyDerkoLibrary.Service_References.ScanPcReference;
using TestWcfCommon;

namespace WebClientMVC.Models
{
    public class ScanPcModel
    {
        public static string Hdd;
        public static string Cpu;
        public static string Memory;
        public static string Video;

        public static void StartScanPcModel()
        {
            Logger.Enter();
            try
            {
                ScanPcClient scanPc = new ScanPcClient();
                Dictionary<string, string> scan = scanPc.Info();
                Hdd = scan["Hdd"];
                Cpu = scan["Cpu"];
                Memory = scan["Memory"];
                Video = scan["Video"];
                Logger.Leave();
                scanPc.Close();
            }
            catch (CommunicationException commProblem)
            {
                Logger.Info("Ошибка подключения к службе ScanPc " + commProblem.Message + commProblem.StackTrace);
            }
            catch (TimeoutException timeProblem)
            {
                Logger.Info("TimeoutException при попытке обратиться к службе ScanPc" + timeProblem.Message);
            }
        }
    }
}