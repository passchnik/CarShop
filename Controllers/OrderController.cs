﻿using Microsoft.AspNetCore.Mvc;
using Shop.Data;
using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    public class OrderController : Controller
    {
        private readonly IAllOrders allOrders;
        private readonly ShopCart shopCart;

        public OrderController(IAllOrders allOrders, ShopCart shopCart)
        {
            this.shopCart = shopCart;
            this.allOrders = allOrders;
        }

        public IActionResult Checkout()
        {
            return View();

        }

        [HttpPost]
        public IActionResult Checkout(Order order) 
        {
            shopCart.ListShopItems = shopCart.getShopItems();

            if (shopCart.ListShopItems.Count == 0)
            {
                ModelState.AddModelError("", "Корзина пуста!");
            }

            if (ModelState.IsValid)
            {
                allOrders.CreateOrder(order);
                return RedirectToAction("Complete");
            }

            return View(order);
        }

        public IActionResult Complete()
        {
            ViewBag.Message = "Заказ успешно обработан";
            return View();
        }

    }
}
