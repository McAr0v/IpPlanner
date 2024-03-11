using Firebase.Auth.Providers;
using Firebase.Auth.Repository;
using Firebase.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Maui.ApplicationModel.Communication;

namespace IpPlanner.DataBase.Auth
{
    internal class AuthInDataBase
    {

        // Конфигурация подключения к сервису авторизации

        private static readonly FirebaseAuthConfig config = new FirebaseAuthConfig
        {
            ApiKey = "AIzaSyARoqME43rFRS4ZgfYzwJD9W8KToFdtg40",
            AuthDomain = "ipplanner-4ca92.firebaseapp.com",
            Providers = new FirebaseAuthProvider[]
                {
                    new EmailProvider()
                },
            // Локальная директория для сохранения данных о пользователе
            UserRepository = new FileUserRepository("UserData") // Persist data into %AppData%\FirebaseSample
        };

        // Клиент сервиса авторизации
        private static readonly FirebaseAuthClient client = new FirebaseAuthClient(config);

        // Функция, заполняющая Current User при инициализации приложения
        public static CustomUser? setUser()
        {
            if (client.User != null)
            {
                return new CustomUser
                (
                    firstName: client.User.Info.FirstName,
                    lastName: client.User.Info.LastName,
                    email: client.User.Info.Email,
                    phone: "",
                    organizationName: "",
                    uid: client.User.Info.Uid,
                    gender: ""
                );
            }
            else return null;
        }


        public static async Task<string> RegisterUser(String email, String password)
        {

            try
            {
                var userCredential = await client.CreateUserWithEmailAndPasswordAsync(email, password);

                var user = userCredential.User;
                var uidUser = user.Uid;

                // Проверяем успешность регистрации
                if (uidUser != null && user != null)
                {
                    CustomUser.SetCurrentUser(firstName: user.Info.FirstName, lastName: user.Info.LastName, email: user.Info.Email, uid: uidUser, phone: "", organizationName: "");
                    return "ok";
                }
                else
                {
                    return "error";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
                
            }
        }

        // Функция выхода из профиля
        public static void SignOut()
        {

            client.SignOut();
            CustomUser.ClearUser();

        }

        // Функция входа в профиль

        public static async Task<string> SignIn(String email, String password)
        {

            try
            {
                var userCredential = await client.SignInWithEmailAndPasswordAsync(email, password);

                // Сохранение токена в безопасном хранилище

                var user = userCredential.User;
                var uidUser = user.Uid;

                // Проверяем успешность регистрации
                if (uidUser != null && user != null)
                {
                    CustomUser.SetCurrentUser(firstName: user.Info.FirstName, lastName: user.Info.LastName, email: user.Info.Email, uid: uidUser, phone: "", organizationName: "", gender: "");
                    return "ok";
                }
                else
                {
                    return "error";
                }
            }
            catch (Exception ex)
            {
                return ex.Message;

            }
        }
    }
}
