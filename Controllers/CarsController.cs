using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewModels;

namespace Shop.Controllers
{
    public class CarsController : Controller
    {
        private readonly IAllCars _allCars;

        private readonly ICarsCategory _carsCategory;

        public CarsController(IAllCars allCars, ICarsCategory carsCategory)
        {
            _allCars = allCars;
            _carsCategory = carsCategory;
        }

        [Route("Cars/List")]
        [Route("Cars/List/{category}")]
        public Microsoft.AspNetCore.Mvc.ViewResult List(string category)
        {
            var _category = category;
            IEnumerable<Car> cars = null;
            string currentCategory = "";
            if (string.IsNullOrEmpty(category))
            {
                cars = _allCars.Cars.OrderBy(e => e.Id);
            }
            else
            {
                if (string.Equals("elctro", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(e => e.Category.Name.Equals("Электромобиль")).OrderBy(e => e.Id);
                }
                else if (string.Equals("fuel", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(e => e.Category.Name.Equals("Классичсекий автомобиль")).OrderBy(e => e.Id);
                }
                else if (string.Equals("hybrid", category, StringComparison.OrdinalIgnoreCase))
                {
                    cars = _allCars.Cars.Where(e => e.Category.Name.Equals("Гибрид")).OrderBy(e => e.Id);
                }

                currentCategory = _category;

                
            }

            var carobj = new CarsListViewModel
            {
                AllCars = cars,
                CurrentCategory = currentCategory
            };


            ViewBag.Title = "Страница с автомобилями";

            

            return View(carobj);
        }




    }
}
