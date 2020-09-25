using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Les_Pizzas2.Validation
{
    public class PizzaLengh : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Boolean result = false;
            if (value != null && (value as List<int>).Count >= 2 && (value as List<int>).Count <= 5)
            {
                result = true;
            }

            return result;
        }
    }
}