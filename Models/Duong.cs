namespace DACS_ThueTro.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Duong")]
    public partial class Duong
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
       

        [Key]
        [StringLength(100)]
        public string Id_Duong { get; set; }

        [StringLength(50)]
        public string TenDuong { get; set; }

        [StringLength(100)]
        public string Id_Quan { get; set; }

        public virtual Quan Quan { get; set; }

    }
}
