using BO;
using Mod5_TP2.Database;
using Mod5_TP2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mod5_TP2.Controllers
{
    public class PizzaController : Controller
    {
        // GET: Pizza
        public ActionResult Index()
        {
            return View(FakeDB.Instance.Pizzas);
        }

        // GET: Pizza/Details/5
        public ActionResult Details(int id)
        {
            PizzaViewModel vm = new PizzaViewModel();
            vm.Pizza = FakeDB.Instance.Pizzas.FirstOrDefault(x => x.Id == id);

            return View(vm);
        }

        // GET: Pizza/Create
        public ActionResult Create()
        {
            PizzaViewModel vm = new PizzaViewModel();
            vm.Pates = FakeDB.Instance.PatesDisponibles.Select(x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();
            vm.Ingredients = FakeDB.Instance.IngredientsDisponibles.Select(x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();

            return View(vm);
        }

        // POST: Pizza/Create
        [HttpPost]
        public ActionResult Create(PizzaViewModel vm)
        {
            try
            {
                if (ModelState.IsValid && ValidateVM(vm))
                {
                    Pizza pizza = vm.Pizza;
                    pizza.Pate = FakeDB.Instance.PatesDisponibles.FirstOrDefault(x => x.Id == vm.IdPate);
                    pizza.Ingredients = FakeDB.Instance.IngredientsDisponibles.Where(x => vm.IdSelectedIngredients.Contains(x.Id)).ToList();
                    pizza.Id = FakeDB.Instance.Pizzas.Count == 0 ? 1 : FakeDB.Instance.Pizzas.Max(x => x.Id) + 1;
                    FakeDB.Instance.Pizzas.Add(pizza);
                    return RedirectToAction("Index");
                }
                else
                {
                    vm.Pates = FakeDB.Instance.PatesDisponibles.Select(x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString()}).ToList();

                    vm.Ingredients = FakeDB.Instance.IngredientsDisponibles.Select(x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();

                    return View(vm);
                }

            }
            catch
            {
                vm.Pates = FakeDB.Instance.PatesDisponibles.Select(x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();

                vm.Ingredients = FakeDB.Instance.IngredientsDisponibles.Select( x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();
                return View();
            }
        }
        private bool ValidateVM(PizzaViewModel vm)
        {
            bool result = true;
            return result;
        }

        // GET: Pizza/Edit/5
        public ActionResult Edit(int id)
        {
            PizzaViewModel vm = new PizzaViewModel();
            vm.Pates = FakeDB.Instance.PatesDisponibles.Select(x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();
            vm.Ingredients = FakeDB.Instance.IngredientsDisponibles.Select(x => new SelectListItem { Text = x.Nom, Value = x.Id.ToString() }).ToList();
            vm.Pizza = FakeDB.Instance.Pizzas.FirstOrDefault(x => x.Id == id);

            if (vm.Pizza.Pate != null)
            {
                vm.IdPate = vm.Pizza.Pate.Id;
            }

            if (vm.Pizza.Ingredients.Any())
            {
                vm.IdSelectedIngredients = vm.Pizza.Ingredients.Select(x => x.Id).ToList();
            }



            return View(vm);
        }

        // POST: Pizza/Edit/5
        [HttpPost]
        public ActionResult Edit(PizzaViewModel vm)
        {
            try
            {
                Pizza pizza = FakeDB.Instance.Pizzas.FirstOrDefault(x => x.Id == vm.Pizza.Id);
                pizza.Nom = vm.Pizza.Nom;
                pizza.Pate = FakeDB.Instance.PatesDisponibles.FirstOrDefault(x => x.Id == vm.IdPate);
                pizza.Ingredients = FakeDB.Instance.IngredientsDisponibles.Where(x => vm.IdSelectedIngredients.Contains(x.Id)).ToList();

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
            PizzaViewModel vm = new PizzaViewModel();

            vm.Pizza = FakeDB.Instance.Pizzas.FirstOrDefault(x => x.Id == id);
            return View(vm);
        }

        // POST: Pizza/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                Pizza pizza = FakeDB.Instance.Pizzas.FirstOrDefault(x => x.Id == id);
                FakeDB.Instance.Pizzas.Remove(pizza);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
