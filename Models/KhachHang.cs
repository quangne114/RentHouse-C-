namespace DACS_ThueTro.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("KhachHang")]
    public partial class KhachHang
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public KhachHang()
        {
            CT_HopDong = new HashSet<CT_HopDong>();
            CT_PhanHoi = new HashSet<CT_PhanHoi>();
        }

        [Key]
        public int Id_KhachHang { get; set; }

        [StringLength(500)]
        public string TenKhachHang { get; set; }

        public int? SDT { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(500)]
        public string UrlHinhAnh { get; set; }

        [StringLength(128)]
        public string Id_AspNetUser { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HopDong> CT_HopDong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_PhanHoi> CT_PhanHoi { get; set; }
    }
}
