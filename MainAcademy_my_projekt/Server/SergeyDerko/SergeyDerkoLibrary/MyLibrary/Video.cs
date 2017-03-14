using System;
using System.Management;
using System.Runtime.CompilerServices;
using System.Text;

namespace SergeyDerkoLibrary.MyLibrary
{
    class Video
    {
        public static string VideoInfo()
        {
            try
            {
                ManagementObjectSearcher scan4 = new ManagementObjectSearcher("root\\CIMV2",
                    "SELECT * FROM Win32_VideoController");
                var video = new StringBuilder();
                foreach (var o in scan4.Get())
                {
                    video.Append("Модель   : " + o["Caption"] + " <br />" + "Количество памяти: " +
                                 Math.Round(Convert.ToDouble(o["AdapterRAM"])/1024/1024/1024, 2) + " Gb <br />");
                }
                return video.ToString();
            }
            catch (Exception)
            {
                return "Невозможно считать информацию о видео карте!";
            }
            
        }
    }
}
