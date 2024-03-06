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

        FirebaseClient firebase = new FirebaseClient("https://ipplanner-4ca92-default-rtdb.firebaseio.com");

        CustomButton firstButton;
        CustomButton secondButton;
        CustomButton thirdButton;

        // Создаем список для хранения данных
        List<YourDataClass> dataList = new List<YourDataClass>();

        StackLayout stackLayoutButtons = new StackLayout{};
        StackLayout stackLayoutLabels = new StackLayout{};
        StackLayout stackLayoutMain = new StackLayout{};

        int counter = 0;

        public UserScreen() 
        {
                        

            firstButton = new CustomButton(text: "Очистить", clickedHandler:  ClearLabels, state: ButtonState.Primary);
            secondButton = new CustomButton(text: "Получить", clickedHandler: ReadDataFromFirebase, state: ButtonState.Secondary);
            thirdButton = new CustomButton(text: "Отправить", clickedHandler: Button_Clicked, state: ButtonState.NotActive);

            stackLayoutButtons = new StackLayout
            {
                Spacing = 20,
                Children =
                {
                    firstButton,
                    secondButton,
                    thirdButton,

                }
            };

            stackLayoutLabels = new StackLayout
            {
                Spacing = 20
            };

            stackLayoutMain = new StackLayout
            {
                Spacing = 20,
                Children = 
                {
                    stackLayoutButtons,
                    stackLayoutLabels
                }

            };

            BackgroundColor = CustomColors.Black;
            Padding = new Thickness(20);
            

            Content = stackLayoutMain;

            if (dataList.Count > 0)
            {
                // Создаем метку для каждого элемента в dataList
                foreach (var data in dataList)
                {
                    // Создаем метку и добавляем ее в StackLayout
                    var label = new Label
                    {
                        Text = $"Property1: {data.Property1}, Property2: {data.Property2}"
                    };
                    stackLayoutLabels.Children.Add(label);
                }
            }


        }

        private void OnBackButtonPressed(object? sender, EventArgs e)
        {
            counter++;
            firstButton.Text = counter.ToString();
            //secondButton.Text = (counter*2).ToString();
            //thirdButton.Text = (counter * counter).ToString();
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

        private async void ReadDataFromFirebase(object sender, EventArgs e)
        {
            try
            {
                // Получаем данные из узла "Test"
                var dataSnapshot = await firebase.Child("Test").OnceAsync<YourDataClass>();

                // Перебираем полученные данные
                foreach (var data in dataSnapshot)
                {
                    // Получаем ключ узла
                    var key = data.Key;

                    // Получаем данные из узла
                    var newData = data.Object;

                    dataList.Add(newData);

                    // Выводим полученные данные
                    Console.WriteLine($"Key: {key}, Property1: {newData.Property1}, Property2: {newData.Property2}");
                }

                UpdateLabels();

            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }

        private void UpdateLabels()
        {
            // Очищаем старые метки
            //stackLayout.Children.Clear();
            int counter = 0;
            // Добавляем метки для каждого элемента в dataList
            foreach (var data in dataList)
            {
                // Создаем метку и добавляем ее в StackLayout
                var label = new Label
                {
                    Text = $"Property{counter}: {data.Property1}, Property2: {data.Property2}",
                    TextColor = CustomColors.White
                };
                stackLayoutLabels.Children.Add(label);
                counter++;
            }
        }

        private void ClearLabels(object sender, EventArgs e)
        {
            // Очищаем старые метки
            stackLayoutLabels.Children.Clear();

            dataList.Clear();
            
        }

    }



    public class YourDataClass
    {
        public required string Property1 { get; set; }
        public required string Property2 { get; set; }
    }
}
