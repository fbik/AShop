using AShop.Data.Interfaces;
using AShop.Data.Models;
using AShop.Data.Repository;
using AShop.Views.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace AShop.Controllers;


public class AShopCartController : Controller
{
    private readonly IAllCars _carRep;
    private readonly AShopCart _ashopCart;

    public AShopCartController(IAllCars carRep, AShopCart asopCartNew)
    {
        _carRep = carRep; 
        _ashopCart = asopCartNew;
    }

    [Route("AShopCart/Index")]
    public ViewResult Index()
    {
        var items = _ashopCart.GetShopItems();
        _ashopCart.listAShopItemsNew = items;

        var obj = new AShopCartViewModels
        {
            ashopCartMod = _ashopCart
        };

        return View(obj);
    }

    public RedirectToActionResult addToCart(int id)
    {
        var item = _carRep.Cars.FirstOrDefault(i => i.id == id);
        if (item != null)
        {
            _ashopCart.AddToCart(item);
        }

        return RedirectToAction("Index");
    }
}