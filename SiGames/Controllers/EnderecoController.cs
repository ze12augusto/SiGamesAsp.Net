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
    public class EnderecoController : Controller
    {
        private sigamesEntities db = new sigamesEntities();

        //
        // GET: /Endereco/

        public ActionResult Index()
        {
            var endereco = db.endereco.Include(e => e.pessoa).Include(e => e.tipo_logradouro).Include(e => e.uf1);
            return View(endereco.ToList());
        }

        //
        // GET: /Endereco/Details/5

        public ActionResult Details(int id )
        {
            endereco endereco = db.endereco.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        //
        // GET: /Endereco/Create

        public ActionResult Create()
        {
            ViewBag.IdPessoa = new SelectList(db.pessoa, "IdPessoa", "Nome");
            ViewBag.IdTipoLogradouro = new SelectList(db.tipo_logradouro, "IdTipoLogradouro", "Descricao");
            ViewBag.UF = new SelectList(db.uf, "UF1", "Estado");
            return View();
        }

        //
        // POST: /Endereco/Create

        [HttpPost]
        public ActionResult Create(endereco endereco)
        {
            if (ModelState.IsValid)
            {
                db.endereco.Add(endereco);
                db.SaveChanges();
                return RedirectToAction("../Pessoa/QualquerCoisa");
            }

            ViewBag.IdPessoa = new SelectList(db.pessoa, "IdPessoa", "Nome", endereco.IdPessoa);
            ViewBag.IdTipoLogradouro = new SelectList(db.tipo_logradouro, "IdTipoLogradouro", "Descricao", endereco.IdTipoLogradouro);
            ViewBag.UF = new SelectList(db.uf, "UF1", "Estado", endereco.UF);
            return View(endereco);
        }

        //
        // GET: /Endereco/Edit/5

        public ActionResult Edit(int id )
        {
            endereco endereco = new endereco();
            if (endereco == null)
            {
                return HttpNotFound();
            }
            endereco = (endereco)db.endereco.Where(c => c.IdPessoa == id).First();
            ViewBag.IdPessoa = new SelectList(db.pessoa, "IdPessoa", "Nome", endereco.IdPessoa);
            ViewBag.IdTipoLogradouro = new SelectList(db.tipo_logradouro, "IdTipoLogradouro", "Descricao", endereco.IdTipoLogradouro);
            ViewBag.UF = new SelectList(db.uf, "UF1", "Estado", endereco.UF);
            return View(endereco);
        }

        //
        // POST: /Endereco/Edit/5

        [HttpPost]
        public ActionResult Edit(endereco endereco)
        {
            if (ModelState.IsValid)
            {
                db.Entry(endereco).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("../pessoa/index");
            }
            ViewBag.IdPessoa = new SelectList(db.pessoa, "IdPessoa", "Nome", endereco.IdPessoa);
            ViewBag.IdTipoLogradouro = new SelectList(db.tipo_logradouro, "IdTipoLogradouro", "Descricao", endereco.IdTipoLogradouro);
            ViewBag.UF = new SelectList(db.uf, "UF1", "Estado", endereco.UF);
            return View(endereco);
        }

        //
        // GET: /Endereco/Delete/5

        public ActionResult Delete(int id)
        {
            endereco endereco = db.endereco.Find(id);
            if (endereco == null)
            {
                return HttpNotFound();
            }
            return View(endereco);
        }

        //
        // POST: /Endereco/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            endereco endereco = db.endereco.Find(id);
            db.endereco.Remove(endereco);
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