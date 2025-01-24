using CarBook.Application.Features.Mediator.Results.CarPricingResults;
using CarBook.Application.Interfaces.CarPricingInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarPricingRepositories
{
    public class CarPricingRepository : ICarPricingRepository
    {
        private readonly CarBookContext _context;
        public CarPricingRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<CarPricing> GetCarPricingWithCars()
        {
            var values = _context.CarPricings
                .Include(x => x.Car)
                .ThenInclude(x => x.Brand)
                .Include(x => x.Pricing)
                .Where(x=> x.PricingID == 3).ToList();
            return values;
        }

        public List<GetCarPricingWithTimePeriodQueryResult> GetCarPricingWithTimePeriod()
        {
            var query = from carPricing in _context.CarPricings
                        join cars in _context.Cars on carPricing.CarID equals cars.CarID
                        join brands in _context.Brands on cars.BrandID equals brands.BrandID
                        group carPricing by new
                        {
                            BrandAndModel = brands.Name + " " + cars.Model,
                            CoverImageUrl = cars.CoverImageUrl,
                            CarID = cars.CarID
                        } into grouped
                        select new GetCarPricingWithTimePeriodQueryResult
                        {
                            BrandAndModel = grouped.Key.BrandAndModel,
                            CoverImageUrl= grouped.Key.CoverImageUrl,
                            CarID = grouped.Key.CarID,
                            DaileyAmount = grouped.Where(x => x.PricingID == 3).Sum(x => x.Amount),
                            WeeklyAmount = grouped.Where(x => x.PricingID == 4).Sum(x => x.Amount),
                            MonthlyAmount = grouped.Where(x => x.PricingID == 5).Sum(x => x.Amount)
                        };

            var values = query.ToList();
            return values;
        }
    }    
}