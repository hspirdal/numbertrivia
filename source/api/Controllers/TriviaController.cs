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
            if(number == 666)
            {
                return new TriviaResponse { Text = "The number of the beast.", Number = 666, Found = true, Type = "hardcoded trivia" };
            }
            if(number == 1337)
            {
                return new TriviaResponse { Text = "The number of the leet.", Number = 1337, Found = true, Type = "hardcoded trivia" };
            }

            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"http://numbersapi.com/{number}?json");
            var triviaResult = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<TriviaResponse>(triviaResult);
        }
    }
}
