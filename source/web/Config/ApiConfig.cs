 

namespace web.Config
{
    public class ApiConfig 
    {
        public string BaseUrl { get; set; }
        public string TriviaUrl { get; set; }

        public override string ToString()
        {
            return $"BaseUrl: {BaseUrl}. TriviaUrl: {TriviaUrl}.";
        }
    }
}
