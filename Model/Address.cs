using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppHondaDuyDuc.Model
{
    public class Address
    {
        public string Village { get; set; }
        public string Wards { get; set; }
        public string Province { get; set; }

        public Address(string v, string w, string p)
        {
            Village = v;
            Wards = w;
            Province = p;
        }
    }
}
