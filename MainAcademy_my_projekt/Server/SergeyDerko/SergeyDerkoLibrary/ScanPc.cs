using System;
using System.Collections.Generic;
using SergeyDerkoLibrary.MyLibrary;
using TestWcfCommon;
using TestWcfTypes.SergeyDerko;
using TestWcfDB.SergeyDerko;
using System.ComponentModel;
using Ionic.Zip;

namespace SergeyDerkoLibrary
{

    public class ScanPc : IScanPc
    {

        public Dictionary<string, string> Info()
        {
            Logger.Enter();
            Logger.Info("Формирование базы данных");
            SaveScanPc(new ScanPcBd
            {
                Cpu = Cpu.CpuInfo().Replace("<br />", ""),
                Hdd = Hdd.HddInfo().Replace("<br />", ""),
                Memory = Memory.MemoryInfo().Replace("<br />", ""),
                Video = Video.VideoInfo().Replace("<br />", "")
            });
            try
            {
                var list = new Dictionary<string, string>
            {
                {"Hdd", Hdd.HddInfo()},
                {"Cpu", Cpu.CpuInfo()},
                {"Memory", Memory.MemoryInfo()},
                {"Video", Video.VideoInfo()},
            };

                Logger.Info(Hdd.HddInfo().Replace("<br />", "\n"));
                Logger.Info(Cpu.CpuInfo().Replace("<br />", "\n"));
                Logger.Info(Memory.MemoryInfo().Replace("<br />", "\n"));
                Logger.Info(Video.VideoInfo().Replace("<br />", "\n"));
                Logger.Leave("Выход из метода ScanPc.Info()");
//                using (ZipFile zip = new ZipFile())
//                {
//                    zip.CompressionLevel = Ionic.Zlib.CompressionLevel.BestCompression; 
//                    zip.AddDirectory(Logger.Dir);
//                zip.Save(@"C:\Log.zip");  
//                }
                //                int a =0;
                //                int b = 1;
                //                int res = b/a;
                return list;
            }
            catch (DivideByZeroException)
            {
                DivideByZeroException fault = new DivideByZeroException("Деление на ноль!");
                Logger.Info(fault.Message);
                throw new DivideByZeroException( "Тэстовая ошибка");
            }
           
        }
        public static void SaveScanPc(ScanPcBd scan)
        {
            using (var bd = new ScanPcContext())
            {
                bd.ScanPcBds.Add(scan);
                bd.SaveChanges();
            }
        }
    }
}
