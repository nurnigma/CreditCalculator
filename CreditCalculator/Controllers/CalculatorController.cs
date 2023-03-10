using CreditCalculator.Models;
using CreditCalculator.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace CreditCalculator.Controllers
{
    public class CalculatorController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(CreditTerms creditTerms)
        {
            if (ModelState.IsValid) // проверка на стороне сервера 
            {
                var res = LoanCalculator.Calculate(creditTerms);

                return View("Payment", res);
            }
            return View();
        }

    }
}
