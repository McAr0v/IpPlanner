using IpPlanner.DataBase.Auth;
using IpPlanner.Design.Buttons;
using IpPlanner.Design.Colors;
using IpPlanner.Design.Entries;
using IpPlanner.Design.TextWidgets;
using System;
using System.Threading.Tasks;

namespace IpPlanner.Screens.ProfileScreens
{
    public class ProfileScreens : ContentPage
    {
        private CustomUser user;
        private Entry emailEntry = EntryCustom.CreateNewEntry(textInPlaceholder: "Введите ваш Email", isEmail: true);
        private Entry passwordEntry = EntryCustom.CreateNewEntry(textInPlaceholder: "Введите ваш пароль", isPassword: true);
        private CustomButton signInButton;
        private CustomButton registerButton;

        public ProfileScreens()
        {
            emailEntry = EntryCustom.CreateNewEntry(textInPlaceholder: "Введите ваш Email", isEmail: true);
            passwordEntry = EntryCustom.CreateNewEntry(textInPlaceholder: "Введите ваш пароль", isPassword: true);

            // Не устанавливаем содержимое здесь, так как пользователь может быть не загружен сразу
            // Запускаем обновление при появлении страницы
            this.Appearing += ProfileScreens_Appearing;
        }

        private async void ProfileScreens_Appearing(object sender, EventArgs e)
        {
            user = CustomUser.GetCurrentUser();

            if (user != null)
            {
                Content = GetUserInfoLayout();
            }
            else
            {
                Content = GetSignInLayout();
            }
        }

        private StackLayout GetUserInfoLayout()
        {
            return new StackLayout
            {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                Children =
            {
                new Label
                {
                    Text = $"Email: {user.Email}, UID: {user.Uid}",
                    FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                    HorizontalOptions = LayoutOptions.Center
                },
                new Button
                {
                    Text = "Выйти",
                    Command = new Command(async () =>
                    {
                        AuthInDataBase.SignOut();
                        await DisplayAlert("Success", "Вы успешно вышли!", "OK");
                        Content = GetSignInLayout();
                    }),
                    HorizontalOptions = LayoutOptions.Center
                }
            }
            };
        }

        private StackLayout GetSignInLayout()
        {
            signInButton = new CustomButton(text: "Войти", state: ButtonState.Primary);
            signInButton.Clicked += SignInButton_Clicked;

            registerButton = new CustomButton(text: "Зарегистрироваться", state: ButtonState.Primary);
            registerButton.Clicked += RegisterButton_Clicked;

            emailEntry = EntryCustom.CreateNewEntry(textInPlaceholder: "Введите ваш Email", isEmail: true);
            passwordEntry = EntryCustom.CreateNewEntry(textInPlaceholder: "Введите ваш пароль", isPassword: true);

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
                    text: "Введите Email и пароль для входа",
                    color: CustomColors.GreyLight,
                    state: TextState.DescMedium
                ),
                new BoxView { HeightRequest = 30, BackgroundColor = CustomColors.Black },
                emailEntry,
                new BoxView { HeightRequest = 10, BackgroundColor = CustomColors.Black },
                passwordEntry,
                new BoxView { HeightRequest = 20, BackgroundColor = CustomColors.Black },
                signInButton,
                new BoxView { HeightRequest = 10, BackgroundColor = CustomColors.Black },
                registerButton
            }
            };
        }

        private async void SignInButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(emailEntry.Text) || string.IsNullOrWhiteSpace(passwordEntry.Text))
            {
                await DisplayAlert("Ошибка", "Пожалуйста, введите Email и пароль.", "OK");
                return;
            }

            string email = emailEntry.Text;
            string password = passwordEntry.Text;
            string result = await AuthInDataBase.SignIn(email, password);

            if (result == "ok")
            {
                // Обновляем пользователя после успешного входа
                user = CustomUser.GetCurrentUser();
                Content = GetUserInfoLayout();
            }
            else
            {
                await DisplayAlert("Ошибка", "Вход не выполнен. Проверьте введенные данные и попробуйте снова.", "OK");
            }
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            // Если нужно, можно реализовать переход на страницу регистрации
            //await Navigation.PushAsync(new RegisterScreen());
        }
    }
}
