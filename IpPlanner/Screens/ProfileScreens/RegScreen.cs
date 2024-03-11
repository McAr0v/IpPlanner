using IpPlanner.DataBase.Auth;
using IpPlanner.DataBase.DbManager;
using IpPlanner.Design.Buttons;
using IpPlanner.Design.Colors;
using IpPlanner.Design.Entries;
using IpPlanner.Design.TextWidgets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.Maui.ApplicationModel.Permissions;

namespace IpPlanner.Screens.ProfileScreens
{
    public class RegScreen : ContentPage
    {
        private Entry emailEntry = EntryCustom.CreateNewEntry(textInPlaceholder: "Введите ваш Email (обязательно)", isEmail: true);
        private Entry passwordEntry = EntryCustom.CreateNewEntry(textInPlaceholder: "Введите ваш пароль (обязательно)", isPassword: true);

        private Entry nameEntry = EntryCustom.CreateNewEntry(textInPlaceholder: "Ваше имя (обязательно)");
        private Entry lastNameEntry = EntryCustom.CreateNewEntry(textInPlaceholder: "Ваша фамилия (не обязательно)");
        private Entry phoneEntry = EntryCustom.CreateNewEntry(textInPlaceholder: "Ваш телефон (не обязательно)", isPhone: true);
        private Entry orgNameEntry = EntryCustom.CreateNewEntry(textInPlaceholder: "Название организации (не обязательно)");

        public RegScreen()
        {
            BackgroundColor = CustomColors.Black;
            Padding = new Thickness(20);

            CustomButton go = new CustomButton("Зарегистрироваться", ButtonState.Primary);
            CustomButton goBack = new CustomButton("Вернуться назад", ButtonState.Secondary);

            goBack.Clicked += Go_Clicked;
            go.Clicked += Go_Reg;

            Content = new ScrollView
            {
                Content = new StackLayout
                {

                    Children =
                {

                    TextWidget.GetTextWidget(
                        text: "Регистрация",
                        color: CustomColors.YellowLight,
                        state: TextState.HeadlineBig
                    ),

                    TextWidget.GetTextWidget(
                        text: "Заполните данные для регистрации",
                        color: CustomColors.GreyLight,
                        state: TextState.DescMedium
                    ),
                    new BoxView { HeightRequest = 30, BackgroundColor = CustomColors.Black },

                    TextWidget.GetTextWidget(
                        text: "Основные данные:",
                        color: CustomColors.YellowLight,
                        state: TextState.HeadlineMedium
                    ),

                    new BoxView { HeightRequest = 10, BackgroundColor = CustomColors.Black },

                    new StackLayout
                    {
                        Padding = new Thickness(10),
                        BackgroundColor = CustomColors.BlackLight,
                        Children =
                        {
                        nameEntry,
                        }
                    },

                    new BoxView { HeightRequest = 10, BackgroundColor = CustomColors.Black },

                    new StackLayout
                    {
                        Padding = new Thickness(10),
                        BackgroundColor = CustomColors.BlackLight,
                        Children =
                        {
                        emailEntry,
                        }
                    },

                    new BoxView { HeightRequest = 10, BackgroundColor = CustomColors.Black },

                    new StackLayout
                    {
                        Padding = new Thickness(10),
                        BackgroundColor = CustomColors.BlackLight,
                        Children =
                        {
                        passwordEntry,
                        }
                    },

                    new BoxView { HeightRequest = 30, BackgroundColor = CustomColors.Black },

                    TextWidget.GetTextWidget(
                        text: "Дополнительные данные:",
                        color: CustomColors.YellowLight,
                        state: TextState.HeadlineMedium
                    ),

                    new BoxView { HeightRequest = 10, BackgroundColor = CustomColors.Black },

                    new StackLayout
                    {
                        Padding = new Thickness(10),
                        BackgroundColor = CustomColors.BlackLight,
                        Children =
                        {
                        lastNameEntry,
                        }
                    },

                    new BoxView { HeightRequest = 10, BackgroundColor = CustomColors.Black },

                    new StackLayout
                    {
                        Padding = new Thickness(10),
                        BackgroundColor = CustomColors.BlackLight,
                        Children =
                        {
                        phoneEntry,
                        }
                    },

                    new BoxView { HeightRequest = 10, BackgroundColor = CustomColors.Black },

                    new StackLayout
                    {
                        Padding = new Thickness(10),
                        BackgroundColor = CustomColors.BlackLight,
                        Children =
                        {
                        orgNameEntry,
                        }
                    },

                    new BoxView { HeightRequest = 30, BackgroundColor = CustomColors.Black },

                    go,

                    new BoxView { HeightRequest = 10, BackgroundColor = CustomColors.Black },

                    goBack

                }
                }
            };
        }

        private async void Go_Clicked(object? sender, EventArgs e)
        {
            await Shell.Current.GoToAsync("//profile");
        }

        private async void Go_Reg(object? sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(emailEntry.Text) || string.IsNullOrWhiteSpace(passwordEntry.Text) || string.IsNullOrWhiteSpace(nameEntry.Text))
            {
                await DisplayAlert("Ошибка", "Пожалуйста, введите имя, Email и пароль.", "OK");
                return;
            }

            string email = emailEntry.Text;
            string password = passwordEntry.Text;
            string result = await AuthInDataBase.RegisterUser(email, password);

            if (result == "ok") 
            {
                try
                {
                    string uid = DbManager.GenerateKey();

                    CustomUser user = new CustomUser(
                        uid: uid, 
                        firstName: nameEntry.Text, 
                        email: emailEntry.Text, 
                        lastName: lastNameEntry.Text, 
                        phone: phoneEntry.Text, 
                        organizationName: orgNameEntry.Text, 
                        avatarUrl: "", 
                        gender: ""
                        );
                                    

                    DbManager.PublishInDb(user, $"{uid}/userInfo");

                    await DisplayAlert("Отлично!", $"Ты успешно зарегистрировался!", "OK");

                    CustomUser.SetCurrentUser(uid: nameEntry.Text, lastName: lastNameEntry.Text, email: emailEntry.Text, phone: phoneEntry.Text, firstName: nameEntry.Text, gender: "", organizationName: orgNameEntry.Text, avatarUrl: "");

                    await Shell.Current.GoToAsync("//profile");

                }
                catch (Exception ex)
                {
                    await DisplayAlert("Ошибка", ex.Message, "OK");
                }
            }

            
        }

    }
}
