using AShop.Data.Models;
using FubuMVC.Core.Urls;

namespace AShop.Data;

public class DBObjects
{
    public static void Initial(AppDBContent content)
    {

        if (!content.Category.Any())
        {
            content.Category.AddRange(Categories.Select(c => c.Value));
        }

        if (!content.Car.Any())
        {
            content.AddRange(
                new Car
                {
                    name = "Tesla Model S",
                    shortDesc = "Быстрый автомобиль",
                    longDesc = "Красивый, быстрый автомобиль компании Tesla",
                    img = "/img/5.jpg",
                    price = 45000,
                    isFavourite = true,
                    available = true,
                    Category = Categories["Электромобили"]
                },

                new Car
                {
                    name = "Ford Fiesta",
                    shortDesc = "Тихий и спокойный",
                    longDesc = "Удобный автомобиль для городской жизни",
                    img = "/img/3.jpg",
                    price = 11000,
                    isFavourite = false,
                    available = true,
                    Category = Categories["Классические автомобили"]

                }

            );
        }

        content.SaveChanges();

    }


    public static Dictionary<string, Category> category;
    public static Dictionary<string, Category> Categories
    {
        get
        {
            if (category == null)
            {
                var list = new Category[]
                {
                    new Category { categoryName = "Электромобили", desc = "Современный вид транспорта" },
                    new Category
                        { categoryName = "Классические автомобили", desc = "Машины с двигателем внутреннего сгорания" }
                };

                category = new Dictionary<string, Category>();
                foreach (Category el in list )
                {
                    category.Add(el.categoryName, el);
                }

            }

            return category;
        }
    }
}