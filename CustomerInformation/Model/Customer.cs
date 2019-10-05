using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomerInformation.Model
{
    public class Customer
    {
        public string code { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string contact { get; set; }
        public int DistrictId { get; set; }

    }
}
