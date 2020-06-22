using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    [DataContract]
    public class UserData
    {
        [DataMember]
        public string Acount { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Avart { get; set; }
        [DataMember]
        public int Grade { get; set; }
        [DataMember]
        public string Sign { get; set; }
        [DataMember]
        public Nullable<int> Score { get; set; }
        [DataMember]
        public Nullable<int> Room { get; set; }
    }
}
