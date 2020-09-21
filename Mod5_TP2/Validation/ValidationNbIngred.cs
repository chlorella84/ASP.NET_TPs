using BO;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mod5_TP2.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class ValidationNbIngred : ValidationAttribute
    {
        

        public override bool IsValid(object value)
        {

            bool result = false;
            List<int> idIngredients =  value as List<int>;
            if (idIngredients.Count() > 1 && idIngredients.Count() < 6)
            {
                result = true;
            }

            return result;
        }

        public override string FormatErrorMessage(string name)
        {
            return string.Format("Une pizza doit avoir entre 2 et 5 ingredients");
        }
    }
}