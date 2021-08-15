using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ProyectoLibreria;

namespace ProyectoLibreria.Controllers
{
    public class EscritorsController : Controller
    {
        private LibreriaEntities db = new LibreriaEntities();

        // GET: Escritors
        public ActionResult Index()
        {
            return View(db.Escritor.ToList());
        }

        // GET: Escritors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escritor escritor = db.Escritor.Find(id);
            if (escritor == null)
            {
                return HttpNotFound();
            }
            return View(escritor);
        }

        // GET: Escritors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Escritors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_escritor,nombre_escritor,nacionalidad_escritor,activo")] Escritor escritor)
        {
            if (ModelState.IsValid)
            {
                db.Escritor.Add(escritor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(escritor);
        }

        // GET: Escritors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escritor escritor = db.Escritor.Find(id);
            if (escritor == null)
            {
                return HttpNotFound();
            }
            return View(escritor);
        }

        // POST: Escritors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_escritor,nombre_escritor,nacionalidad_escritor,activo")] Escritor escritor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(escritor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(escritor);
        }

        // GET: Escritors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Escritor escritor = db.Escritor.Find(id);
            if (escritor == null)
            {
                return HttpNotFound();
            }
            return View(escritor);
        }

        // POST: Escritors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Escritor escritor = db.Escritor.Find(id);
            db.Escritor.Remove(escritor);
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
