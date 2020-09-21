using BO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mod5_TP2.Validation
{
    public class NomUniqueValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {

            bool result = true;
            Pizza pizzaEnCreation = value as Pizza;

            List<Pizza> pizzas = Database.FakeDB.Instance.Pizzas;

            foreach (Pizza pizza in pizzas)
            {
                if (pizza.Nom.ToLower().Equals(pizzaEnCreation.Nom.ToLower()))

                {
                    result = false;
                }
            }



            return result;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format("Deux pizzas ne peuvent pas avoir les mêmes ingredients");
        }


    }
}