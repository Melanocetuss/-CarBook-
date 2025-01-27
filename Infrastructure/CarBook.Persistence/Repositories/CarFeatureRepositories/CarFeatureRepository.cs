using CarBook.Application.Interfaces.CarFeatureInterfaces;
using CarBook.Domain.Entities;
using CarBook.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Persistence.Repositories.CarFeatureRepositories
{
    public class CarFeatureRepository : ICarFeatureRepository
    {
        private readonly CarBookContext _context;
        public CarFeatureRepository(CarBookContext context)
        {
            _context = context;
        }

        public List<CarFeature> GetCarFeatureByCarID(int CarID)
        {
            var values = _context.CarFeatures.Include(x=> x.Feature).Where(x=> x.CarID == CarID).ToList();
            return values;
        }

        public void ChangeCarFeatureAvailableToFalse(int CarFeatureID)
        {
            var values = _context.CarFeatures.Where(x=> x.CarFeatureID == CarFeatureID).FirstOrDefault();
            values.Available = false;
            _context.SaveChanges();
        }

        public void ChangeCarFeatureAvailableToTrue(int CarFeatureID)
        {
            var values = _context.CarFeatures.Where(x => x.CarFeatureID == CarFeatureID).FirstOrDefault();
            values.Available = true;
            _context.SaveChanges();
        }

        public void CreateCarFeatureByCar(CarFeature carFeature)
        {
            _context.CarFeatures.Add(carFeature);
            _context.SaveChanges();
        }
    }
}
