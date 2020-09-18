using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BO.Validation
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class MyValidation : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            bool result = false;
            if (true)
            {
                result = true;
            }

            return result;
        }
    }
}