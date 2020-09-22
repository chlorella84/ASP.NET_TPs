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
            vm.Armes = db.Armes.ToList();
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
                    vm.Samourai.Arme = db.Armes.FirstOrDefault(x => x.Id == vm.IdSelectedArme.Value);
                }

                db.Samourais.Add(vm.Samourai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            vm.Armes = db.Armes.ToList();
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
            vm.Armes = db.Armes.ToList();
            vm.Samourai = samourai;

            if (samourai.Arme != null)
            {
                vm.IdSelectedArme = samourai.Arme.Id;
            }
            else
            {
                vm.IdSelectedArme = null;
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
                var samouraiDB = db.Samourais.Find(vm.Samourai.Id);
                samouraiDB.Nom = vm.Samourai.Nom;
                samouraiDB.Force = vm.Samourai.Force;
                samouraiDB.Arme = null;
                if (vm.IdSelectedArme.HasValue)
                {
                    samouraiDB.Arme = db.Armes.FirstOrDefault(x => x.Id == vm.IdSelectedArme.Value);
                }
                else
                {
                    samouraiDB.Arme = null;
                }

                db.SaveChanges();
                return RedirectToAction("Index");
            }
            vm.Armes = db.Armes.ToList();

            return View(vm);
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
