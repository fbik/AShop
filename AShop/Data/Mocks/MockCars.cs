using AShop.Data.Interfaces;
using AShop.Data.Models;

namespace AShop.Data.Mocks;

public class MocksCars : IAllCars
{
    private readonly ICarsCategory _categoryCars = new MockCategory();
    private IAllCars _allCarsImplementation;

    public MocksCars(IEnumerable<Car> getFavCars)
    {
        this.getFavCars = getFavCars;
    }

    public IEnumerable<Car> Cars =>
        new List<Car>
        {
            new Car
            {
                name = "Tesla Model S",
                shortDesc = "Быстрый автомобиль",
                longDesc = "Красивый, быстрый автомобиль компании Tesla",
                img = "",
                price = 45000,
                isFavourite = true,
                available = true,
                Category = _categoryCars.AllCategories.First()
            },

            new Car
            {
                name = "Ford Fiesta",
                shortDesc = "Тихий и спокойный",
                longDesc = "Удобный автомобиль для городской жизни",
                img = "",
                price = 11000,
                isFavourite = false,
                available = true,
                Category = _categoryCars.AllCategories.Last()

            }

        };

    public IEnumerable<Car> getFavCars { get; set; }
    public Car getObjectCar(int carId)
    {
        throw new NotImplementedException();
    }

    public Car GetObjectCar (int carId)
    {
        throw new NotImplementedException();
    }
}
