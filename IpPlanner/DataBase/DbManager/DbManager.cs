using Firebase.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IpPlanner.DataBase.DbManager
{
    internal class DbManager
    {
        FirebaseClient firebase = new FirebaseClient("https://ipplanner-4ca92-default-rtdb.firebaseio.com");

        /*private async void PublishToDb()
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
                    .PutAsync(newData); // Отправляем объект данных в базу данных Firebase

                await DisplayAlert("Success", $"Record created with key: {newItem.Key}", "OK");
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "OK");
            }
        }*/
    }
}
