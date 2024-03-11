using Firebase.Auth;
using IpPlanner.Design.Colors;
using IpPlanner.Screens.UserScreen;

namespace IpPlanner
{
    public partial class AppShell : Shell
    {

        public AppShell()
        {
            InitializeComponent();


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

                Resources.Add(tabStyle);

            }

        }
    }
}
