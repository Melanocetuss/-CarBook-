using CarBook.Application.Features.Mediator.Results.AdminDashboardChartResult;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.AdminDashboardChartQueries
{
    public class GetCarCountByBrandNameQuery : IRequest<List<GetCarCountByBrandNameQueryResult>>
    {
    }
}