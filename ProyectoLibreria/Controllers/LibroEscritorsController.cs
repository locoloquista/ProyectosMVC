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
    public class LibroEscritorsController : Controller
    {
        private LibreriaEntities db = new LibreriaEntities();

        // GET: LibroEscritors
        public ActionResult Index()
        {
            var libroEscritor = db.LibroEscritor.Include(l => l.Escritor).Include(l => l.Libro);
            return View(libroEscritor.ToList());
        }

        // GET: LibroEscritors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibroEscritor libroEscritor = db.LibroEscritor.Find(id);
            if (libroEscritor == null)
            {
                return HttpNotFound();
            }
            return View(libroEscritor);
        }

        // GET: LibroEscritors/Create
        public ActionResult Create()
        {
            ViewBag.id_escritor = new SelectList(db.Escritor, "id_escritor", "nombre_escritor");
            ViewBag.id_libro = new SelectList(db.Libro, "id_libro", "nombre_libro");
            return View();
        }

        // POST: LibroEscritors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_libroescritor,id_libro,id_escritor")] LibroEscritor libroEscritor)
        {
            if (ModelState.IsValid)
            {
                db.LibroEscritor.Add(libroEscritor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_escritor = new SelectList(db.Escritor, "id_escritor", "nombre_escritor", libroEscritor.id_escritor);
            ViewBag.id_libro = new SelectList(db.Libro, "id_libro", "nombre_libro", libroEscritor.id_libro);
            return View(libroEscritor);
        }

        // GET: LibroEscritors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibroEscritor libroEscritor = db.LibroEscritor.Find(id);
            if (libroEscritor == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_escritor = new SelectList(db.Escritor, "id_escritor", "nombre_escritor", libroEscritor.id_escritor);
            ViewBag.id_libro = new SelectList(db.Libro, "id_libro", "nombre_libro", libroEscritor.id_libro);
            return View(libroEscritor);
        }

        // POST: LibroEscritors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_libroescritor,id_libro,id_escritor")] LibroEscritor libroEscritor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libroEscritor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_escritor = new SelectList(db.Escritor, "id_escritor", "nombre_escritor", libroEscritor.id_escritor);
            ViewBag.id_libro = new SelectList(db.Libro, "id_libro", "nombre_libro", libroEscritor.id_libro);
            return View(libroEscritor);
        }

        // GET: LibroEscritors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibroEscritor libroEscritor = db.LibroEscritor.Find(id);
            if (libroEscritor == null)
            {
                return HttpNotFound();
            }
            return View(libroEscritor);
        }

        // POST: LibroEscritors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LibroEscritor libroEscritor = db.LibroEscritor.Find(id);
            db.LibroEscritor.Remove(libroEscritor);
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
