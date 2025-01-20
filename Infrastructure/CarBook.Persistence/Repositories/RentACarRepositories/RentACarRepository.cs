using CarBook.Application.Interfaces.RentACarInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.RentACarRepositories
{
    public class RentACarRepository : IRentACarRepository
    {
        private readonly CarBookContext _context;
        public RentACarRepository(CarBookContext context)
        {
            _context = context;
        }

        public async Task<List<RentACar>> GetByFilterAsync(Expression<Func<RentACar, bool>> filter)
        {
            var values = await _context.RentACars
            .Where(filter)
            .Include(x=> x.Car)
            .ThenInclude(x=> x.Brand)
            .Include(x=> x.Car)
            .ThenInclude(x=> x.CarPricings)
            .ToListAsync();

            return values;
        }
    }
}