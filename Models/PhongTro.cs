namespace DACS_ThueTro.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Security.Cryptography.X509Certificates;
    using System.Web;

    [Table("PhongTro")]
    public partial class PhongTro
    {
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PhongTro()
        {
            CT_HinhAnhPTro = new HashSet<CT_HinhAnhPTro>();
            CT_HopDong = new HashSet<CT_HopDong>();
            CT_PhanHoi = new HashSet<CT_PhanHoi>();

        }


        [Key]
            
        public int Id_PhongTro { get; set; }

        public int? Id_ChuTro { get; set; }

        public int? Id_LoaiPhong { get; set; }

       /* [StringLength(100)]
        public string Id_ThanhPho { get; set; }

        [StringLength(100)]
        public string Id_Quan { get; set; }

        [StringLength(100)]
        public string Id_Duong { get; set; }*/

        [StringLength(500)]
        public string Title { get; set; }
        public decimal? GiaThue { get; set; }

        public decimal? GiaCoc { get; set; }

        public decimal? DienTich { get; set; }

        [StringLength(500)]
        public string Mota { get; set; }

        [StringLength(500)]
        public string Image { get; set; }
       
        public int? SDT { get; set; }

        [StringLength(500)]
        public string LienHe { get; set; }

        [StringLength(500)]
        public string DiaChi { get; set; }

        public DateTime? NgayDang { get; set; }

        public DateTime? NgayHetHan { get; set; }

        [StringLength(50)]
        public string TrangThai { get; set; }

        public virtual ChuTro ChuTro { get; set; }
 

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HinhAnhPTro> CT_HinhAnhPTro { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HopDong> CT_HopDong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PhanHoi> CT_PhanHoi { get; set; }

  /*      public virtual Duong Duong { get; set; }*/

        public virtual LoaiPhong LoaiPhong { get; set; }
    }
}
