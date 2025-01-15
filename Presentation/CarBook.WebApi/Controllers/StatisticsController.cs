using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StatisticsController : ControllerBase
    {
        private readonly IMediator _mediator;
        public StatisticsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetCarCount")]
        public async Task<IActionResult> GetCarCount()
        {
            var values = await _mediator.Send(new GetCarCountQuery());
            return Ok(values);
        }

        [HttpGet("GetLocationCount")]
        public async Task<IActionResult> GetLocationCount()
        {
            var values = await _mediator.Send(new GetLocationCountQuery());
            return Ok(values);
        }

        [HttpGet("GetAuthorCount")]
        public async Task<IActionResult> GetAuthorCount()
        {
            var values = await _mediator.Send(new GetAuthorCountQuery());
            return Ok(values);
        }

        [HttpGet("GetBlogCount")]
        public async Task<IActionResult> GetBlogCount()
        {
            var values = await _mediator.Send(new GetBlogCountQuery());
            return Ok(values);
        }

        [HttpGet("GetBrandCount")]
        public async Task<IActionResult> GetBrandCount()
        {
            var values = await _mediator.Send(new GetBrandCountQuery());
            return Ok(values);
        }

        [HttpGet("GetAvgRentPriceForDailey")]
        public async Task<IActionResult> GetAvgRentPriceForDailey()
        {
            var values = await _mediator.Send(new GetAvgRentPriceForDaileyQuery());
            return Ok(values);
        }

        [HttpGet("GetAvgRentPriceForWeekly")]
        public async Task<IActionResult> GetAvgRentPriceForWeekly()
        {
            var values = await _mediator.Send(new GetAvgRentPriceForWeeklyQuery());
            return Ok(values);
        }

        [HttpGet("GetAvgRentPriceForMonthly")]
        public async Task<IActionResult> GetAvgRentPriceForMonthly()
        {
            var values = await _mediator.Send(new GetAvgRentPriceForMonthlyQuery());
            return Ok(values);
        }

        [HttpGet("GetCarCountByTranmissionAuto")]
        public async Task<IActionResult> GetCarCountByTranmissionAuto()
        {
            var values = await _mediator.Send(new GetCarCountByTranmissionAutoQuery());
            return Ok(values);
        }

        [HttpGet("GetBrandNameByMaxCar")]
        public async Task<IActionResult> GetBrandNameByMaxCar()
        {
            var values = await _mediator.Send(new GetBrandNameByMaxCarQuery());
            return Ok(values);
        }

        [HttpGet("GetBlogTitleByMaxBlogComment")]
        public async Task<IActionResult> GetBlogTitleByMaxBlogComment()
        {
            var values = await _mediator.Send(new GetBlogTitleByMaxBlogCommentQuery());
            return Ok(values);
        }

        [HttpGet("GetCarCountByKmSmallerThan1000")]
        public async Task<IActionResult> GetCarCountByKmSmallerThan1000()
        {
            var values = await _mediator.Send(new GetCarCountByKmSmallerThan1000Query());
            return Ok(values);
        }

        [HttpGet("GetCarCountByFualGasolineOrDiesel")]
        public async Task<IActionResult> GetCarCountByFualGasolineOrDiesel()
        {
            var values = await _mediator.Send(new GetCarCountByFualGasolineOrDieselQuery());
            return Ok(values);
        }

        [HttpGet("GetCarCountByFualElectiric")]
        public async Task<IActionResult> GetCarCountByFualElectiric()
        {
            var values = await _mediator.Send(new GetCarCountByFualElectiricQuery());
            return Ok(values);
        }

        [HttpGet("GetCarBrandAndModelByRentPriceDaileyMax")]
        public async Task<IActionResult> GetCarBrandAndModelByRentPriceDaileyMax()
        {
            var values = await _mediator.Send(new GetCarBrandAndModelByRentPriceDaileyMaxQuery());
            return Ok(values);
        }

        [HttpGet("GetCarBrandAndModelByRentPriceDaileyMin")]
        public async Task<IActionResult> GetCarBrandAndModelByRentPriceDaileyMin()
        {
            var values = await _mediator.Send(new GetCarBrandAndModelByRentPriceDaileyMinQuery());
            return Ok(values);
        }
    }
}