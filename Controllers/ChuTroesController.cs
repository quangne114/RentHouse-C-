using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DACS_ThueTro.Models;

namespace DACS_ThueTro.Controllers
{
    public class ChuTroesController : Controller
    {
        private ThueTro db = new ThueTro();

        // GET: ChuTroes
        public ActionResult Index()
        {
            var chuTroes = db.ChuTroes.Include(c => c.AspNetUser);
            return View(chuTroes.ToList());
        }

        // GET: ChuTroes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuTro chuTro = db.ChuTroes.Find(id);
            if (chuTro == null)
            {
                return HttpNotFound();
            }
            return View(chuTro);
        }

        // GET: ChuTroes/Create
        public ActionResult Create()
        {
            ViewBag.Id_AspNetUser = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: ChuTroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_ChuTro,TenChuTro,SDT,Email,UrlHinhAnh,Id_AspNetUser")] ChuTro chuTro)
        {
            if (ModelState.IsValid)
            {
                db.ChuTroes.Add(chuTro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_AspNetUser = new SelectList(db.AspNetUsers, "Id", "Email", chuTro.Id_AspNetUser);
            return View(chuTro);
        }

        // GET: ChuTroes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuTro chuTro = db.ChuTroes.Find(id);
            if (chuTro == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_AspNetUser = new SelectList(db.AspNetUsers, "Id", "Email", chuTro.Id_AspNetUser);
            return View(chuTro);
        }

        // POST: ChuTroes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_ChuTro,TenChuTro,SDT,Email,UrlHinhAnh,Id_AspNetUser")] ChuTro chuTro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(chuTro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_AspNetUser = new SelectList(db.AspNetUsers, "Id", "Email", chuTro.Id_AspNetUser);
            return View(chuTro);
        }

        // GET: ChuTroes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ChuTro chuTro = db.ChuTroes.Find(id);
            if (chuTro == null)
            {
                return HttpNotFound();
            }
            return View(chuTro);
        }

        // POST: ChuTroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ChuTro chuTro = db.ChuTroes.Find(id);
            db.ChuTroes.Remove(chuTro);
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
