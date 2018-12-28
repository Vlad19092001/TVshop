

using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace TVshop.Models
{
    public class Tvshop
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [Display(Name = "Цена")]
        public double Price { get; set; }
        [Display(Name = "Марка")]
        public string Marka { get; set; }
        [Display(Name = "Диогональ")]
        public double Dioganal { get; set; }
        [Display(Name = "Модель")]
        public string Model { get; set; }
        [Display(Name = "Цвет")]
        public string Colors { get; set; } 

    }
}