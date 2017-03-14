using System;
using System.Management;
using System.Text;

namespace SergeyDerkoLibrary.MyLibrary
{
    class Memory
    {
        public static string MemoryInfo()
        {
            try
            {
                ManagementObjectSearcher scan5 = new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_PhysicalMemory");
                var memory = new StringBuilder();
                foreach (var o in scan5.Get())
                {
                    memory.Append("Размер: " + Math.Round(Convert.ToDouble(o["Capacity"])/1024/1024/1024, 2) + " Gb  " +
                                  "Скорость: " + o["Speed"] + " <br />");
                }
                return memory.ToString();
            }
            catch (Exception)
            {
                return "Невозможно считать информацию о оперативной памяти!";
            }
            
        }
    }
}
