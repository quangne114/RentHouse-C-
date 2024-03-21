namespace DACS_ThueTro.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PhanHoi")]
    public partial class PhanHoi
    {
        [Key]
        public int Id_PhanHoi { get; set; }

        [StringLength(500)]
        public string Title { get; set; }

        public DateTime? NgayHetHan { get; set; }

        public DateTime? NgayDang { get; set; }

        public virtual CT_PhanHoi CT_PhanHoi { get; set; }
    }
}
