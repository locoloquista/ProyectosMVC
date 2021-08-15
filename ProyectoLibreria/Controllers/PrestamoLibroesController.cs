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
    public class PrestamoLibroesController : Controller
    {
        private LibreriaEntities db = new LibreriaEntities();

        // GET: PrestamoLibroes
        public ActionResult Index()
        {
            var prestamoLibro = db.PrestamoLibro.Include(p => p.Libro).Include(p => p.Usuario);
            return View(prestamoLibro.ToList());
        }

        // GET: PrestamoLibroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrestamoLibro prestamoLibro = db.PrestamoLibro.Find(id);
            if (prestamoLibro == null)
            {
                return HttpNotFound();
            }
            return View(prestamoLibro);
        }

        // GET: PrestamoLibroes/Create
        public ActionResult Create()
        {
            ViewBag.id_libro = new SelectList(db.Libro, "id_libro", "nombre_libro");
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombres_usuario");
            return View();
        }

        // POST: PrestamoLibroes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_prestamolibro,dias_prestamolibro,fecha_prestamolibro,id_usuario,id_libro")] PrestamoLibro prestamoLibro)
        {
            if (ModelState.IsValid)
            {
                db.PrestamoLibro.Add(prestamoLibro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_libro = new SelectList(db.Libro, "id_libro", "nombre_libro", prestamoLibro.id_libro);
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombres_usuario", prestamoLibro.id_usuario);
            return View(prestamoLibro);
        }

        // GET: PrestamoLibroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrestamoLibro prestamoLibro = db.PrestamoLibro.Find(id);
            if (prestamoLibro == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_libro = new SelectList(db.Libro, "id_libro", "nombre_libro", prestamoLibro.id_libro);
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombres_usuario", prestamoLibro.id_usuario);
            return View(prestamoLibro);
        }

        // POST: PrestamoLibroes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_prestamolibro,dias_prestamolibro,fecha_prestamolibro,id_usuario,id_libro")] PrestamoLibro prestamoLibro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prestamoLibro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_libro = new SelectList(db.Libro, "id_libro", "nombre_libro", prestamoLibro.id_libro);
            ViewBag.id_usuario = new SelectList(db.Usuario, "id_usuario", "nombres_usuario", prestamoLibro.id_usuario);
            return View(prestamoLibro);
        }

        // GET: PrestamoLibroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PrestamoLibro prestamoLibro = db.PrestamoLibro.Find(id);
            if (prestamoLibro == null)
            {
                return HttpNotFound();
            }
            return View(prestamoLibro);
        }

        // POST: PrestamoLibroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PrestamoLibro prestamoLibro = db.PrestamoLibro.Find(id);
            db.PrestamoLibro.Remove(prestamoLibro);
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
