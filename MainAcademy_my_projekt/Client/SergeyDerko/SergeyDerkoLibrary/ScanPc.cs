using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using SergeyDerkoLibrary.Service_References.ScanPcReference;

namespace SergeyDerkoLibrary
{
    public class ScanPc
    {
        static void Main()
        {
            ScanPcClient client = new ScanPcClient();
            try
            {
                Dictionary<string, string> scan = client.Info();
                foreach (var i in scan)
                {
                    Console.WriteLine(i);
                }
                Console.Read();
            }
            catch (FaultException e)
            {
                Console.WriteLine(e.Message);
                Console.Read();
            }
            
            client.Close();
        }
    }
}
