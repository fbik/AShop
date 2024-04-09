using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace AShop.Data.Models;

public class Order
{
    [BindNever]
    public int id { get; set; }
    
    [Display(Name = "Введите имя")]
    [StringLength(5)]
    [Required(ErrorMessage = "Длина имени не менее 5 символов")]
    public  string name { get; set; }
    
    [Display(Name = "Введите Фамилию")]
    [StringLength(5)]
    [Required(ErrorMessage = "Длина фамилии не менее 5 символов")]
    public string surname { get; set; }
    
    [Display(Name = "Введите адрес")]
    [StringLength(20)]
    [Required(ErrorMessage = "Длина адреса не менее 20 символов")]
    public string adress { get; set; }
    
    [Display(Name = "Введите телефон")]
    [StringLength(11)]
    [DataType(DataType.PhoneNumber)]
    [Required(ErrorMessage = "Длина номера не менее 11 символов")]
    public int phone { get; set; }
    
    [Display(Name = "Email")]
    [DataType(DataType.EmailAddress)]
    [StringLength(5)]
    [Required(ErrorMessage = "Длина почты не менее 5 символов")]
    public string email { get; set; }
    
    [BindNever]
    [ScaffoldColumn(false)]
    public DateTime orderTime { get; set; }
    
    [BindNever]
    public List<OrderDetail> OrderDetails { get; set; }
}