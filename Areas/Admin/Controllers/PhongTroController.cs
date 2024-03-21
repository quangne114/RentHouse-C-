using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DACS_ThueTro.Models;
using Microsoft.AspNet.Identity;

namespace DACS_ThueTro.Areas.Admin.Controllers
{
    public class PhongTroController : Controller
    {
        private ThueTro db = new ThueTro();

        // GET: Admin/PhongTro
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            string currentUserId   = User.Identity.GetUserId();

             if (currentUserId == null)
             {
                 return RedirectToAction("Login", "Account", new
                 {
                     area = ""
                 });
             }
             else
             {
                 var phongTroes = db.PhongTroes.Include(p => p.ChuTro).Include(p => p.LoaiPhong);
                 return View(phongTroes.ToList());
             }

        }
        // GET: Admin/PhongTro/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhongTro phongTro = db.PhongTroes.Find(id);
            if (phongTro == null)
            {
                return HttpNotFound();
            }
            return View(phongTro);
        }

        // GET: Admin/PhongTro/Create
        public ActionResult Create()
        {

            ViewBag.Id_ChuTro = new SelectList(db.ChuTroes, "Id_ChuTro", "TenChuTro");
            ViewBag.Id_LoaiPhong = new SelectList(db.LoaiPhongs, "Id_LoaiPhong", "TenLoaiPhong");
            return View();
        }

        // POST: Admin/PhongTro/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_PhongTro,Id_ChuTro,Id_LoaiPhong,Title,GiaThue,GiaCoc,DienTich,Mota,SDT,LienHe,DiaChi,NgayDang,NgayHetHan,TrangThai,Image")] PhongTro phongTro )
        {
            if (ModelState.IsValid)
            {
                db.PhongTroes.Add(phongTro);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.Id_ChuTro = new SelectList(db.ChuTroes, "Id_ChuTro", "TenChuTro", phongTro.Id_ChuTro);
            ViewBag.Id_LoaiPhong = new SelectList(db.LoaiPhongs, "Id_LoaiPhong", "TenLoaiPhong", phongTro.Id_LoaiPhong);
            return View(phongTro);
        }

        // GET: Admin/PhongTro/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhongTro phongTro = db.PhongTroes.Find(id);
            if (phongTro == null)
            {
                return HttpNotFound();
            }
            ViewBag.Id_ChuTro = new SelectList(db.ChuTroes, "Id_ChuTro", "TenChuTro", phongTro.Id_ChuTro);
            ViewBag.Id_LoaiPhong = new SelectList(db.LoaiPhongs, "Id_LoaiPhong", "TenLoaiPhong", phongTro.Id_LoaiPhong);
            return View(phongTro);
        }

        // POST: Admin/PhongTro/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id_PhongTro,Id_ChuTro,Id_LoaiPhong,Title,GiaThue,GiaCoc,DienTich,Mota,SDT,LienHe,DiaChi,NgayDang,NgayHetHan,TrangThai,Image")] PhongTro phongTro)
        {
            if (ModelState.IsValid)
            {
                db.Entry(phongTro).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.Id_ChuTro = new SelectList(db.ChuTroes, "Id_ChuTro", "TenChuTro", phongTro.Id_ChuTro);
            ViewBag.Id_LoaiPhong = new SelectList(db.LoaiPhongs, "Id_LoaiPhong", "TenLoaiPhong", phongTro.Id_LoaiPhong);
            return View(phongTro);
        }

        // GET: Admin/PhongTro/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PhongTro phongTro = db.PhongTroes.Find(id);
            if (phongTro == null)
            {
                return HttpNotFound();
            }
            return View(phongTro);
        }

        // POST: Admin/PhongTro/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhongTro phongTro = db.PhongTroes.Find(id);
            db.PhongTroes.Remove(phongTro);
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
