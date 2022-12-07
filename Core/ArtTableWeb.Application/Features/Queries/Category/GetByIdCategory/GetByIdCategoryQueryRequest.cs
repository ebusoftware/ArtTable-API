﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArtTableWeb.Application.Features.Queries.Category.GetByIdCategory
{
    public class GetByIdCategoryQueryRequest:IRequest<GetByIdCategoryQueryResponse>
    {
        public string Id { get; set; }
    }
}
