using ArtTableWeb.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Domain.Entities
{
    public class Product:BaseEntity
    {
        public Guid CategoryId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int  Stock { get; set; }
        public long Price { get; set; }
        public bool Status { get; set; } = true;
        public ICollection<Order> orders { get; set; }
        public ICollection<ProductImageFile> ProductImageFiles { get; set; }
        public Category Category { get; set; }


    }
}
