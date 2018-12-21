using System;
using System.Collections.Generic;

namespace WebApiRugby.Models
{
    public partial class SeasonPoints
    {
        public int SeasonPointId { get; set; }
        public int PointTypeId { get; set; }
        public int SeasonId { get; set; }
        public int Value { get; set; }

        public PointType PointType { get; set; }
        public Season Season { get; set; }
    }
}
