using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TVshop.Models;

namespace TVshop.Controllers
{
    public class HomeController : Controller
    {
        TvContext db = new TvContext();
        public ActionResult Index()
        {
            IEnumerable < Tvshop > tvs = db.TvShops;
            ViewBag.Tvs = tvs;
            return View();
        }
        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.TvId = id;
            return View();
        }
        [HttpPost]
        public string Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            db.Purchases.Add(purchase);
            db.SaveChanges();
            return "Спасибо,"  + purchase.Person + ",за покупку";

        }
        public ActionResult Show()
        {
            ViewBag.Message = "Сообщение";
            return PartialView();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Сообщение About";
            return PartialView();
        }
        public ActionResult PartialBlock()
        {
            return PartialView();
        }


    }
}