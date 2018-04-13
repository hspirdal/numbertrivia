namespace web.ViewModels 
{
    public class NumberTrivia
    {
        public NumberTrivia()
        {
            Text = string.Empty;
            Type = "Trivia";
        }

        public string Text { get; set; }
        public int Number { get; set; }
        public bool Found { get; set; }
        public string Type { get; set; }
    }
}