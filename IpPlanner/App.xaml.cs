
using IpPlanner.Screens.UserScreen;

namespace IpPlanner
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();



            /*var shell = new Shell();

            shell.Items.Add(new Tab()
            {
                //FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                Title = "Page One",
                Items =
                {
                    new ShellContent() { Content = new RegistrationPage() }
                }
            });

            shell.Items.Add(new Tab()
            {
                FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                Title = "Page Two",
                FlyoutIcon = "Icons/user-solid.svg",
                
                Items =
                {
                    new ShellContent() { Content = new UserScreen() }
                }
            });

            shell.Items.Add(new Tab()
            {
                FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                Title = "Page Three",
                Items =
                {
                    new ShellContent() { Content = new UserScreen() }
                }
            });



            MainPage = shell;*/

            //MainPage = new UserScreen();
            //MainPage = new RegistrationPage();

            MainPage = new AppShell();
        }
    }
}
