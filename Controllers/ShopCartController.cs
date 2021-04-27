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
    public class ShopCartController : Controller
    {
        private readonly IAllCars carRepository;
        private readonly ShopCart shopCart;

        public ShopCartController(IAllCars carRepository, ShopCart shopCart)
        {
            this.carRepository = carRepository;
            this.shopCart = shopCart;
        }

        public ViewResult Index()
        {
            var items = shopCart.getShopItems();
            shopCart.ListShopItems = items;

            var obj = new ShopCartViewModel
            {
                ShopCart = shopCart
            };

            return View(obj);
        }


        public RedirectToActionResult addToCart(int id)
        {
            var item = carRepository.Cars.FirstOrDefault(e => e.Id == id);
            if (item != null)
            {
                shopCart.AddToCart(item);
            }

            return RedirectToAction("Index");
        }
    }
}
