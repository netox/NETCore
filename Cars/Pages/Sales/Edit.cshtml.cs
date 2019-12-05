using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarsCore;
using CarsData;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cars.Pages.Sales
{
    public class EditModel : PageModel
    {

        [BindProperty]
        public Car Car { get; set; }
        public IEnumerable<SelectListItem> Brands { get; set; }
        public IEnumerable<SelectListItem> Colors { get; set; }

        private readonly ICarsData carsData;
        private readonly IHtmlHelper htmlHelper;

        public EditModel(ICarsData carsData,IHtmlHelper htmlHelper)
        {
            this.carsData = carsData;
            this.htmlHelper = htmlHelper;
        }
        
        public IActionResult OnGet(int? carId)
        {
            Brands = htmlHelper.GetEnumSelectList<Brands>();
            Colors = htmlHelper.GetEnumSelectList<Colors>();

            if (carId.HasValue)
                Car = carsData.GetById(carId.Value);
            else
                Car = new Car();

            if (Car == null)
            {
                return RedirectToPage("./NotFound");
            }

            return Page();
        }

        public IActionResult OnPost()
        {
            Brands = htmlHelper.GetEnumSelectList<Brands>();
            Colors = htmlHelper.GetEnumSelectList<Colors>();
            _ = (Car.Id > 0) ? carsData.Update(Car) : carsData.Add(Car);
            carsData.commit();
            return Page();
        }
    }
}
