using AShop.Data.Models;

namespace AShop.Views.ViewModels;

public class HomeViewModel
{
    public  IEnumerable<Car> favCars { get; set; }
}