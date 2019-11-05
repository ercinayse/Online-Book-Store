namespace YeniProje.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Fatura")]
    public partial class Fatura
    {
        public int FaturaID { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FaturaTarihi { get; set; }

        public int? siparisID { get; set; }

        public virtual Satis Satis { get; set; }
    }
}
