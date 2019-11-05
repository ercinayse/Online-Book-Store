namespace YeniProje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Resim")]
    public partial class Resim
    {
        public int Id { get; set; }

        public string BuyukYol { get; set; }

        public string OrtaYol { get; set; }

        public string KucukYol { get; set; }

        public bool? Varsayılan { get; set; }

        public byte? SiraNo { get; set; }

        public int? KitapID { get; set; }

        public virtual Kitap Kitap { get; set; }
    }
}
