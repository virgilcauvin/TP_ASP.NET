using BO;
using BO.Validation;
using Les_Pizzas2.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Les_Pizzas2.Models
{
    public class PizzaCreateViewModel
    {
        public Pizza Pizza { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public List<Pate> Pate { get; set; }
        [Required]
        public int IdPate { get; set; }
        [PizzaLengh]
        [IngrediantDoublons]
        public List<int> IdsIngredients { get; set; }
    }
}