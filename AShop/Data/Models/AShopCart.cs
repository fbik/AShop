using Microsoft.EntityFrameworkCore;

namespace AShop.Data.Models;

public class AShopCart
{

    private readonly AppDBContent _appDbContent;

    public AShopCart(AppDBContent appDbContentPer)
    {
        this._appDbContent = appDbContentPer;
    }
    
    public string AShopCartId2 { get; set; }
    
    public List<AShopCartItemOne> listAShopItemsNew { get; set; }

    public static AShopCart GetCart(IServiceProvider services)
    {
        ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
        var context = services.GetService<AppDBContent>();
        string ashopCartIdString = session.GetString("CartId") ?? Guid.NewGuid().ToString();
        
        session.SetString("CartId", ashopCartIdString);

        return new AShopCart(context) { AShopCartId2 = ashopCartIdString };
        
    }

    public void AddToCart(Car car2)
    {
        this._appDbContent.AShopCartItem2.Add(new AShopCartItemOne
        {
           AShopCartId = AShopCartId2,
           CarOb = car2,
           Price = car2.price
        });

        _appDbContent.SaveChanges();
    }

    public List<AShopCartItemOne> GetShopItems()
    {
        return _appDbContent.AShopCartItem2.Where(c => c.AShopCartId == AShopCartId2)
            .Include(s => s.CarOb).ToList();
    }

}