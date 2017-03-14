using System;
using System.IO;
using System.Text;
using TestWcfCommon;

namespace WebClientMVC.Models
{
    public class ReadLogInSite
    {
       // public string ReadLogInServise = Read();

        public string Read()
        {
            string path = Logger.Dir + "\\" + Logger.Prefix + DateTime.Now.Date.ToString(@"\-yyyy\-MM\-dd") + ".txt";
            Stream stream = File.Open(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
            StreamReader streamReader = new StreamReader(stream, Encoding.Default);
            string str = streamReader.ReadToEnd();
            return str;
        }
    }
}