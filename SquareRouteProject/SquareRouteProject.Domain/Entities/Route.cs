﻿using SquareRouteProject.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SquareRouteProject.Domain.Entities
{
    public class Route
    {
        [Key]
        public int RouteId { get; set; }
        public int RouteNum { get; set; }
        public string RouteStart { get; set; }
        public string RouteEnd { get; set; }
        public int AccessCodeId { get; set; }
        public int DistrictId { get; set; }

        public virtual ICollection<BusStop> BusStops { get; set; }
        public virtual ICollection<RouteUser> Users { get; set; }
        public virtual ICollection<RouteSchool> Schools { get; set; }
    }
}