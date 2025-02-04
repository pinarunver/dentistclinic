using Dentistclinic.Entity;
using Dentistclinicc.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dentistclinicc.BLL
{
    public class HastaGirisBLL
    {
       
            // HastaGirisDAL sınıfına referans
        private HastaGirisDAL hastaGirisDAL = new HastaGirisDAL();

        public bool GirisYap(string hastaTC, string sifre)
        {
            // Boş kontrolü
            if (string.IsNullOrWhiteSpace(hastaTC) || string.IsNullOrWhiteSpace(sifre))
            {
                throw new ArgumentException("TC Kimlik ve Şifre boş olamaz.");
            }

            // DAL katmanından giriş kontrolü
            return hastaGirisDAL.GirisKontrol(hastaTC, sifre);
        }

        // Yapıcı metod, hastaGirisDAL nesnesi oluşturuyor
        public HastaGirisBLL()
            {
                hastaGirisDAL = new HastaGirisDAL();
            }

        // Kullanıcı adı ve şifre ile giriş kontrolü yapar
        

            public string Arama(HastaGiris hastaGiris)
            {
            if (string.IsNullOrWhiteSpace(hastaGiris.HastaTC) || string.IsNullOrWhiteSpace(hastaGiris.HastaSifre))
            {
                throw new Exception("TC Kimlik No ve şifre alanlarını doldurunuz.");
            }

            // DAL katmanına sorgu gönderilir
            string HastaTC = hastaGirisDAL.Arama(hastaGiris);

            // Eğer veri yoksa boş döner
            if (string.IsNullOrEmpty(HastaTC))
            {
                return null; // Kullanıcı bulunamadı
            }

            return HastaTC;
        }
        

        /*public string Arama(HastaGiris hastaGiris)
        {
            // Kullanıcı adı ve şifre kontrolü yapılır
            if (string.IsNullOrWhiteSpace(hastaGiris.Kullaniciadi) || string.IsNullOrWhiteSpace(hastaGiris.Sifre))
            {
                throw new Exception("Kullanıcı adı ve şifreyi giriniz.");
            }

            // Kullanıcı adı ve şifreyi DAL'den kontrol ederiz
            string kullaniciAdi = hastaGirisDAL.Arama(hastaGiris);

            if (string.IsNullOrEmpty(kullaniciAdi))
            {
                throw new Exception("Kullanıcı adı veya şifre yanlış.");
            }

            return kullaniciAdi;
        }*/

        // Yeni hasta kaydı ekler
        public string AddNewItem(HastaGiris hastaGiris)
            {
                // Boş alan kontrolü yapılır
                if (string.IsNullOrWhiteSpace(hastaGiris.Kullaniciadi) || string.IsNullOrWhiteSpace(hastaGiris.HastaSifre) ||
                    string.IsNullOrWhiteSpace(hastaGiris.HastaAdi) || string.IsNullOrWhiteSpace(hastaGiris.HastaSoyadi))
                {
                    throw new Exception("Lütfen tüm alanları doldurunuz.");
                }

                return hastaGirisDAL.AddNewItem(hastaGiris); // DAL'den yeni hasta kaydını ekleriz
            }

            // Hasta bilgilerini günceller
            public int UpdateItem(HastaGiris hastaGiris)
            {
                // Boş alan kontrolü yapılır
                if (string.IsNullOrWhiteSpace(hastaGiris.Kullaniciadi) || string.IsNullOrWhiteSpace(hastaGiris.HastaSifre))
                {
                    throw new Exception("Kullanıcı adı ve şifreyi giriniz.");
                }

                return hastaGirisDAL.UpdateItem(hastaGiris); // DAL'den hasta bilgilerini güncelleriz
            }

            // Hasta kaydını siler
            public int DeleteItem(HastaGiris hastaGiris)
            {
                // Boş alan kontrolü yapılır
                if (string.IsNullOrWhiteSpace(hastaGiris.Kullaniciadi))
                {
                    throw new Exception("Kullanıcı adı alanını doldurunuz.");
                }

                return hastaGirisDAL.DeleteItem(hastaGiris); // DAL'den hasta kaydını sileriz
            }
        }
    }


