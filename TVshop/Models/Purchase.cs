using System;

namespace TVshop.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public int TvId { get; set; }
        public string Person { get; set; }
        public string Adress { get; set; }
        public DateTime Date { get; set; }
    }
}