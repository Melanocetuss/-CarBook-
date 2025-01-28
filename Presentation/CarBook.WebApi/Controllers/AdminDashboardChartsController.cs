using CarBook.Application.Features.Mediator.Queries.AdminDashboardChartQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminDashboardChartsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AdminDashboardChartsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("CarCountByBrandNameQuery")]
        public async Task<IActionResult> CarCountByBrandNameQuery()
        {
            var values = await _mediator.Send(new GetCarCountByBrandNameQuery());
            return Ok(values);
        }

        [HttpGet("CarCountByLocationNameQuery")]
        public async Task<IActionResult> CarCountByLocationNameQuery()
        {
            var values = await _mediator.Send(new GetCarCountByLocationNameQuery());
            return Ok(values);
        }
    }
}
