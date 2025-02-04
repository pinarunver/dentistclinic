using Dentistclinicc.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistclinicc.BLL
{
    public class DoktorRandevuDurumBLL
    {
    private DoktorRandevuDurumDAL _dal = new DoktorRandevuDurumDAL();

    public DataTable GetDoktorlar()
    {
        return _dal.GetDoktorlar();
    }

    public DataTable GetRandevuSayisiByDoktor(string doktorAdi)
    {
        return _dal.GetRandevuSayisiByDoktor(doktorAdi);
    }
}
}