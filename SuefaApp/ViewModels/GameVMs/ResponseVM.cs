namespace SuefaApp.ViewModels.GameVMs
{
    public class ResponseVM
    {
        public int Result { get; set; }
        public int UserScore { get; set; }
        public int CompScore { get; set; }
        public int HasWon { get; set; }
        public int CompSelected { get; set; }
        public string Message { get; set; }
    }
}
