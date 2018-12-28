using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TVshop.Models.DTO
{
    public class PurchaseDTO
    {
        public int IdTV { get; set; }
        public string Adress { get; set; }
        public DateTime Date { get; set; }
        public string NameClient { get; set; }
    }
}