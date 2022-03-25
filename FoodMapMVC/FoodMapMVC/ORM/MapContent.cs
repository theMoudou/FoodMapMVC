namespace FoodMapMVC.ORM
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MapContent
    {
        public Guid ID { get; set; }

        [Required]
        [StringLength(200)]
        public string Title { get; set; }

        [Required]
        public string Body { get; set; }

        [Required]
        [StringLength(500)]
        public string CoverImage { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public bool IsEnable { get; set; }

        public DateTime CreateDate { get; set; }

        public Guid CreateUser { get; set; }

        public DateTime? UpdateDate { get; set; }

        public Guid? UpdateUser { get; set; }

        public DateTime? DeleteDate { get; set; }

        public Guid? DeleteUser { get; set; }
    }
}
