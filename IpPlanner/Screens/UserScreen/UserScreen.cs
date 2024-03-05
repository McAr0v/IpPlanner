using Firebase.Database;
using Firebase.Database.Query;
using IpPlanner.Design.Buttons;
using IpPlanner.Design.Colors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpPlanner.Screens.UserScreen
{
    public class UserScreen: ContentPage
    {

        FirebaseClient firebase;

        CustomButton firstButton;
        CustomButton secondButton;
        CustomButton thirdButton;
        int counter = 0;

        public UserScreen() 
        {
            firebase = new FirebaseClient("https://ipplanner-4ca92-default-rtdb.firebaseio.com");



            firstButton = new CustomButton(text: counter.ToString(), OnBackButtonPressed, state: ButtonState.Primary);
            secondButton = new CustomButton(text: counter.ToString(), OnBackButtonPressed, state: ButtonState.Secondary);
            thirdButton = new CustomButton(text: counter.ToString(), clickedHandler: Button_Clicked, state: ButtonState.NotActive);

            BackgroundColor = CustomColors.Black;
            Padding = new Thickness(20);
            Content = new StackLayout
            {
                Spacing = 20,
                Children =
                {
                    firstButton,
                    secondButton, 
                    thirdButton
                }
            };
        }

        private void OnBackButtonPressed(object? sender, EventArgs e)
        {
            counter++;
            firstButton.Text = counter.ToString();
            secondButton.Text = (counter*2).ToString();
            thirdButton.Text = (counter * counter).ToString();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            try
            {
                var newData = new YourDataClass
                {
                    Property1 = "Value1",
                    Property2 = "Value2"
                };

                // Создание новой записи в базе данных Firebase
                var newItem = await firebase
                    .Child("Test") // Указываем узел, куда хотим записать данные
                    .PostAsync(newData); // Отправляем объект данных в базу данных Firebase

                await DisplayAlert("Success", $"Record created with key: {newItem.Key}", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }
    }

    public class YourDataClass
    {
        public required string Property1 { get; set; }
        public required string Property2 { get; set; }
    }
}
