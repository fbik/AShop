namespace AShop.Data.Models;

public class Order
{
    public int id { get; set; }
    
    public  string name { get; set; }
    
    public string surname { get; set; }
    
    public string adress { get; set; }
    
    public int phone { get; set; }
    
    public string email { get; set; }
    
    public DateTime orderTime { get; set; }
    
    public List<OrderDetail> OrderDetails { get; set; }
}