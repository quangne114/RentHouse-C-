using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DACS_ThueTro.Models;

namespace DACS_ThueTro.Areas.Admin.Controllers
{
    public class ChuTroController : Controller
    {
        private ThueTro db = new ThueTro();
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            var chuTroes = db.ChuTroes.Include(c => c.AspNetUser);
            return View(chuTroes.ToList());
        }

        // GET: Admin/ChuTro/Details/5
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

        // GET: Admin/ChuTro/Create
        public ActionResult Create()
        {
            ViewBag.Id_AspNetUser = new SelectList(db.AspNetUsers, "Id", "Email");
            return View();
        }

        // POST: Admin/ChuTro/Create
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

        // GET: Admin/ChuTro/Edit/5
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

        // POST: Admin/ChuTro/Edit/5
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

        // GET: Admin/ChuTro/Delete/5
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

        // POST: Admin/ChuTro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var cat = db.ChuTroes.Include(p => p.PhongTroes).SingleOrDefault(p => p.Id_ChuTro == id);
            db.PhongTroes.RemoveRange(cat.PhongTroes);
            db.ChuTroes.Remove(cat);
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
