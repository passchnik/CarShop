using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
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

        public Microsoft.AspNetCore.Mvc.ViewResult List()
        {
            ViewBag.Title = "Страница с автомобилями";

            CarsListViewModel carsListViewModel = new CarsListViewModel();

            carsListViewModel.AllCars = _allCars.Cars;
            carsListViewModel.CurrentCategory = "Автомобили";

            return View(carsListViewModel);
        }


    }
}
