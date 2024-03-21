using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace DACS_ThueTro.Models
{
    public partial class ThueTro : DbContext
    {
        public ThueTro()
            : base("name=ThueTro")
        {
        }

        public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        public virtual DbSet<ChuTro> ChuTroes { get; set; }
        public virtual DbSet<CT_HinhAnhPTro> CT_HinhAnhPTro { get; set; }
        public virtual DbSet<CT_HopDong> CT_HopDong { get; set; }
        public virtual DbSet<CT_PhanHoi> CT_PhanHoi { get; set; }
        public virtual DbSet<Duong> Duongs { get; set; }
        public virtual DbSet<HopDong> HopDongs { get; set; }
        public virtual DbSet<KhachHang> KhachHangs { get; set; }
        public virtual DbSet<LoaiPhong> LoaiPhongs { get; set; }
        public virtual DbSet<PhanHoi> PhanHois { get; set; }
        public virtual DbSet<PhongTro> PhongTroes { get; set; }
        public virtual DbSet<Quan> Quans { get; set; }
        public virtual DbSet<ThanhPho> ThanhPhoes { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AspNetRole>()
                .HasMany(e => e.AspNetUsers)
                .WithMany(e => e.AspNetRoles)
                .Map(m => m.ToTable("AspNetUserRoles").MapLeftKey("RoleId").MapRightKey("UserId"));

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserClaims)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.AspNetUserLogins)
                .WithRequired(e => e.AspNetUser)
                .HasForeignKey(e => e.UserId);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.ChuTroes)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.Id_AspNetUser);

            modelBuilder.Entity<AspNetUser>()
                .HasMany(e => e.KhachHangs)
                .WithOptional(e => e.AspNetUser)
                .HasForeignKey(e => e.Id_AspNetUser);

            modelBuilder.Entity<ChuTro>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<ChuTro>()
                .Property(e => e.UrlHinhAnh)
                .IsUnicode(false);

            modelBuilder.Entity<CT_HinhAnhPTro>()
                .Property(e => e.Url_HinhAnh)
                .IsUnicode(false);

            modelBuilder.Entity<CT_HopDong>()
                .Property(e => e.GiaCoc)
                .HasPrecision(18, 0);

            modelBuilder.Entity<CT_HopDong>()
                .Property(e => e.GiaThue)
                .HasPrecision(18, 0);

            modelBuilder.Entity<HopDong>()
                .HasOptional(e => e.CT_HopDong)
                .WithRequired(e => e.HopDong);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<KhachHang>()
                .Property(e => e.UrlHinhAnh)
                .IsUnicode(false);

            modelBuilder.Entity<PhanHoi>()
                .HasOptional(e => e.CT_PhanHoi)
                .WithRequired(e => e.PhanHoi);

            modelBuilder.Entity<PhongTro>()
                .Property(e => e.GiaThue)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PhongTro>()
                .Property(e => e.GiaCoc)
                .HasPrecision(18, 0);

            modelBuilder.Entity<PhongTro>()
                .Property(e => e.DienTich)
                .HasPrecision(18, 0);
        }
    }
}
