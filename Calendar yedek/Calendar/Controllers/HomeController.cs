using Calendar.Models;
using Calendar.Services;
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
            }

            return View();
        }

        public bool ToplantiOlustur(string toplantiAdi, string aciklama, DateTime baslangicTarihi, DateTime bitisTarihi)
        {
            Toplanti toplanti = new Toplanti(toplantiAdi, aciklama, baslangicTarihi, bitisTarihi);

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
            return myCalendarService.ToplantilariGetir().Items;
        }
    }
}
