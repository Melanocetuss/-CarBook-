using CarBook.Application.Features.Mediator.Results.CarDescriptionsResults;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Queries.CarDescriptionsQueries
{
    public class GetCarDescriptionsByCarIdQuery : IRequest<GetCarDescriptionsByCarIdQueryResult>
    {
        public int Id { get; set; }

        public GetCarDescriptionsByCarIdQuery(int id)
        {
            Id = id;
        }
    }
}