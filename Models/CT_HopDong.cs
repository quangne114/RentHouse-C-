namespace DACS_ThueTro.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_HopDong
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_HopDong { get; set; }

        public int? Id_KhachHang { get; set; }

        public int? Id_ChuTro { get; set; }

        public int? Id_PhongTro { get; set; }

        [StringLength(500)]
        public string DieuKhoan { get; set; }

        [StringLength(500)]
        public string MoTa { get; set; }

        public DateTime? NgayDang { get; set; }

        public DateTime? NgayHetHan { get; set; }

        public decimal? GiaCoc { get; set; }

        public decimal? GiaThue { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        [StringLength(50)]
        public string PhuongThucThanhToan { get; set; }

        [StringLength(50)]
        public string TrangThaiThanhToan { get; set; }

        public virtual ChuTro ChuTro { get; set; }

        public virtual HopDong HopDong { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual PhongTro PhongTro { get; set; }
    }
}
