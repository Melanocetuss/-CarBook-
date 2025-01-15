using CarBook.Application.Features.Mediator.Queries.StatisticsQueries;
using CarBook.Application.Features.Mediator.Results.StatisticsResults;
using CarBook.Application.Interfaces.StatisticsInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.StatisticsHandlers
{
    public class GetAvgRentPriceForDaileyQueryHandler : IRequestHandler<GetAvgRentPriceForDaileyQuery, GetAvgRentPriceForDaileyQueryResult>
    {
        private readonly IStatisticsRepository _repository;
        public GetAvgRentPriceForDaileyQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetAvgRentPriceForDaileyQueryResult> Handle(GetAvgRentPriceForDaileyQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetAvgRentPriceForDailey();
            return new GetAvgRentPriceForDaileyQueryResult
            {
                AvgRentPriceForDailey = value
            };
        }
    }
}