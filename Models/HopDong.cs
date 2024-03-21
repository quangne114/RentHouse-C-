namespace DACS_ThueTro.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("HopDong")]
    public partial class HopDong
    {
        [Key]
        public int Id_HopDong { get; set; }

        [StringLength(50)]
        public string Title { get; set; }

        public DateTime? NgayDang { get; set; }

        public DateTime? NgayHetHan { get; set; }

        public virtual CT_HopDong CT_HopDong { get; set; }
    }
}
