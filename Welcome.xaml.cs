using System;

namespace Wordle
{

    //code behind on xaml page that displays a welcome message to the player
    public partial class WelcomePage : ContentPage
    {
        public WelcomePage()
        {
            InitializeComponent();
        }

        private async void OnStartGameClicked(object sender, EventArgs e)
        {
            // navigate to the Wordle game page
            await Navigation.PushAsync(new MainPage());
        }
    }
}
