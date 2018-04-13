using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using web.Services;
using web.ViewModels;

namespace web.Controllers 
{
    public class TriviaController : Controller
    {
        private readonly INumberTriviaService _numberTriviaService;

        public TriviaController(INumberTriviaService numberTriviaService)
        {
            _numberTriviaService = numberTriviaService;
        }

         // POST trivia/check
        [HttpPost]
        public async Task<IActionResult> Check(int number)
        {
            var numberTrivia = await _numberTriviaService.GetNumberAsync(number);
            return View(numberTrivia);
        }

        public IActionResult Check()
        {
            return View(new NumberTrivia());
        }
    }
}