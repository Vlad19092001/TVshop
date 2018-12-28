using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TVshop.Models;
using TVshop.Models.DTO;

namespace TVshop.Controllers
{
    public class HomeController : Controller
    {
        TvContext db = new TvContext();
        public PagingInfo PagingInfo { get; set; }
        public int pageSize = 2;
        public ActionResult Index(int page = 1)
        {
            IEnumerable<Tvshop> tvs = db.TvShops;
            var Tvs = tvs
            .OrderBy(tv => tv.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize);
            PagingInfo = new PagingInfo
            {
                CurrentPage = page,
                ItemsPerPage = pageSize,
                TotalItems = tvs.Count()
            };
            ViewBag.Tv = Tvs;
            ViewBag.PagingInfo = PagingInfo;
            return View();
        }
        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.TvId = id;
            return View();
        }
        [HttpPost]
        public string Buy(PurchaseDTO purchaseDTO)
        {
            purchaseDTO.Date = DateTime.Now;
            var client = MapToClient(purchaseDTO);
            var purchase = MapToPurchase(purchaseDTO);
            var ClientId = SaveClient(client);
            purchase.ClientId = ClientId;
            SavePurchase(purchase);
            return "Спасибо,"  + purchaseDTO.NameClient + ",за покупку";

        }
        private Client MapToClient(PurchaseDTO purchaseDTO)
        {
            return new Client
            {
                NameClient = purchaseDTO.NameClient,
                Adress = purchaseDTO.Adress

            };
        }
        private Purchase MapToPurchase(PurchaseDTO purchaseDTO)
        {
            return new Purchase
            {
                TvId = purchaseDTO.IdTV
            };
        }
        private int SaveClient(Client client)
        {
            var a = db.Client.Add(client);
            db.SaveChanges();
            return a.Id;
        }
        private int SavePurchase(Purchase purchase)
        {
            var a = db.Purchases.Add(purchase);
            db.SaveChanges();
            return a.PurchaseId;
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
        public ActionResult Contact()
        {
            ViewBag.Message = "Сообщение Контакты";
            return PartialView();
        }


    }
}