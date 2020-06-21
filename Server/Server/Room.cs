using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    public class Room
    {
        public int id { get; set; }
        public List<MyUser> Users { get; set; }
        public Questions Question { get; set; }
    }
}
