using CarBook.Application.Interfaces.StatisticsInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.StatisticsRepositories
{
    public class StatisticsRepository : IStatisticsRepository
    {
        private readonly CarBookContext _context;
        public StatisticsRepository(CarBookContext context)
        {
            _context = context;
        }

        public int GetAuthorCount()
        {
            var value = _context.Authors.Count();
            return value;
        }

        public decimal GetAvgRentPriceForDailey()
        {
            int id = _context.Pricings.Where(x=> x.Name == "Günlük").Select(x=> x.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(x=> x.PricingID == id).Average(x=> x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForMonthly()
        {
            int id = _context.Pricings.Where(x => x.Name == "Aylık").Select(x => x.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(x => x.PricingID == id).Average(x => x.Amount);
            return value;
        }

        public decimal GetAvgRentPriceForWeekly()
        {
            int id = _context.Pricings.Where(x => x.Name == "Haftalık").Select(x => x.PricingID).FirstOrDefault();
            var value = _context.CarPricings.Where(x => x.PricingID == id).Average(x => x.Amount);
            return value;
        }

        public int GetBlogCount()
        {
            var value = _context.Blogs.Count();
            return value;
        }

        public string GetBlogTitleByMaxBlogComment()
        {
            /*Select Top(1) BlogID,COUNT(*) as 'YorumSayisi' From Comments
              Group BY BlogID Order By YorumSayisi Desc            
            */
            var value = _context.Comments.GroupBy(x=> x.BlogID)
            .Select(x=> new 
            {
                BlogId = x.Key,
                Count = x.Count(),
            }).OrderByDescending(x => x.Count).Take(1).FirstOrDefault();
            string blogTitle = _context.Blogs.Where(x=> x.BlogID == value.BlogId).Select(x=> x.Title).FirstOrDefault();
            return blogTitle;
        }

        public int GetBrandCount()
        {
            var value = _context.Brands.Count();
            return value;
        }

        public string GetBrandNameByMaxCar()
        {
            /*Select Top(1) Brands.Name,COUNT(*) as 'ToplamAraç' From Cars 
              Inner Join Brands On Cars.BrandID = Brands.BrandID 
              Group By Brands.Name Order By ToplamAraç Desc 
            */
            var value = _context.Cars.GroupBy(x => x.BrandID)
            .Select(x => new 
            { 
                BrandId = x.Key,
                Count = x.Count()
            }).OrderByDescending(x=> x.Count).Take(1).FirstOrDefault();
            string brandName = _context.Brands.Where(x => x.BrandID == value.BrandId).Select(x=> x.Name).FirstOrDefault();
            return brandName;
        }

        public string GetCarBrandAndModelByRentPriceDaileyMax()
        {           
            /*Select * From CarPricings
              Where Amount=(Select Max(Amount) From CarPricings Where PricingID = 4)
            */
            int pricingId = _context.Pricings.Where(x => x.Name == "Günlük").Select(x => x.PricingID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(x => x.PricingID == pricingId).Max(x => x.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(x => x.CarID).FirstOrDefault();
            string brandModel = _context.Cars.Where(x => x.CarID == carId).Include(x => x.Brand).Select(x => x.Brand.Name + " " + x.Model).FirstOrDefault();
            return brandModel;
        }

        public string GetCarBrandAndModelByRentPriceDaileyMin()
        {
            /*Select * From CarPricings 
              Where Amount=(Select Min(Amount) From CarPricings Where PricingID = 4)
            */
            int pricingId = _context.Pricings.Where(x => x.Name == "Günlük").Select(x => x.PricingID).FirstOrDefault();
            decimal amount = _context.CarPricings.Where(x => x.PricingID == pricingId).Min(x => x.Amount);
            int carId = _context.CarPricings.Where(x => x.Amount == amount).Select(x => x.CarID).FirstOrDefault();
            string brandModel = _context.Cars.Where(x => x.CarID == carId).Include(x => x.Brand).Select(x => x.Brand.Name + " " + x.Model).FirstOrDefault();
            return brandModel;
        }

        public int GetCarCount()
        {
            var value = _context.Cars.Count();
            return value;
        }

        public int GetCarCountByFualElectiric()
        {
            var value = _context.Cars.Where(x => x.Fuel == "Elektirikli").Count();
            return value;
        }

        public int GetCarCountByFualGasolineOrDiesel()
        {
            var value = _context.Cars.Where(x=> x.Fuel == "Benzin" || x.Fuel == "Dizel").Count();
            return value;
        }

        public int GetCarCountByKmSmallerThan1000()
        {
            var value = _context.Cars.Where(x=> x.Km <= 1000).Count();
            return value;
        }

        public int GetCarCountByTranmissionAuto()
        {
            var value = _context.Cars.Where(x => x.Transmission == "Otomatik").Count();
            return value;
        }

        public int GetLocationCount()
        {
            var value = _context.Locations.Count();
            return value;
        }
    }
}
