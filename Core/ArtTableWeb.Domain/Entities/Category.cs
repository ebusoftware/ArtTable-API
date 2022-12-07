using ArtTableWeb.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Domain.Entities
{
    public class Category:BaseEntity
    {
        public string Name { get; set; }
        public string Description{ get; set; }
        public bool CategoryStatus { get; set; } = true;
        public ICollection<Product> Products { get; set; }
    }
}
