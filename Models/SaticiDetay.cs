namespace YeniProje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("SaticiDetay")]
    public partial class SaticiDetay
    {
        [Key]
        public int satıcıdetayid { get; set; }

        public int? kitapID { get; set; }

        public int? satıcıID { get; set; }

        public virtual Kitap Kitap { get; set; }

        public virtual Satıcı Satıcı { get; set; }
    }
}
