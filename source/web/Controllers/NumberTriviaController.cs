using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using web.Services;

namespace web.Controllers 
{
    public class NumberTriviaController : Controller
    {
        private readonly INumberTriviaService _numberTriviaService;

        public NumberTriviaController(INumberTriviaService numberTriviaService)
        {
            _numberTriviaService = numberTriviaService;
        }

        public async Task<IActionResult> Index()
        {
            var numberTrivia = await _numberTriviaService.GetNumberAsync(666);
            ViewData["Message"] = $"From microservice: {numberTrivia?.Text ?? "null value"}";

            return View();
        }
    }
}