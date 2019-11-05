namespace YeniProje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SatisDetay")]
    public partial class SatisDetay
    {
        [Key]
        public int detayID { get; set; }

        public int? kitapID { get; set; }

        public int? siparisID { get; set; }

        public int? adet { get; set; }

        public int? tutar { get; set; }

        public virtual Kitap Kitap { get; set; }

        public virtual Satis Satis { get; set; }
    }
}
