namespace YeniProje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Uye")]
    public partial class Uye
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Uye()
        {
            Musteri = new HashSet<Musteri>();
            Satıcı = new HashSet<Satıcı>();
        }

        public int uyeID { get; set; }

        [Required]
        [StringLength(60)]
        public string ad { get; set; }

        [Required]
        [StringLength(60)]
        public string soyad { get; set; }

        public int telno { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dogumtarihi { get; set; }

        [Required]
        [StringLength(60)]
        public string kullancıadı { get; set; }

        [Required]
        [StringLength(255)]
        public string mail { get; set; }

        [Required]
        [StringLength(36)]
        public string sifre { get; set; }

        public string gizlisoru { get; set; }

        public string gizlicevap { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Musteri> Musteri { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Satıcı> Satıcı { get; set; }
    }
}
