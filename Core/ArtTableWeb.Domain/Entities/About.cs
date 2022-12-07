using ArtTableWeb.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Domain.Entities
{
    public class About:BaseEntity
    {
        public string Details { get; set; }
        public bool Status { get; set; } = true;
        public string MapLocation { get; set; }
    }
}
