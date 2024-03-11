using IpPlanner.DataBase.Auth;
using IpPlanner.Design.Buttons;
using IpPlanner.Design.Colors;
using IpPlanner.Design.Entries;
using IpPlanner.Design.TextWidgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpPlanner.Screens.Layouts
{
    public class LoginLayout
    {
        public static StackLayout CreateLayout()
        {
            Entry emailEntry = EntryCustom.CreateNewEntry(textInPlaceholder: "Введи свой Email", isEmail: true);
            Entry passwordEntry = EntryCustom.CreateNewEntry(textInPlaceholder: "Введи свой пароль", isPassword: true);

            Frame frame = EntryFrame.GetFrameForEntry(emailEntry);
            Frame framePass = EntryFrame.GetFrameForEntry(passwordEntry);

            Button signInButton = new CustomButton(text: "Войти", state: ButtonState.Primary);
            signInButton.Clicked += (sender, e) => SignInButton_Clicked(sender, e);

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

                // Вызываем метод SignIn из класса AuthInDataBase
                string result = await AuthInDataBase.SignIn(email, password);

                if (result == "ok")
                {
                    // Переходим на главную страницу (AppShell)
                    //await Navigation.PushAsync(new AppShell());
                }
            }
        }
    }
}
