using AShop.Data.Interfaces;
using AShop.Views.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AShop.Controllers;


public class HomeController : Controller
{
    private IAllCars _allCars;

    public HomeController(IAllCars allCars)
    {
        _allCars = allCars;
    }
    
    [Route("Home/Index2")]
    public ViewResult Index2()
    {
        var homeCars = new HomeViewModel
        {
          favCars = _allCars.getFavCars
        };
        // ReSharper disable once Mvc.ViewNotResolved
        return View(homeCars);
    }
}