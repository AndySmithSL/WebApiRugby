using System;
using System.Collections.Generic;

namespace WebApiRugby.Models
{
    public partial class SchoolType
    {
        public SchoolType()
        {
            School = new HashSet<School>();
        }

        public short SchoolTypeId { get; set; }
        public string Type { get; set; }

        public ICollection<School> School { get; set; }
    }
}
