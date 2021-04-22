using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data
{
    public class DBObjects
    {
        public static void Initial(AppDBContent content)
        {
            


            if (!content.Categories.Any())
            {
                content.Categories.AddRange(Categories.Select(c => c.Value));
            }

            if (!content.Cars.Any())
            {
                content.AddRange
                    (
                        new Car
                        {
                            Name = "Tesla Model X",
                            IsAvailable = true,
                            IsFavourite = true,
                            ShortDescription = "Автомобиль Tesla",
                            LongDescription = "",
                            Price = 75000,
                            Img = "https://lh3.googleusercontent.com/proxy/ysqXg9L7ECQn8geAGzLwAf-8dvIqgupgncZOvHzQqbR3Aj4Ar6x7Tro8eNOxZs4_aRDFsNHubchH58XOzIuup_Z1tg",
                            Category = Categories["Электромобиль"]   //content.Categories.AllCategories.First(e => e.Name == "Электромобиль")
                        },

                    //new Car { Name="Tesla Model X", IsAvailable = true, CategoryId = 0, IsFavourite = true, ShortDescription = "Автомобиль Tesla", LongDescription = "", Price = 75000, Img="", Category = carsCategory.AllCategories.First() },

                    new Car
                    {
                        Name = "BMW 5",
                        IsAvailable = true,
                        IsFavourite = false,
                        ShortDescription = "Автомобиль BMW",
                        LongDescription = "",
                        Price = 100000,
                        Img = "https://lh3.googleusercontent.com/proxy/1UZtrRbSGK8afRt2qJHn8cDe5d84y7kbmWFe3LOothQ9Rur3_XFRVTrE7tjuhA1m8id_qGBap3ZOa2dZ9mdju43Mhg",
                        Category = Categories["Классичсекий автомобиль"]  
                    },

                    new Car
                    {
                        Name = "Honda Accord Hybrid 2017",
                        IsAvailable = false,
                        IsFavourite = true,
                        ShortDescription = "Автомобиль Honda",
                        LongDescription = "",
                        Price = 50000,
                        Img = "https://fastmb.ru/uploads/posts/2017-11/1510869719_1.jpg",
                        Category = Categories["Гибрид"]  
                    },

                    new Car
                    {
                        Name = "Honda Jazz",
                        IsAvailable = false,
                        IsFavourite = true,
                        ShortDescription = "Автомобиль Honda",
                        LongDescription = "",
                        Price = 50000,
                        Img = "https://i.infocar.ua/i/12/5431/1400x936.jpg",
                        Category = Categories["Классичсекий автомобиль"]
                    }

                    )  ;
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
                        new Category { Name="Электромобиль", Description="Автомобиль с электро двигателем и батареями. Не имеет вредных выбросов."},
                        new Category { Name="Классичсекий автомобиль", Description="Автомобиль с двигателм внутреннего сгорания."},
                        new Category { Name="Гибрид", Description="Автомобиль который имеет и двигатель внутреннего сгорания и электро."}
                    };

                    category = new Dictionary<string, Category>();

                    foreach (var item in list)
                    {
                        category.Add(item.Name, item);
                    }

                }


                return category;

            }
        }
        

    }
}
