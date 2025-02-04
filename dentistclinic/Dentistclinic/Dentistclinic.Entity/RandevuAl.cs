using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistclinic.Entity
{
    public class RandevuAl
    {


        
            public int RandevuID { get; set; } // Otomatik Sayı (Primary Key)
            public string HastaAdi {  get; set; }
            public DateTime RandevuTarihi { get; set; } // Tarih/Saat
            public string Saat { get; set; }         // Tarih/Saat
            public string RandevuTürü { get; set; }    // Kısa Metin
            public string DoktorAdi { get; set; }
            public string Mail { get; set; }





    }
}