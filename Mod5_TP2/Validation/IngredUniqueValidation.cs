using BO;
using Mod5_TP2.Database;
using Mod5_TP2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mod5_TP2.Validation
{
    public class IngredUniqueValidation :ValidationAttribute
    {

        public override bool IsValid(object value)
        {

            bool result = true;
            if (value is List<int>)
            {
                var maList = value as List<int>;

                if (FakeDB.Instance.Pizzas.Any(x => x.Ingredients.Select(y => y.Id).OrderBy(z => z).SequenceEqual(maList.OrderBy(z => z))))
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


        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            bool result = true;

            if (value is List<int>)
            {
                var maList = value as List<int>;
                var vm = validationContext.ObjectInstance as PizzaViewModel;
                if (vm.Pizza != null && vm.Pizza.Id != 0)
                {
                    if (FakeDB.Instance.Pizzas.Where(x => x.Id != vm.Pizza.Id).Any(x => x.Ingredients.Select(y => y.Id).OrderBy(z => z).SequenceEqual(maList.OrderBy(z => z))))
                    {
                        result = false;
                    }
                }
                else
                {
                    if (FakeDB.Instance.Pizzas.Any(x => x.Ingredients.Select(y => y.Id).OrderBy(z => z).SequenceEqual(maList.OrderBy(z => z))))
                    {
                        result = false;
                    }
                } 
            }

            if (result == false)
            {
                return new ValidationResult("Deux pizzas ne peuvent pas avoir les mêmes ingredients");
            }
            else
            {
                return null;
            }
        }
    }

}
