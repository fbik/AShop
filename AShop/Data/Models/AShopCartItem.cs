using AShop.Data.Models;

namespace AShop.Data.Models;

public class AShopCartItemOne
{
    public int id { get; set; }
    public Car CarOb { get; set; }
    public int Price { get; set; }
    
    public string AShopCartId { get; set; }
}