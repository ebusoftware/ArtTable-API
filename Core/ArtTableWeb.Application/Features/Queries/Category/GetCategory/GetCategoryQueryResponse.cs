using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Application.Features.Queries.Category.GetCategory
{
    public class GetCategoryQueryResponse
    {
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool CategoryStatus { get; set; }
    }
}
