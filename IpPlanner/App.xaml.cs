
using IpPlanner.Screens.UserScreen;

namespace IpPlanner
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();

            CustomUser? user = CustomUser.GetCurrentUser();

            if (user != null) 
            {
                MainPage = new AppShell();
            } 
            else 
            {
                MainPage = new LogInScreen();
            }
        }

        public void NavigateToMainPage()
        {
            MainPage = new AppShell(); // Установка AppShell как главной страницы
        }

        public void NavigateToProfilePage()
        {
            MainPage = new AppShell(); // Установка AppShell как главной страницы
                                       // Переход на страницу профиля
            Shell.Current.GoToAsync("//profile");
        }

    }
}
