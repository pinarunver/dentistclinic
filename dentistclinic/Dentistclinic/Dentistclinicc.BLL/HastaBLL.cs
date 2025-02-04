using Dentistclinic.Entity;
using Dentistclinicc.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistclinicc.BLL
{
    public class HastaBLL
    {
        private HastaDAL hastaDAL = new HastaDAL();

        public bool HastaEkle(Hasta hasta)
        {
            // İş kuralları kontrolü (örneğin, TC'nin 11 haneli olup olmadığını kontrol edebilirsiniz)
            if (hasta.HastaTC.Length != 11)
            {
                throw new Exception("TC Kimlik Numarası 11 haneli olmalıdır.");
            }

            if (hasta.DogumTarihi > DateTime.Now)
            {
                throw new Exception("Doğum tarihi bugünden ileri bir tarih olamaz.");
            }


            return hastaDAL.HastaEkle(hasta);
        }



    }
}