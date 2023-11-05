using UIChallenge.Views;

namespace UIChallenge
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

        MainPage = new NavigationPage(new StartPage());
        }
    }
}