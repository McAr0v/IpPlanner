using Android.App;
using Firebase.Auth;
using IpPlanner.DataBase.Auth;
using IpPlanner.Design.Buttons;
using IpPlanner.Design.Colors;
using IpPlanner.Design.Entries;
using IpPlanner.Design.TextWidgets;
using IpPlanner.Interfaces.AlertDialogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpPlanner.Screens.UserScreen
{
    public class LogInScreen: ContentPage
    {

        public LogInScreen()
        {
            Content = LogInLayout();
        }
        
        private StackLayout LogInLayout()
        {

            Entry emailEntry = EntryCustom.CreateNewEntry(textInPlaceholder: "Введи свой Email", isEmail: true);
            Entry passwordEntry = EntryCustom.CreateNewEntry(textInPlaceholder: "Введи свой пароль", isPassword: true);

            Frame frame = EntryFrame.GetFrameForEntry(emailEntry);
            Frame framePass = EntryFrame.GetFrameForEntry(passwordEntry);

            Button signInButton = new CustomButton(text: "Войти", clickedHandler: SignInButton_Clicked, state: ButtonState.Primary);

            return new StackLayout
            {
                BackgroundColor = CustomColors.Black,
                Padding = new Thickness(20),
                Children =
                {
                    TextWidget.GetTextWidget(
                        text: "Войти в аккаунт",
                        color: CustomColors.YellowLight,
                        state: TextState.HeadlineBig
                        ),
                    TextWidget.GetTextWidget(
                        text: "Введи Email и пароль чтобы войти в свой личный кабинет",
                        color: CustomColors.GreyLight,
                        state: TextState.DescMedium
                        ),
                    new BoxView { HeightRequest = 30, BackgroundColor = CustomColors.Black }, // Пустое пространство в 20 пикселей
                    //emailEntry,
                    frame,
                    new BoxView { HeightRequest = 10, BackgroundColor = CustomColors.Black }, // Пустое пространство в 20 пикселей
                    framePass,
                    new BoxView { HeightRequest = 20, BackgroundColor = CustomColors.Black }, // Пустое пространство в 20 пикселей
                    signInButton,
                }
            };

            async void SignInButton_Clicked(object sender, EventArgs e)
            {
                var email = emailEntry.Text;
                var password = passwordEntry.Text;

                // Вызываем метод RegisterUser из класса AuthInDataBase
                string result = await AuthInDataBase.SignIn(email, password);

                if (result == "Ok") 
                {
                    var app = Microsoft.Maui.Controls.Application.Current as App;
                    app.NavigateToMainPage();
                }

            }

        }
    }
}
