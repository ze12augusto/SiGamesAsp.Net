using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SiGames.Models;

namespace SiGames.Controllers
{
    public class DocumentoController : Controller
    {
        private sigamesEntities db = new sigamesEntities();

        //
        // GET: /Documento/

        public ActionResult Index()
        {
            var documento = db.documento.Include(d => d.pessoa).Include(d => d.tipodocumento);
            return View(documento.ToList());
        }

        //
        // GET: /Documento/Details/5

        public ActionResult Details(int id )
        {
            documento documento = db.documento.Find(id);
            if (documento == null)
            {
                return HttpNotFound();
            }
            return View(documento);
        }

        //
        // GET: /Documento/Create

        public ActionResult Create()
        {
            ViewBag.IdPessoa = new SelectList(db.pessoa, "IdPessoa", "Nome");
            ViewBag.IdTipoDocumento = new SelectList(db.tipodocumento, "IdTipoDocumento", "Descricao");
            return View();
        }

        //
        // POST: /Documento/Create

        [HttpPost]
        public ActionResult Create(documento documento)
        {
            if (ModelState.IsValid)
            {
                db.documento.Add(documento);
                db.SaveChanges();
                return RedirectToAction("../Telefone/create");
            }

            ViewBag.IdPessoa = new SelectList(db.pessoa, "IdPessoa", "Nome", documento.IdPessoa);
            ViewBag.IdTipoDocumento = new SelectList(db.tipodocumento, "IdTipoDocumento", "Descricao", documento.IdTipoDocumento);
            return View(documento);
        }

        //
        // GET: /Documento/Edit/5

        public ActionResult Edit(int id )
        {
            documento documento = new documento();
            if (documento == null)
            {
                return HttpNotFound();
            }
            documento = (documento)db.documento.Where(c => c.IdPessoa == id).First();
            ViewBag.IdPessoa = new SelectList(db.pessoa, "IdPessoa", "Nome", documento.IdPessoa);
            ViewBag.IdTipoDocumento = new SelectList(db.tipodocumento, "IdTipoDocumento", "Descricao", documento.IdTipoDocumento);
            return View(documento);
        }

        //
        // POST: /Documento/Edit/5

        [HttpPost]
        public ActionResult Edit(documento documento)
        {
            if (ModelState.IsValid)
            {
                db.Entry(documento).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("../telefone/edit", new {id=documento.IdPessoa} );
            }
            ViewBag.IdPessoa = new SelectList(db.pessoa, "IdPessoa", "Nome", documento.IdPessoa);
            ViewBag.IdTipoDocumento = new SelectList(db.tipodocumento, "IdTipoDocumento", "Descricao", documento.IdTipoDocumento);
            return View(documento);
        }

        //
        // GET: /Documento/Delete/5

        public ActionResult Delete(int id )
        {
            documento documento = db.documento.Find(id);
            if (documento == null)
            {
                return HttpNotFound();
            }
            return View(documento);
        }

        //
        // POST: /Documento/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            documento documento = db.documento.Find(id);
            db.documento.Remove(documento);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}