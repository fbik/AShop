using AShop.Data.Interfaces;
using AShop.Data.Models;
using AShop.Views.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AShop.Controllers;

public class CarsController : Controller
{
    private readonly IAllCars _allCars;
    private readonly ICarsCategory _allCategories;

    public CarsController(IAllCars allCars, ICarsCategory iCarsCat)
    {
        _allCars = allCars;
        _allCategories = iCarsCat;
    }
    
    [Route("Cars/List")]
    [Route("Cars/List/{category}")]
    public ViewResult List(string category)
    {
        string _category = category;
        IEnumerable<Car> cars = null;
        string carrCategory = "";
        if (string.IsNullOrEmpty(category))
        {
            cars = _allCars.Cars.OrderBy(i => i.id);
        }
        else
        {
            if (string.Equals("electro", category, StringComparison.OrdinalIgnoreCase))
            {
                cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Электромобили")).OrderBy(i => i.id);
                carrCategory = "Электромобили";
            } else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
            {
                cars = _allCars.Cars.Where(i => i.Category.categoryName.Equals("Классические автомобили"))
                    .OrderBy(i => i.id);
                carrCategory = "Класические автомобили";
            }
            
            carrCategory = _category;
        }

        var carObj = new CarsListViewModel
        {
            allCars = cars,
            currCategory = carrCategory
        };
        
        ViewBag.Title = "Страница с автомобилями";
       
        return View(carObj);
    }
}