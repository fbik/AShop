using AShop.Data.Models;
using Microsoft.EntityFrameworkCore;


namespace AShop.Data;

public class AppDBContent : DbContext
{
   static readonly string connectionString = "Server=localhost,3306\\MSSQLLocalDB;DataBase=mysql; User=Irina;Password=:.%L9pJPd=%C555l_w9#YpTEPcS97m7+;";
   protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
   {
      optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
   }

   public DbSet<Car> Car { get; set; }
   public DbSet<Category> Category { get; set; }
   public DbSet<AShopCartItemOne> AShopCartItem2 { get; set; }

   public DbSet<Order> Order2 { get; set; }
   
   public DbSet<OrderDetail> OrderDetails { get; set; }
}

