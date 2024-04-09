using AShop.Data.Interfaces;
using AShop.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace AShop.Controllers;

public class OrderController : Controller
{
    private readonly IAllOrders _allOrders;
    private readonly AShopCart _ashopCart;

    public OrderController(IAllOrders allOrders, AShopCart ashopCart)
    {
        this._allOrders = allOrders;
        this._ashopCart = ashopCart;
    }

    public IActionResult Checkout()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult Checkout(Order order)
    {

        _ashopCart.listAShopItemsNew = _ashopCart.GetShopItems();

        if (_ashopCart.listAShopItemsNew.Count == 0) 
        {
            ModelState.AddModelError("", "Ваша корзина пуста");
        }

        if (ModelState.IsValid)
        {
            _allOrders.createOrder(order);
            return RedirectToAction("Complete");
        }
        return View();
    }

    public IActionResult Complete()
    {
        ViewBag.Message = "Заказ обработан";
        // ReSharper disable once Mvc.ViewNotResolved
        return View();
    }
    
}