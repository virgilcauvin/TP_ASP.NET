using BO;
using BO.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Les_Pizzas2.Validation
{
    public class IngrediantDoublons : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Boolean result = true;
            if (value != null)
            {
            List<Pizza> pizza = FakeDb.Instance.pizzas;
                if (pizza.Any(x => x.Ingredients.Select(y => y.Id).OrderBy(z => z).SequenceEqual((value as List<int>).OrderBy(j => j))))
                {
                    result = false;
                }
            }

            return result;
        }
    }
}