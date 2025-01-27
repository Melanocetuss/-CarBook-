using CarBook.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Application.Interfaces.CarFeatureInterfaces
{
    public interface ICarFeatureRepository
    {
        List<CarFeature> GetCarFeatureByCarID(int CarID);
        void ChangeCarFeatureAvailableToFalse(int CarFeatureID);
        void ChangeCarFeatureAvailableToTrue(int CarFeatureID);
        void CreateCarFeatureByCar(CarFeature carFeature);
    }
}
