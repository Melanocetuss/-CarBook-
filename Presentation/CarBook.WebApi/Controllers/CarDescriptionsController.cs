using CarBook.Application.Features.Mediator.Queries.CarDescriptionsQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarDescriptionsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public CarDescriptionsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> CarDecriptionsByCarId(int id)
        {
            var values = await _mediator.Send(new GetCarDescriptionsByCarIdQuery(id));
            return Ok(values);
        }
    }
}