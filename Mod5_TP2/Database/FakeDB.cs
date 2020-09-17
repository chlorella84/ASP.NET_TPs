using System;
using System.Collections.Generic;
using BO;
using System.Linq;
using System.Web;

namespace Mod5_TP2.Database
{
    public class FakeDB
    {
        private static readonly Lazy<FakeDB> lazy =
            new Lazy<FakeDB>(() => new FakeDB());

        /// <summary>
        /// FakeDb singleton access.
        /// </summary>
        public static FakeDB Instance { get { return lazy.Value; } }

        private FakeDB()
        {
            this.IngredientsDisponibles = getIngredients();
            this.PatesDisponibles = getPates();
            this.Pizzas = new List<Pizza>();
        }


        public List<Ingredient> IngredientsDisponibles { get; private set; }
        public List<Pate> PatesDisponibles { get; private set; }
        public List<Pizza> Pizzas { get; private set; }


        public List<Ingredient> getIngredients()
        {
            return new List<Ingredient>
            {
                new Ingredient{Id=1,Nom="Mozzarella"},
                new Ingredient{Id=2,Nom="Jambon"},
                new Ingredient{Id=3,Nom="Tomate"},
                new Ingredient{Id=4,Nom="Oignon"},
                new Ingredient{Id=5,Nom="Cheddar"},
                new Ingredient{Id=6,Nom="Saumon"},
                new Ingredient{Id=7,Nom="Champignon"},
                new Ingredient{Id=8,Nom="Poulet"}
            };
        }

        public List<Pate> getPates()
        {
            return new List<Pate>
            {
                new Pate{ Id=1,Nom="Pate fine, base crême"},
                new Pate{ Id=2,Nom="Pate fine, base tomate"},
                new Pate{ Id=3,Nom="Pate épaisse, base crême"},
                new Pate{ Id=4,Nom="Pate épaisse, base tomate"}
            };
        }

   
    }
}