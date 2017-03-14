using System;
using System.Collections.Generic;
using TestWcfDB.SergeyDerko;
using TestWcfTypes.SergeyDerko;

namespace WebClientMVC.Models
{
    public class ScanBdModel
    {
        //public static List<ScanPcBd> ListBd = new List<ScanPcBd>();
        public List<ScanPcBd> CountBd()
        {
            List<ScanPcBd> listBd = new List<ScanPcBd>();
            using (var bd = new ScanPcContext())
            {
                foreach (var i in bd.ScanPcBds)
                {
                    listBd.Add(i);
                }
                return listBd;
            }

        }

        public string AddCpu { get; set; }
        public string AddHdd { get; set; }
        public string AddMemory { get; set; }
        public string AddVideo { get; set; }
        public string Answer;
        public string Respons;
        public int I { get; set; }
        public string OutOfTable;
        public string InTable;



        public void SaveScanPc()
        {
            Respons = "Данные переданы в Базу!";
            ScanPcBd newAdd = new ScanPcBd
            {
                Cpu = AddCpu,
                Hdd = AddHdd,
                Memory = AddMemory,
                Video = AddVideo
            };
            using (var bd = new ScanPcContext())
            {
                bd.ScanPcBds.Add(newAdd);
                bd.SaveChanges();
            }
        }

        public void DeleteOrder()
        {
            InTable = "Данные успешно удалены!";
            using (var bd = new ScanPcContext())
            {
                try
                {
                    ScanPcBd order = new ScanPcBd { ScanPcId = I };
                    bd.ScanPcBds.Attach(order);
                    bd.ScanPcBds.Remove(order);

                    bd.SaveChanges();
                }
                catch (Exception)
                {
                    OutOfTable = "Введите корректный номер Id!";
                }
                
            }
        }
        

    }
}