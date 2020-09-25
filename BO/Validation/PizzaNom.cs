using BO.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BO.Validation
{
    public class PizzaNom : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Boolean result = true;
            if (value != null)
            {
            List<Pizza> pizza = FakeDb.Instance.pizzas;
                if (pizza.Any(x => x.Nom == value.ToString()))
                {
                    result = false;
                }
                
            }

            return result;
        }
    }
}
