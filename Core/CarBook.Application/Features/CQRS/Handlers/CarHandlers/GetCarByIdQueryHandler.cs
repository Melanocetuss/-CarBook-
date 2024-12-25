using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces;
using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarByIdQueryHandler
    {
        private readonly IRepository<Car> _repository;
        public GetCarByIdQueryHandler(IRepository<Car> repository)
        {
            _repository = repository;
        }

        public async Task<GetCarByIdQueryResult> Handle(GetCarByIdQuery query)
        {
            var values = await _repository.GetByIdAsync(query.Id);
            return new GetCarByIdQueryResult
            {
                CarID = values.CarID,
                BrandID = values.BrandID,
                Model = values.Model,
                CoverImageUrl = values.CoverImageUrl,
                Km = values.Km,
                Transmission  = values.Transmission,
                Seat = values.Seat,
                Luggage = values.Luggage,
                Fuel = values.Fuel,
                BigImageUrl = values.BigImageUrl
            };
        }
    }
}