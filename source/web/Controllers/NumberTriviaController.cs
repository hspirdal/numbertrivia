using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Mvc;
using api.Dto;

namespace web.Controllers 
{
    public class NumberTriviaController : Controller
    {
        private readonly string _baseUrl;

        public NumberTriviaController()
        {
            _baseUrl = "http://0.0.0.0:8080/";
        }

        public async Task<IActionResult> Index()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{_baseUrl}api/trivia/{666}");
            var triviaResult = await response.Content.ReadAsStringAsync();
            var triviaResponse = JsonConvert.DeserializeObject<TriviaResponse>(triviaResult);


            ViewData["Message"] = triviaResponse.Text;

            return View();
        }
    }

}