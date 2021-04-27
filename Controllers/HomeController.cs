using Microsoft.AspNetCore.Mvc;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAllCars carRepository;
        

        public HomeController(IAllCars carRepository)
        {
            this.carRepository = carRepository;
           
        }


        public ViewResult Index()
        {
            var homeCars = new HomeViewModel()
            {
                FavCars = carRepository.getFavCars
            };
            

            return View(homeCars);
        }



    }

}
