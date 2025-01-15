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
    public class GetCarCountByFualGasolineOrDieselQueryHandler : IRequestHandler<GetCarCountByFualGasolineOrDieselQuery, GetCarCountByFualGasolineOrDieselQueryResult>
    {
        private readonly IStatisticsRepository _repository;
        public GetCarCountByFualGasolineOrDieselQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountByFualGasolineOrDieselQueryResult> Handle(GetCarCountByFualGasolineOrDieselQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountByFualGasolineOrDiesel();
            return new GetCarCountByFualGasolineOrDieselQueryResult
            {
                CarCountByFualGasolineOrDiesel = value
            };
        }
    }
}