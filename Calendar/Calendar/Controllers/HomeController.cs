using Calendar.Models;
using Calendar.Services;
using Google.Apis.Services;
using Google.Apis.Calendar.v3;
using Google.Apis.Calendar.v3.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Calendar.Controllers
{
    public class HomeController : Controller
    {
        //static List<Toplanti> toplantiListesi = new List<Toplanti>();
        static MyCalendarService myCalendarService = new MyCalendarService();

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(string toplantiAdi, string aciklama, DateTime baslangicTarihi, DateTime bitisTarihi, string submitButton)
        {
            switch(submitButton)
            {
                case "Toplantı Oluştur":
                    if (toplantiAdi == "null" || aciklama == "null" || baslangicTarihi.ToString() == "1.01.0001 00:00:00" || bitisTarihi.ToString() == "1.01.0001 00:00:00")
                    {
                        ViewBag.Name = "Lütfen girilen değerleri kontrol ediniz.";
                        return View();
                    }

                    ToplantiOlustur(toplantiAdi, aciklama, baslangicTarihi, bitisTarihi);

                    break;
                case "Toplantı Listele":
                    return View(ToplantiListele());

                case "Tatil günü getir":
                    return View(TatilGunuGetir());
            }

            return View();
        }

        public bool ToplantiOlustur(string toplantiAdi, string aciklama, DateTime baslangicTarihi, DateTime bitisTarihi)
        {
            Toplanti toplanti = new Toplanti(toplantiAdi, aciklama, baslangicTarihi, bitisTarihi);

            Console.WriteLine("hafta Günü: {0}", baslangicTarihi.DayOfWeek);
            baslangicTarihi.AddDays(1);

            if (HomeController.myCalendarService.ToplantiOlustur(toplanti) == true)
            {

                //HomeController.toplantiListesi.Add(toplanti);
                ViewBag.Name = "Toplantı başarıyla oluşturuldu.";
            }
            else
            {

                ViewBag.Name = "Toplantı oluşturulurken bir hata meydana geldi.";
            }

            return true;
        }

        public IList<Event> ToplantiListele()
        {
            EFTControl(new DateTime(2021, 10 , 29));

            return myCalendarService.ToplantilariGetir().Items;
        }

        //bunu yaptım!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
        public IList<Event> TatilGunuGetir()
        {
            return myCalendarService.TatilGunleriniGetir().Items;
        }

        /*önce tarihleri getir CalendarService'ten
	parametreyle gelen tatiller içerisinde mi bak
		if içindeyse bir gün ilerlet.(BAŞA DÖN)
		else değilse devam et aşağı

	     parametre tarihinin gününü al(DayOfWeek)
		  if "Saturday" veya "Sunday" ise bir gün ilerlet(AddDays(1)).(BAŞA DÖN)
		  else devam et.

	hiç ilerleme yapmadıysan saate bak, 17:00'dan sonraysa ilerle.(BAŞA DÖN)
	""	""	""	""	"", değilse EFT BUGÜN !!!!!*/

        public bool EFTControl(DateTime tarih)
        {
            List<Event> tatilGunleri = TatilGunuGetir().ToList();

            List<Event> filtered = tatilGunleri.FindAll(e => e.Start.Date.Equals(tarih.ToString("yyyy-MM-dd")));

            if (filtered.Count != 0 || tarih.Date.DayOfWeek.ToString().Equals("Saturday") || tarih.Date.DayOfWeek.ToString().Equals("Sunday"))
            {
                //tarih = tarih.AddDays(1);
                return EFTControl(tarih.AddDays(1));
            }

            // kod buraya gelmişse gün sorunu kalmamış demektir.

            // saate bakmıyoruz!!!

            Console.WriteLine("EFT gerçekleşme tarihi: " + tarih.Date + " " + tarih.Date.DayOfWeek.ToString());
            //ViewBag.Name = "EFT gerçekleşme tarihi: " + tarih.Date + " " + tarih.Date.DayOfWeek.ToString();

            return true;
        }

    }
}
