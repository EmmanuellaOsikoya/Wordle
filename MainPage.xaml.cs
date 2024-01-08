namespace Wordle
{
    public partial class MainPage : ContentPage
    {
        private WordleGame wordleGame;

        public MainPage()
        {
            InitializeComponent();
            wordleGame = new WordleGame();
            BindingContext = wordleGame;
        }

        private void OnCheckClicked(object sender, EventArgs e)
        {
            string guess = GuessEntry.Text;
            wordleGame.CheckGuess(guess);
            Result.Text = wordleGame.GetFeedback();
        }
    }
}