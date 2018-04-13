using System;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using web.Config;
using web.ViewModels;

namespace web.Services
{
    public interface INumberTriviaService
    {
        Task<NumberTrivia> GetNumberAsync(int number);
    }    

    public class NumberTriviaService : INumberTriviaService
    {
        ApiConfig _apiConfig;

        public NumberTriviaService(ApiConfig apiConfig)
        {
            _apiConfig = apiConfig;
        }

        public async Task<NumberTrivia> GetNumberAsync(int number)
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync($"{_apiConfig.BaseUrl}/{_apiConfig.NumberTriviaApiUrl}/{number}");
            var triviaResult = await response.Content.ReadAsStringAsync();
            var numberTrivia = JsonConvert.DeserializeObject<NumberTrivia>(triviaResult);
            return numberTrivia;
        }
    }
}