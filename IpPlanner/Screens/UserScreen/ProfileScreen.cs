using IpPlanner.DataBase.Auth;
using IpPlanner.Design.Colors;
using IpPlanner.Design.Layouts;
using IpPlanner.Screens.Layouts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpPlanner.Screens.UserScreen
{
    public class ProfileScreen: ContentPage
    {
       

        private ScrollView scrollView;

        public ProfileScreen()
        {

            //scrollView = StackCustom.CreateLayout();
            scrollView = new ScrollView()
            {
                //Padding = new Thickness(20),
                BackgroundColor = CustomColors.Black
            };

            Content = scrollView;

            UpdateProfile();

        }



        // Метод для обновления информации о пользователе на экране
        private void UpdateProfile()
        {
            CustomUser? user = CustomUser.GetCurrentUser();
            LogInScreen logInScreen = new LogInScreen();

            //scrollView.Children.Clear(); // Очищаем содержимое StackLayout перед добавлением новой информации
            

            if (user != null)
            {
                Label label = new Label
                {
                    Text = $"Имя: {user.FirstName}, Email: {user.Email}, UID: {user.Uid}",
                    TextColor = CustomColors.YellowLight,
                };
                //scrollView.Children.Add(label);
                scrollView.Content = label;
            }
            else
            {
                var loginLayout = LoginLayout.CreateLayout();
                //scrollView.Children.Add(label);
                scrollView.Content = loginLayout;
            }
        }

        /*async void SignInButton_Clicked(object sender, EventArgs e)
        {
            // Вызываем метод SignIn из класса AuthInDataBase
            string result = await AuthInDataBase.SignIn(email, password);

            if (result == "ok")
            {
                // Переходим на главную страницу (AppShell)
                //await Navigation.PushAsync(new AppShell());
            }
        }*/

        protected override void OnAppearing()
        {
            base.OnAppearing();
            UpdateProfile(); // Обновляем профиль каждый раз, когда страница становится видимой
        }
    }
}
