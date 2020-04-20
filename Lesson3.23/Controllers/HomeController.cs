using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Lesson3._23.Models;

namespace Lesson3._23.Controllers
{
    public class HomeController : Controller
    {
        CarsDb db = new CarsDb("Data Source=.\\sqlexpress;Initial Catalog=Cars;Integrated Security=True");
        public IActionResult Index(string sort)
        {
            IEnumerable<Car> cars = db.GetCars();
            if (sort == "asc")
            {
                cars = cars.OrderBy(c => c.Year);
            }
            else if (sort == "desc")
            {
                cars = cars.OrderByDescending(c => c.Year);
            }
            SortCarsViewModel vm = new SortCarsViewModel();
            vm.Cars = cars;
            vm.SortAsc = sort == "asc";
            return View(vm);
        }
        public IActionResult AddCar()
        {
            return View();
        }
        public IActionResult SaveCar(Car car)
        {
            db.AddCar(car);
            return Redirect("/home/index");
        }
    }
}
