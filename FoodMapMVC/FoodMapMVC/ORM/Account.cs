namespace FoodMapMVC.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Account
    {
        public Guid ID { get; set; }

        [Column("Account")]
        [Required]
        [StringLength(50)]
        public string Account1 { get; set; }

        [Required]
        [StringLength(50)]
        public string PWD { get; set; }

        public int UserLevel { get; set; }

        public bool IsEnable { get; set; }

        public DateTime CreateDate { get; set; }
    }
}
