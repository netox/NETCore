using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsCore;
using CarsData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Cars.Pages.Sales
{
    public class DetailModel : PageModel
    {
        private readonly ICarsData carsData;

        public Car Car { get; set; }

        public DetailModel(ICarsData carsData)
        {
            this.carsData = carsData;
        }

        public IActionResult OnGet(int carId)
        {
            /*Car = new Car();
            Car.Id = carId;*/
            Car = carsData.GetById(carId);
            if(Car == null)
            {
                return RedirectToPage("./NotFound");
            }
            return Page();
        }
    }
}
