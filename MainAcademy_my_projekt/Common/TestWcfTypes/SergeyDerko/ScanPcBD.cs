using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace TestWcfTypes.SergeyDerko
{
    [DataContract]
    public class ScanPcBd
    {
        [Key]
        public int ScanPcId { get; set; }

        [DataMember]
        public string Hdd { get; set; }

        [DataMember]
        public string Cpu { get; set; }

        [DataMember]
        public string Memory { get; set; }

        [DataMember]
        public string Video { get; set; }
    }
}
