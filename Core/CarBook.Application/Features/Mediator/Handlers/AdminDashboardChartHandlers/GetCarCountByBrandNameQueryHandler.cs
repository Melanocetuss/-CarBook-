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
    public class GetCarCountByBrandNameQueryHandler : IRequestHandler<GetCarCountByBrandNameQuery, List<GetCarCountByBrandNameQueryResult>>
    {
        private readonly IAdminDashboardChartRepository _repository;
        public GetCarCountByBrandNameQueryHandler(IAdminDashboardChartRepository repository)
        {
            _repository = repository;
        }

        public Task<List<GetCarCountByBrandNameQueryResult>> Handle(GetCarCountByBrandNameQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarCountByBrandName();
            return Task.FromResult(values);
        }
    }
}