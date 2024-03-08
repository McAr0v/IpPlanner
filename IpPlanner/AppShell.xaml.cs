using Firebase.Auth;
using IpPlanner.Design.Colors;
using IpPlanner.Screens.UserScreen;

namespace IpPlanner
{
    public partial class AppShell : Shell
    {
        CustomUser? user;
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute("profile", typeof(ProfileScreen));

            // Добавляем вкладки
            AddTabBar();

            void AddTabBar()
            {
                // Создаем стиль для вкладок
                var tabStyle = new Style(typeof(Tab))
                {
                    ApplyToDerivedTypes = true,
                    Setters =
                {
                    new Setter() { Property = TabBarBackgroundColorProperty, Value = CustomColors.Black }, // Устанавливаем цвет текста вкладок
                    new Setter() { Property = TabBarTitleColorProperty, Value = CustomColors.YellowDark }, // Устанавливаем размер шрифта вкладок
                    new Setter() { Property = TabBarUnselectedColorProperty, Value = CustomColors.GreyLight }, // Устанавливаем размер шрифта вкладок
                    new Setter() { Property = TabBarForegroundColorProperty, Value = CustomColors.YellowDark }, // Устанавливаем размер шрифта вкладок
                }
                };

                // Применяем стиль вкладок
                Resources.Add(tabStyle);
                // Создаем вкладки и добавляем их в шелл
                Items.Add(new Tab()
                {
                    Route = "//profile",
                    FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                    Title = "Заказы",
                    Icon = "file_invoice_dollar_solid.png",
                    Items =
                {
                    new ShellContent() { Content = new RegistrationPage() }
                }
                });

                Items.Add(new Tab()
                {
                    FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                    Title = "Задачи",
                    Icon = "list_check_solid.png",
                    Items =
                {
                    new ShellContent() { Content = new UserScreen() }
                }
                });

                Items.Add(new Tab()
                {
                    FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                    Title = "Статистика",
                    Icon = "chart_simple_solid.png",
                    Items =
                {
                    new ShellContent() { Content = new UserScreen() }
                }
                });

                

                Items.Add(new Tab()
                {
                    Route = "//profile2",
                    FlyoutDisplayOptions = FlyoutDisplayOptions.AsMultipleItems,
                    Title = "Профиль",
                    Icon = "user_solid.png",
                    Items =
                {
                    new ShellContent() 
                    { 
                        Content = new ProfileScreen(),
                    }
                }
                });

            }

        }
    }
}
