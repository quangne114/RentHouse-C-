using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DACS_ThueTro.Models;
using Microsoft.AspNet.Identity;

namespace DACS_ThueTro.Controllers
{
    public class PhongTroesController : Controller
    {
        private ThueTro db = new ThueTro();

        
        // GET: PhongTroes
        public ActionResult Index()
        {

            var phongTroes = db.PhongTroes.Include(p => p.ChuTro).Include(p => p.LoaiPhong);
            return View(phongTroes.ToList());
        }

        // GET: PhongTroes/Details/5
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

        // GET: PhongTroes/Create
        public ActionResult Create()
        {
            string currentUserId = User.Identity.GetUserId();
           
            if (currentUserId == null)
            {
                return RedirectToAction("Login", "Account", new {area = ""});
            }
            else
            {
                ViewBag.Id_ChuTro = new SelectList(db.ChuTroes, "Id_ChuTro", "TenChuTro");

                ViewBag.Id_LoaiPhong = new SelectList(db.LoaiPhongs, "Id_LoaiPhong", "TenLoaiPhong");
                return View();
            }

        }

        // POST: PhongTroes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id_PhongTro,Id_ChuTro,Id_LoaiPhong,Title,GiaThue,GiaCoc,DienTich,Mota,SDT,LienHe,NgayDang,NgayHetHan,TrangThai,Image")] PhongTro phongTro, string address_sum, HttpPostedFileBase image)
        {
            if (image != null && image.ContentLength > 0)
            {
                string fileName = Path.GetFileName(image.FileName);
                string urlImage = Server.MapPath("~/Content/AnhTro/" + fileName);
                image.SaveAs(urlImage);

                phongTro.Image = "~/Content/AnhTro/" + fileName;

            }
            phongTro.DiaChi = address_sum;
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

        // GET: PhongTroes/Edit/5
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

        // POST: PhongTroes/Edit/5
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

        // GET: PhongTroes/Delete/5
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

        // POST: PhongTroes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PhongTro phongTro = db.PhongTroes.Find(id);
            db.PhongTroes.Remove(phongTro);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Search(string location)
        {
            
            /*var results = (from m in context.PhongTroes where m.DiaChi.Contains(searchString) select m).ToList();*/
            var results = db.PhongTroes.Include(p => p.ChuTro).Include(p => p.LoaiPhong).Where(p => p.DiaChi.ToLower().Contains(location.ToLower())).ToList();
            return View("Index", results);
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
