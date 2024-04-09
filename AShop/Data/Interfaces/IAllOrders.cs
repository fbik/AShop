using AShop.Data.Models;

namespace AShop.Data.Interfaces;

public interface IAllOrders
{
    void createOrder(Order order);
}