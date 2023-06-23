using AShop.Data.Models;

namespace AShop.Data.Interfaces;

public interface ICarsCategory
{
    IEnumerable<Category> AllCategories { get; }
}