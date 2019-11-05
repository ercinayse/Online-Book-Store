namespace YeniProje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Kitap")]
    public partial class Kitap
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Kitap()
        {
            SaticiDetay = new HashSet<SaticiDetay>();
            SatisDetay = new HashSet<SatisDetay>();
            Resim = new HashSet<Resim>();
        }

        public int kitapID { get; set; }

        [Required]
        [StringLength(60)]
        public string ad { get; set; }

        public int? fiyat { get; set; }

        public int? stok { get; set; }

        public int? kategoriID { get; set; }

        public int? yayıneviID { get; set; }

        public int? sayfasayısı { get; set; }

        public int? yayıntarihi { get; set; }

        public int? yazarID { get; set; }

        public virtual Kategori Kategori { get; set; }

        public virtual Yayınevi Yayınevi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SaticiDetay> SaticiDetay { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SatisDetay> SatisDetay { get; set; }

        public virtual Yazar Yazar { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Resim> Resim { get; set; }
    }
}
