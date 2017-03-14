using System;
using System.Management;
using System.Text;

namespace SergeyDerkoLibrary.MyLibrary
{
    class Cpu
    {
        public static string CpuInfo()
        {
            try
            {
                ManagementObjectSearcher scan3 = new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_Processor");
                var processor = new StringBuilder();
                foreach (var o in scan3.Get())
                {
                    processor.Append("Параметры     : " + o["Name"] + " <br />" + "количество ядер :  " +
                                     o["NumberOfCores"]);

                }
                return processor.ToString();
            }
            catch (Exception)
            {
                return "Не возмжно считать параметры процессора!";
            }
            
        }
    }
}
