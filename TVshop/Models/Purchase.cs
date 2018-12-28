using System;

namespace TVshop.Models
{
    public class Purchase
    {
        public int PurchaseId { get; set; }
        public int TvId { get; set; }
        public int ClientId { get; set; }
        public int BascketId { get; set; }
    }
}