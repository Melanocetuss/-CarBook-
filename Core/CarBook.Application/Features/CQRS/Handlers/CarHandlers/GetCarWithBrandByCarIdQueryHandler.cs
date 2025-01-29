using CarBook.Application.Features.CQRS.Queries.CarQueries;
using CarBook.Application.Features.CQRS.Results.CarResults;
using CarBook.Application.Interfaces.CarInterfaces;

namespace CarBook.Application.Features.CQRS.Handlers.CarHandlers
{
    public class GetCarWithBrandByCarIdQueryHandler
    {
        private readonly ICarRepository _repository;
        public GetCarWithBrandByCarIdQueryHandler(ICarRepository repository)
        {
            _repository = repository;
        }

        public async Task<GetCarWithBrandByCarIdQueryResult> Handle(GetCarWithBrandByCarIdQuery query)
        {
            var values = _repository.CarWithBrandByCarId(query.Id);
            var result = values.Select(x => new GetCarWithBrandByCarIdQueryResult
            {
                BrandName = x.Brand.Name,
                Model = x.Model,
                BigImageUrl = x.BigImageUrl,
                Km = x.Km,
                Transmission = x.Transmission,
                Seat = x.Seat,
                Luggage = x.Luggage,
                Fuel = x.Fuel
            }).FirstOrDefault();  // Only return the first item if there's any

            return result;
        }
    }
}