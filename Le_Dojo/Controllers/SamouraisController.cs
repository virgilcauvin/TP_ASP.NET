using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BO;
using Le_Dojo.Data;
using Le_Dojo.Models;

namespace Le_Dojo.Controllers
{
    public class SamouraisController : Controller
    {
        private Le_DojoContext db = new Le_DojoContext();

        // GET: CRUDcontroller
        public ActionResult Index()
        {
            return View(db.Samourais.ToList());
        }

        // GET: CRUDcontroller/Details/5
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

        // GET: CRUDcontroller/Create
        public ActionResult Create()
        {
            SamouraiViewModel vm = new SamouraiViewModel();
            //vm.Armes = db.Armes.ToList();
            List<int> armeIds = db.Samourais.Where(x => x.Arme != null).Select(x => x.Arme.Id).ToList();
            vm.Armes = db.Armes.Where(x => !armeIds.Contains(x.Id)).ToList();
            vm.ArtMartials = db.ArtMartials.ToList();
            return View(vm);
        }

        // POST: CRUDcontroller/Create
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SamouraiViewModel vm)
        {
            if (ModelState.IsValid)
            {
                vm.Samourai.Arme = db.Armes.Find(vm.IdArmes);
                foreach (var item in vm.IdsArtMartials)
                {
                    vm.Samourai.ArtMartials.Add(db.ArtMartials.FirstOrDefault(x => x.Id == item));
                }
                db.Samourais.Add(vm.Samourai);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(vm);
        }

        // GET: CRUDcontroller/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SamouraiViewModel vm = new SamouraiViewModel();
            Samourai samourai = db.Samourais.Find(id);
            vm.Samourai = samourai;
            if (samourai.Arme != null)
            {
                vm.IdArmes = samourai.Arme.Id;
            }
            List<int> armeIds = db.Samourais.Where(x => x.Arme != null).Select(x => x.Arme.Id).ToList();
            vm.Armes = db.Armes.Where(x => !armeIds.Contains(x.Id)).ToList();
            if (samourai.ArtMartials != null)
            {
                vm.IdsArtMartials = samourai.ArtMartials.Select(x => x.Id).ToList();
            }
            vm.ArtMartials = db.ArtMartials.ToList();
            if (samourai == null)
            {
                return HttpNotFound();
            }
            return View(vm);
        }

        // POST: CRUDcontroller/Edit/5
        // Afin de déjouer les attaques par sur-validation, activez les propriétés spécifiques que vous voulez lier. Pour 
        // plus de détails, voir  https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SamouraiViewModel vm)
        {
            if (ModelState.IsValid)
            {
                Samourai samourai = db.Samourais.Find(vm.Samourai.Id);
                db.Entry(samourai).State = EntityState.Modified;

                samourai.Nom = vm.Samourai.Nom;
                samourai.Force = vm.Samourai.Force;
                samourai.Arme = db.Armes.Find(vm.IdArmes);
                List<ArtMartial> liste = samourai.ArtMartials;
                samourai.ArtMartials = db.ArtMartials.Where(x => vm.IdsArtMartials.Contains(x.Id)).ToList();
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(vm);
        }

        // GET: CRUDcontroller/Delete/5
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

        // POST: CRUDcontroller/Delete/5
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
