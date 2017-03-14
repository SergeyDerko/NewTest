using System;
using System.Management;
using System.Text;


namespace SergeyDerkoLibrary.MyLibrary
{
    class Hdd
    {
        public static string HddInfo()
        {
            try
            {
                ManagementObjectSearcher scan1 = new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_DiskDrive");
                StringBuilder fullSize = new StringBuilder();
                foreach (var i in scan1.Get())
                {
                    fullSize.Append("Диск -  " + i["Caption"] + "     Pазмер -  " +
                                    Math.Round(Convert.ToDouble(i["Size"])/1024/1024/1024, 2) + " Gb <br />");
                }
                ManagementObjectSearcher scan2 = new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_Volume");
                foreach (var o in scan2.Get())
                {
                    fullSize.Append("Информация по разделам  :   " + o["Caption"] +
                                    "   Файловая система:    " + o["FileSystem"] +
                                    "   Свободное место :    " +
                                    Math.Round(Convert.ToDouble(o["FreeSpace"])/1024/1024/1024, 2) + "Gb <br />");
                }
                return fullSize.ToString();
            }
            catch (Exception)
            {
                return "Не возможно считать информацию о накопителях!";
            }
            

        }
    }
}
