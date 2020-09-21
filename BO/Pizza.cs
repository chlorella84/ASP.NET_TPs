
using BO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO
{
    public class Pizza
    {
        public int Id { get; set; }
        [Required]
        [StringLength(20, ErrorMessage = "Le nom doit contenir entre {2} et {1} charactéres", MinimumLength = 5)]
        public string Nom { get; set; }
       
        public Pate Pate { get; set; }
        
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();


    }
}
