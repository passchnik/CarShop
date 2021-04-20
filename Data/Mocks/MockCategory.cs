using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Mocks
{
    public class MockCategory : ICarsCategory
    {
        public IEnumerable<Category> AllCategories 
        {
            get
            {
                return new List<Category>
                {
                    new Category { Name="Электромобиль", Description="Автомобиль с электро двигателем и батареями. Не имеет вредных выбросов."},
                    new Category { Name="Классичсекий автомобиль", Description="Автомобиль с двигателм внутреннего сгорания."},
                    new Category { Name="Гибрид", Description="Автомобиль который имеет и двигатель внутреннего сгорания и электро."}
                };
            }

        }
    }
}
