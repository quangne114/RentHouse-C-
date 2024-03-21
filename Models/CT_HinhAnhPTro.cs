namespace DACS_ThueTro.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CT_HinhAnhPTro
    {
        [Key]
        public int Id_CTHinhAnh { get; set; }

        [StringLength(500)]
        public string Url_HinhAnh { get; set; }

        public int? Id_PhongTro { get; set; }

        public virtual PhongTro PhongTro { get; set; }
    }
}
