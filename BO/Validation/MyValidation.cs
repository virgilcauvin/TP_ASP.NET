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
            Boolean result = false;
            if (value != null && (value as List<int>).Count >= 1 && (value as List<int>).Count <= 5)
            {
                result = true;
            }

            return result;
        }
    }
}