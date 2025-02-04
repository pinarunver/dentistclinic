using Dentistclinicc.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistclinicc.BLL
{
    public class HastaRandevuTabloBLL
    {
        private HastaRandevuTabloDAL _randevuDAL;

        public HastaRandevuTabloBLL()
        {
            _randevuDAL = new HastaRandevuTabloDAL();
        }

        public DataTable GetRandevuData()
        {
            return _randevuDAL.GetRandevuData();
        }
    }
}
