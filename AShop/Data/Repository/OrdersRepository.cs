using AShop.Data.Interfaces;
using AShop.Data.Models;

namespace AShop.Data.Repository;

public class OrdersRepository : IAllOrders
{
    private readonly AppDBContent _appDbContent;
    private readonly AShopCart _aShopCart;

    public OrdersRepository(AppDBContent appDbContent, AShopCart aShopCart)
    {
        this._appDbContent = appDbContent;
        this._aShopCart = aShopCart;
    }
    
    public void createOrder(Order order)
    {
      order.orderTime = DateTime.Now;
      _appDbContent.Order2.Add(order);

      var items = _aShopCart.listAShopItemsNew;

      foreach (var el in items)
      {
          var orderDetail = new OrderDetail()
          {
            CarID = el.CarOb.id,
            orderId = order.id,
            price = el.CarOb.price
          };
          _appDbContent.OrderDetails.Add(orderDetail);
      }
      _appDbContent.SaveChanges();
    }
}