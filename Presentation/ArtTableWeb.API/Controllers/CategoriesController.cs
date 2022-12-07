using ArtTableWeb.Application.Features.Commands.Category.CreateCategory;
using ArtTableWeb.Application.Features.Commands.Category.DeleteCategory;
using ArtTableWeb.Application.Features.Commands.Category.UpdateCategory;
using ArtTableWeb.Application.Features.Queries.Category.GetByIdCategory;
using ArtTableWeb.Application.Features.Queries.Category.GetCategory;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ArtTableWeb.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        IMediator _mediator;

        public CategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll([FromQuery] GetCategoryQueryRequest getCategoryQueryRequest)
        {
            List<GetCategoryQueryResponse> response = await _mediator.Send(getCategoryQueryRequest);
            return Ok(response);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetById([FromRoute] GetByIdCategoryQueryRequest getByIdCategoryQueryRequest)
        {
            GetByIdCategoryQueryResponse response = await _mediator.Send(getByIdCategoryQueryRequest);
            return Ok(response);
        }
        [HttpPost]
        public async Task<IActionResult> Post([FromQuery] CreateCategoryCommandRequest createCategoryCommandRequest)
        {
            CreateCategoryCommandResponse response = await _mediator.Send(createCategoryCommandRequest);
            return Ok(response);
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromQuery] UpdateCategoryCommandRequest updateCategoryCommandRequest)
        {
            UpdateCategoryCommandResponse response = await _mediator.Send(updateCategoryCommandRequest);
            return Ok(response);
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute] DeleteCategoryCommandRequest deleteCategoryCommandRequest)
        {
            DeleteCategoryCommandResponse response = await _mediator.Send(deleteCategoryCommandRequest);
            return Ok(response);
        }
    }
}
