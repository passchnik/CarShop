using Shop.Data.Interfaces;
using Shop.Data.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Data.Repository
{
    public class CarRepository : IAllCars
    {
        private readonly AppDBContent appDBContent;

        public CarRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Car> Cars => appDBContent.Cars.Include( e => e.Category);

        public IEnumerable<Car> getFavCars => appDBContent.Cars.Where( e => e.IsFavourite == true).Include(e => e.Category);

        public Car GetCar(Car carId) => appDBContent.Cars.FirstOrDefault(e => e.Id == carId.Id);
        
        
    }
}
