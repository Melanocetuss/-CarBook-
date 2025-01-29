using CarBook.Application.Interfaces.CarDescriptionsInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarDescriptionsRepositories
{
    public class CarDescriptionsRepository : ICarDescriptionsRepository
    {
        private readonly CarBookContext _context;
        public CarDescriptionsRepository(CarBookContext context)
        {
            _context = context;
        }

        public CarDescription GetCarDescription(int CarID)
        {
            var values = _context.CarDescriptions.Where(x=> x.CarID == CarID).FirstOrDefault();
            return values;
        }
    }
}