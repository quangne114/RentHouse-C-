namespace DACS_ThueTro.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("ChuTro")]
    public partial class ChuTro
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public ChuTro()
        {
            CT_HopDong = new HashSet<CT_HopDong>();
            PhongTroes = new HashSet<PhongTro>();
        }

        [Key]
        public int Id_ChuTro { get; set; }

        [StringLength(500)]
        public string TenChuTro { get; set; }

        public int? SDT { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string UrlHinhAnh { get; set; }

        [StringLength(128)]
        public string Id_AspNetUser { get; set; }

        public virtual AspNetUser AspNetUser { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CT_HopDong> CT_HopDong { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PhongTro> PhongTroes { get; set; }
    }
}
