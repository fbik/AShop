using AShop.Data.Models;

namespace AShop.Views.ViewModels;

public class CarsListViewModel
{
    public IEnumerable<Car>? allCars { get; set; }
    
    public string currCategory { get; set; }
}