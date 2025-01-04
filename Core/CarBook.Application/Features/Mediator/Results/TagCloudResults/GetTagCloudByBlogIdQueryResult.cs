using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Results.TagCloudResults
{
    public class GetTagCloudByBlogIdQueryResult
    {
        public int tagCloudID { get; set; }
        public string title { get; set; }
        public int blogID { get; set; }
    }
}