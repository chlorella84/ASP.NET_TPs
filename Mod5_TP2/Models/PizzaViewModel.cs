using BO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mod5_TP2.Models
{
    public class PizzaViewModel
    {

        public Pizza Pizza { get; set; }

        public List<SelectListItem> Ingredients { get; set; } = new List<SelectListItem>();
        public List<SelectListItem> Pates { get; set; } = new List<SelectListItem>();

        [Required]
        public int? IdPate { get; set; }
        [Required]
        public List<int> IdSelectedIngredients { get; set; } = new List<int>();
    }
}
