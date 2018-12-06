using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TVshop.Controllers
{
    public class TVController : Controller
    {
        // GET: TV
        public ActionResult Index()
        {
            return View();
        }

        public string Square (string a, string h)
        {
            double S =Convert.ToInt32( a) * Convert.ToInt32( h )/ 2.0;
            if( a==null & h == null)
            {
                return "Вы ничего не ввели";
            }
            else
            {
                return "Площадь" + S;
            }
            
        }
    }
}