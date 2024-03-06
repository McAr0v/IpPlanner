
using IpPlanner.Screens.UserScreen;

namespace IpPlanner
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            

            MainPage = new UserScreen();
            //MainPage = new RegistrationPage();
        }
    }
}
