using BO;
using BO.Database;
using Les_Pizzas2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BO.Controllers
{
    public class PizzaController : Controller
    {

        // GET: Pizza
        public ActionResult Index()
        {
            return View(FakeDb.Instance.pizzas);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            PizzaCreateViewModel vm = new PizzaCreateViewModel();
            vm.Pizza = FakeDb.Instance.pizzas.FirstOrDefault(x => x.Id == id);
            return View(vm);
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            PizzaCreateViewModel vm = new PizzaCreateViewModel();
            vm.Ingredients = FakeDb.Instance.IngredientsDisponibles;
            vm.Pate = FakeDb.Instance.PatesDisponibles;
            return View(vm);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzaCreateViewModel vm)
        {
            try
            {
                vm.Pizza.Pate = FakeDb.Instance.PatesDisponibles.FirstOrDefault(x => x.Id == vm.IdPate);
                foreach (var item in vm.IdsIngredients)
                {
                    vm.Pizza.Ingredients.Add(FakeDb.Instance.IngredientsDisponibles.FirstOrDefault(x => x.Id == item ));
                }
                FakeDb.Instance.pizzas.Add(vm.Pizza);
                return RedirectToAction("Index");
            }
            catch
            {
                return View(vm);
            }
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            PizzaCreateViewModel vm = new PizzaCreateViewModel();
            var pizza = FakeDb.Instance.pizzas.FirstOrDefault(x => x.Id == id); ;
            vm.Pizza = pizza;
            vm.IdPate = pizza.Pate.Id;
            vm.IdsIngredients = pizza.Ingredients.Select(x => x.Id).ToList();
            vm.Ingredients = FakeDb.Instance.IngredientsDisponibles;
            vm.Pate = FakeDb.Instance.PatesDisponibles;
                                   
            return View(vm);
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(PizzaCreateViewModel vm)
        {
            try
            {
                Pizza pizza = FakeDb.Instance.pizzas.FirstOrDefault(x => x.Id == vm.Pizza.Id);
                pizza.Nom = vm.Pizza.Nom;
                pizza.Pate = FakeDb.Instance.PatesDisponibles.FirstOrDefault(x => x.Id == vm.IdPate);
                pizza.Ingredients = FakeDb.Instance.IngredientsDisponibles.Where(x => vm.IdsIngredients.Contains(x.Id)).ToList();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Pizza/Delete/5
        public ActionResult Delete(int id)
        {
            PizzaCreateViewModel vm = new PizzaCreateViewModel();
            vm.Pizza = FakeDb.Instance.pizzas.FirstOrDefault(x => x.Id == id);
            return View(vm);
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Pizza pizza = FakeDb.Instance.pizzas.FirstOrDefault(x => x.Id == id);
                FakeDb.Instance.pizzas.Remove(pizza);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
