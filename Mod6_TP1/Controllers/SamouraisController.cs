using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BO;
using Mod6_TP1.Data;
using Mod6_TP1.Models;

namespace Mod6_TP1.Controllers
{
    public class SamouraisController : Controller
    {
        private Mod6_TP1Context db = new Mod6_TP1Context();

        // GET: Samourais
        public ActionResult Index()
        {
            return View(db.Samourais.ToList());
        }

        // GET: Samourais/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // GET: Samourais/Create
        public ActionResult Create()
        {
            var vm = new SamouraiVM();
            vm.Armes = getArmesDisponibles(vm);
            vm.ArtsMartials = db.ArtMartials.ToList();
            return View(vm);
        }

        // POST: Samourais/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SamouraiVM vm)
        {
            if (ModelState.IsValid)
            {
                if(vm.IdSelectedArme.HasValue)
                {
                    vm.Samourai.Arme = getArmesDisponibles(vm).FirstOrDefault(x => x.Id == vm.IdSelectedArme.Value);
                }
                if (vm.IdSelectedArtsMartials.Count != 0)
                {
                    vm.Samourai.ArtMartials = db.ArtMartials.Where(x => vm.IdSelectedArtsMartials.Contains(x.Id)).ToList();

                }

                db.Samourais.Add(vm.Samourai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            vm.Armes = getArmesDisponibles(vm);
            vm.ArtsMartials = db.ArtMartials.ToList();
            return View(vm);
        }

        // GET: Samourais/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            var vm = new SamouraiVM();
            var armeActuel = samourai.Arme;
            vm.Armes = getArmesDisponibles(vm);
            vm.Armes.Add(armeActuel);
            vm.ArtsMartials = db.ArtMartials.ToList();
            vm.Samourai = samourai;

            if (samourai.Arme != null)
            {
                vm.IdSelectedArme = samourai.Arme.Id;
            }
            else
            {
                vm.IdSelectedArme = null;
            }

            if (samourai.ArtMartials.Count !=0)
            {
                vm.IdSelectedArtsMartials = samourai.ArtMartials.Select(x => x.Id).ToList(); ;
            }
            else
            {
                vm.ArtsMartials = null;
            }


            return View(vm);
        }

        // POST: Samourais/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( SamouraiVM vm)
        {
            if (ModelState.IsValid)
            {
                //eager loading
                var currentSamurai = db.Samourais.Include(x => x.Arme).Include(x => x.ArtMartials).FirstOrDefault(x => x.Id == vm.Samourai.Id);
              
                currentSamurai.Nom = vm.Samourai.Nom;
                currentSamurai.Force = vm.Samourai.Force;

                Arme armeActuel = currentSamurai.Arme;

                var armesDisponibles = getArmesDisponibles(vm);
                armesDisponibles.Add(armeActuel);

                if (vm.IdSelectedArme.HasValue)
                {
                    currentSamurai.Arme = armesDisponibles.FirstOrDefault(x => x.Id == vm.IdSelectedArme.Value);
                }
                else
                {
                    currentSamurai.Arme = null;
                }

                if (vm.ArtsMartials != null)
                {
                    currentSamurai.ArtMartials = db.ArtMartials.Where(x => vm.IdSelectedArtsMartials.Contains(x.Id)).ToList();
                   
                }
                else
                {
                    currentSamurai.ArtMartials = null;
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            vm.Armes = getArmesDisponibles(vm);
            vm.ArtsMartials = db.ArtMartials.ToList();

            return View(vm);
        }

        private List<Arme> getArmesDisponibles(SamouraiVM vm)
        {
            var allWeapons = db.Armes.ToList();
            vm.Armes = new List<Arme>();
            foreach (var item in allWeapons)
            {
                if (db.Samourais.Where(x => x.Arme.Id == item.Id).ToList().Count() == 0)
                {
                    vm.Armes.Add(item);
                }
            }
 
            return vm.Armes;
        }



        // GET: Samourais/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Samourai samourai = db.Samourais.Find(id);
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(samourai);
        }

        // POST: Samourais/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Samourai samourai = db.Samourais.Find(id);
            db.Samourais.Remove(samourai);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
