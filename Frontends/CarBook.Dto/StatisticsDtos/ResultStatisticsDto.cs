using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.StatisticsDtos
{
    public class ResultStatisticsDto
    {
        public int CarCount { get; set; }
        public int LocationCount { get; set; }
        public int AuthorCount { get; set; }
        public int BlogCount { get; set; }
        public int BrandCount { get; set; }
        public decimal AvgRentPriceForDailey { get; set; }
        public decimal AvgRentPriceForWeekly { get; set; }
        public decimal AvgRentPriceForMonthly { get; set; }
        public int CarCountByTranmissionAuto { get; set; }
        public string BrandNameByMaxCar { get; set; }
        public string BlogTitleByMaxBlogComment { get; set; }
        public int CarCountByKmSmallerThan1000 { get; set; }
        public int CarCountByFualGasolineOrDiesel { get; set; }
        public int CarCountByFualElectiric { get; set; }
        public string CarBrandAndModelByRentPriceDaileyMax { get; set; }
        public string CarBrandAndModelByRentPriceDaileyMin { get; set; }
        
    }
}