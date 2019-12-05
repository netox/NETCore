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
    public class ListModel : PageModel
    {
        private readonly ICarsData carsData;
        public IEnumerable<Car> Cars { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }
        public ListModel(ICarsData carsData)
        {
            this.carsData = carsData;
        }
        public void OnGet(string searchTerm)
        {
            Cars = carsData.getCarsByName(searchTerm);
        }
    }
}