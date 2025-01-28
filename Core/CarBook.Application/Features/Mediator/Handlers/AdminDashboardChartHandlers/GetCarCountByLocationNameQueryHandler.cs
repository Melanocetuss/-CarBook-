using CarBook.Application.Features.Mediator.Queries.AdminDashboardChartQueries;
using CarBook.Application.Features.Mediator.Results.AdminDashboardChartResult;
using CarBook.Application.Interfaces.AdminDashboardChartInterfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.AdminDashboardChartHandlers
{
    public class GetCarCountByLocationNameQueryHandler : IRequestHandler<GetCarCountByLocationNameQuery, List<GetCarCountByLocationNameQueryResult>>
    {
        private readonly IAdminDashboardChartRepository _repository;
        public GetCarCountByLocationNameQueryHandler(IAdminDashboardChartRepository repository)
        {
            _repository = repository;
        }

        public Task<List<GetCarCountByLocationNameQueryResult>> Handle(GetCarCountByLocationNameQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarCountByLocationName();
            return Task.FromResult(values);
        }
    }
}