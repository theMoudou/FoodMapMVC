﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodMapMVC.Models
{
    public class FoodMapViewModel
    {
        public Guid ID { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }

        public string CoverImage { get; set; }

        public double Longitude { get; set; }

        public double Latitude { get; set; }

        public bool IsEnable { get; set; }

        public DateTime CreateDate { get; set; }
    }
}