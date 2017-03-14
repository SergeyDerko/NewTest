using System;
using System.Runtime.InteropServices;
using System.Threading;
using TestWcfTypes.SergeyDerko;

namespace SergeyDerkoLibrary.MyLibrary
{
    public class AvtoAddInDb
    {

        public static void AddInDb()
        {
            while (true)
            {
                ScanPc.SaveScanPc(new ScanPcBd
                {
                    Cpu = Cpu.CpuInfo().Replace("<br />", ""),
                    Hdd = Hdd.HddInfo().Replace("<br />", ""),
                    Memory = Memory.MemoryInfo().Replace("<br />", ""),
                    Video = Video.VideoInfo().Replace("<br />", "")
                });
                Thread.Sleep(3600000); //3600000 час
            }
            
        }
    }
}
