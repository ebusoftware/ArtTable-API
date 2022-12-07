using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Application.Features.Commands.Product.CreateProduct
{
    public class CreateProductCommandRequest:IRequest<CreateProductCommandResponse>
    {
        public string CategoryId{ get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int Stock { get; set; }
        public long Price { get; set; }
    }
}
