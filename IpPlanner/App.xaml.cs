
using IpPlanner.Screens.UserScreen;

namespace IpPlanner
{
    public partial class App : Application
    {
        //CustomUser? user;
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
            
        }

    }
}
