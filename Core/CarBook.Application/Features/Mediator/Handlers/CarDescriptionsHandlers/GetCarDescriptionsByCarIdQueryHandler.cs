using CarBook.Application.Features.Mediator.Queries.CarDescriptionsQueries;
using CarBook.Application.Features.Mediator.Results.CarDescriptionsResults;
using CarBook.Application.Interfaces;
using CarBook.Application.Interfaces.CarDescriptionsInterfaces;
using CarBook.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.Mediator.Handlers.CarDescriptionsHandlers
{
    public class GetCarDescriptionsByCarIdQueryHandler : IRequestHandler<GetCarDescriptionsByCarIdQuery, GetCarDescriptionsByCarIdQueryResult>
    {
        private readonly ICarDescriptionsRepository _repository;
        public GetCarDescriptionsByCarIdQueryHandler(ICarDescriptionsRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarDescriptionsByCarIdQueryResult> Handle(GetCarDescriptionsByCarIdQuery request, CancellationToken cancellationToken)
        {
            var values = _repository.GetCarDescription(request.Id);
            return new GetCarDescriptionsByCarIdQueryResult
            {
                CarDescriptionID = values.CarDescriptionID,
                CarID = values.CarID,
                Details = values.Details
            };
        }
    }
}