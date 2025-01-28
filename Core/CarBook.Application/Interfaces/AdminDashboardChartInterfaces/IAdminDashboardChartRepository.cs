using CarBook.Application.Features.Mediator.Results.AdminDashboardChartResult;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.AdminDashboardChartInterfaces
{
    public interface IAdminDashboardChartRepository
    {
        List<GetCarCountByBrandNameQueryResult> GetCarCountByBrandName();
        List<GetCarCountByLocationNameQueryResult> GetCarCountByLocationName();
    }
}