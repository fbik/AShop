using AShop.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace AShop.Data;

public class AppDBContent : DbContext
{
   public AppDBContent(DbContextOptions<AppDBContent> options) : base(options)
   {
      
   }

   public DbSet<Car> Car { get; set; }
   public DbSet<Category> Category { get; set; }
   public DbSet<AShopCartItemOne> AShopCartItem2 { get; set; }

   public DbSet<Order> Order2 { get; set; }
   
   public DbSet<OrderDetail> OrderDetails { get; set; }
}

