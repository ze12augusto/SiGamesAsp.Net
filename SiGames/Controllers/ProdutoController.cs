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
    public class ProdutoController : Controller
    {
        private sigamesEntities db = new sigamesEntities();

        //
        // GET: /Produto/

        public ActionResult Index()
        {
            return View(db.produto.ToList());
        }

        //
        // GET: /Produto/Details/5

        public ActionResult Details(int id)
        {
            produto produto = db.produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        //
        // GET: /Produto/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Produto/Create

        [HttpPost]
        public ActionResult Create(produto produto)
        {
            if (ModelState.IsValid)
            {
                db.produto.Add(produto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(produto);
        }

        //
        // GET: /Produto/Edit/5

        public ActionResult Edit(int id )
        {
            produto produto = db.produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        //
        // POST: /Produto/Edit/5

        [HttpPost]
        public ActionResult Edit(produto produto)
        {
            if (ModelState.IsValid)
            {
                db.Entry(produto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(produto);
        }

        //
        // GET: /Produto/Delete/5

        public ActionResult Delete(int id )
        {
            produto produto = db.produto.Find(id);
            if (produto == null)
            {
                return HttpNotFound();
            }
            return View(produto);
        }

        //
        // POST: /Produto/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            produto produto = db.produto.Find(id);
            db.produto.Remove(produto);
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