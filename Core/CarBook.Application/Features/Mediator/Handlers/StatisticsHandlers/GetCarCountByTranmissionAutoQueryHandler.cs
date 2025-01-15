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
    public class GetCarCountByTranmissionAutoQueryHandler : IRequestHandler<GetCarCountByTranmissionAutoQuery, GetCarCountByTranmissionAutoQueryResult>
    {
        private readonly IStatisticsRepository _repository;
        public GetCarCountByTranmissionAutoQueryHandler(IStatisticsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarCountByTranmissionAutoQueryResult> Handle(GetCarCountByTranmissionAutoQuery request, CancellationToken cancellationToken)
        {
            var value = _repository.GetCarCountByTranmissionAuto();
            return new GetCarCountByTranmissionAutoQueryResult
            {
                CarCountByTranmissionAuto = value
            };
        }
    }
}