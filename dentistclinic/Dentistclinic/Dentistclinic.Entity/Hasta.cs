using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistclinic.Entity
{
    public class Hasta
    {   
        public int HastaID { get; set; }
        public string HastaAdi { get; set; }
        public string HastaSoyadi { get; set; }
        public DateTime DogumTarihi { get; set; }
        public string HastaTelefon { get; set; }
        public string HastaCinsiyet { get; set; }
        public string HastaTC { get; set; }
        public string HastaSifre  { get; set; }
        public string Mail { get; set; }
    }

}