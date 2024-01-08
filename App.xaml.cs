using System;

namespace Wordle
{

    //ensures that the starting page is the welcome page
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new WelcomePage());
        }

       
    }
}
