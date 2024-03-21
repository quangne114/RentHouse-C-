namespace DACS_ThueTro.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_PhanHoi
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id_PhanHoi { get; set; }

        public int? Id_KhachHang { get; set; }

        public int? Id_PhongTro { get; set; }

        [StringLength(500)]
        public string NoiDungPhanHoi { get; set; }

        public DateTime? NgayPhanHoi { get; set; }

        public virtual KhachHang KhachHang { get; set; }

        public virtual PhanHoi PhanHoi { get; set; }

        public virtual PhongTro PhongTro { get; set; }
    }
}
