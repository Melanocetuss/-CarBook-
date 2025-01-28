using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.AdminDashboardChartDtos
{
    public class ResultCarCountByLocationNameDto
    {
        public string LocationName { get; set; }
        public int CarCount { get; set; }
    }
}