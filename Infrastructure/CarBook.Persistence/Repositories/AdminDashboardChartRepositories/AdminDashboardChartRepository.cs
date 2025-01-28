using CarBook.Application.Features.Mediator.Results.AdminDashboardChartResult;
using CarBook.Application.Interfaces.AdminDashboardChartInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.AdminDashboardChartRepositories
{
    public class AdminDashboardChartRepository : IAdminDashboardChartRepository
    {
        private readonly CarBookContext _context;
        public AdminDashboardChartRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<GetCarCountByBrandNameQueryResult> GetCarCountByBrandName()
        {
            var values = _context.Cars
                .Join(
                    _context.Brands,
                    car => car.BrandID,
                    brand => brand.BrandID,
                    (car, brand) => new { brand.Name, car.CarID}
                )
                .GroupBy(x => x.Name)
                .Select(g => new GetCarCountByBrandNameQueryResult 
                {
                    BrandName = g.Key,
                    CarCount  = g.Count()
                }).ToList();

            return values;
        }

        public List<GetCarCountByLocationNameQueryResult> GetCarCountByLocationName()
        {
            var values = _context.RentACars
                .Join(                  
                    _context.Cars,
                    rentACar => rentACar.CarID,
                    car => car.CarID,
                    (rentACar, car) => new { rentACar.LocationID, car.CarID }
                )
                .Join(
                    _context.Locations,
                    rentACarCar => rentACarCar.LocationID,
                    location => location.LocationID,      
                    (rentACarCar, location) => new { location.Name, rentACarCar.CarID }
                )
                .GroupBy(x => x.Name)
                .Select(g => new GetCarCountByLocationNameQueryResult
                {
                    LocationName = g.Key,
                    CarCount = g.Count() 
                 }).ToList();

            return values;
        }
    }
}