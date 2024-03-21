namespace DACS_ThueTro.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Quan")]
    public partial class Quan
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Quan()
        {
            Duongs = new HashSet<Duong>();
        }

        [Key]
        [StringLength(100)]
        public string Id_Quan { get; set; }

        [StringLength(50)]
        public string TenQuan { get; set; }

        [StringLength(100)]
        public string Id_ThanhPho { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Duong> Duongs { get; set; }

        public virtual ThanhPho ThanhPho { get; set; }
    }
}
