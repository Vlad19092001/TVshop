using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace TVshop.Models
{
    public class TvshopsDbInitializer:DropCreateDatabaseAlways<TvContext>
    {
        protected override void Seed(TvContext db)
        {
            db.TvShops.Add(new Tvshop { Price = 1250, Marka = "Lenovo", Dioganal = 65, Model = "Dlk24", Colors = "Grey" });
            db.TvShops.Add(new Tvshop { Price = 1500, Marka = "Samsung", Dioganal = 90, Model = "Ndg56", Colors = "Black" });
            db.TvShops.Add(new Tvshop { Price = 2000, Marka = "LG", Dioganal = 55, Model = "Lui67", Colors = "White" });
            db.TvShops.Add(new Tvshop { Price = 5000, Marka = "Panasonic", Dioganal = 70, Model = "Vtr37", Colors = "Gold" });
            db.TvShops.Add(new Tvshop { Price = 1100, Marka = "Sony", Dioganal = 110, Model = "Kfg50", Colors = "Blue" });
            db.TvShops.Add(new Tvshop { Price = 3550, Marka = "Philips", Dioganal = 60, Model = "Psz78", Colors = "Red" });
            base.Seed(db);
        }
    }
}
    
    
    
    
