using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using api.Dto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class TriviaController : Controller
    {
        // GET api/values
        [HttpGet("{number}")]
        public async Task<TriviaResponse> GetTriviaAsync(int number)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"http://numbersapi.com/{number}?json");
            var triviaResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TriviaResponse>(triviaResult);
        }
    }
}
