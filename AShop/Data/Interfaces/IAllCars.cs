using AShop.Data.Models;

namespace AShop.Data.Interfaces;

public interface IAllCars
{
    IEnumerable<Car> Cars { get; }
    IEnumerable<Car> getFavCars { get; }
    
    Car getObjectCar(int carId);
}