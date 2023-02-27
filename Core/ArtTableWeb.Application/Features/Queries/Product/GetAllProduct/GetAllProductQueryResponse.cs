using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Application.Features.Queries.Product.GetAllProduct
{
    public class GetAllProductQueryResponse
    {
        public object Products { get; set; }
        public object Categories { get; set; }

        public int TotalProductCount { get; set; }
        
    }
}
