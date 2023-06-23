using AShop.Data.Interfaces;
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

    [NonAction]
    public ViewResult List()
    {
        ViewBag.Title = "Страница с автомобилями";
        CarsListViewModel obj = new CarsListViewModel
        {
            allCars = _allCars.Cars,
            currCategory = "Автомобили"
        };
        return View(obj);
    }
}