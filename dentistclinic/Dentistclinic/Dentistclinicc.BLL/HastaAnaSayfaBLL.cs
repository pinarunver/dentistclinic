using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dentistclinic.Entity;
using Dentistclinicc.DAL;

namespace Dentistclinicc.BLL
{
    public class HastaAnaSayfaBLL
    {
        public bool HastaBilgiGuncelle(string tc, string mail, string telefon, string sifre)
        {
            if (string.IsNullOrEmpty(tc) || tc.Length != 11)
                return false;

            if (string.IsNullOrEmpty(mail) || string.IsNullOrEmpty(telefon) || string.IsNullOrEmpty(sifre))
                return false;

            HastaAnaSayfaDAL hastaDAL = new HastaAnaSayfaDAL();
            return hastaDAL.UpdateHastaBilgileri(tc, mail, telefon, sifre);
        }
        public bool SilHasta(string tc)
        {
            // Silme işlemi için DAL katmanını çağırıyoruz
            HastaAnaSayfaDAL hastaDAL = new HastaAnaSayfaDAL();
            return hastaDAL.SilHasta(tc);
        }
        public Hasta GetHastaBilgileri(string tc)
        {
            HastaAnaSayfaDAL hastaDAL = new HastaAnaSayfaDAL();
            return hastaDAL.GetHastaBilgileriByTC(tc);
        }
    }
}
