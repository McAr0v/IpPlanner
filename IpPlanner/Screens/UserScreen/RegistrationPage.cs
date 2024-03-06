using Firebase.Auth.Providers;
using Firebase.Auth;
using Firebase.Auth.Repository;
using IpPlanner.DataBase.Auth;
using static System.Runtime.InteropServices.JavaScript.JSType;




namespace IpPlanner.Screens.UserScreen
{

    public partial class RegistrationPage : ContentPage
    {
        //FirebaseAuthProvider authProvider;
        private Entry emailEntry;
        private Entry passwordEntry;
        private Button registerButton;
        private Button signOutButton;
        private Button signInButton;
        private Label label;
        private CustomUser user;
        private StackLayout allStack;

        public RegistrationPage()
        {

            

            user = CustomUser.CurrentUser;

            if (user != null)
            {
                label = new Label
                {
                    Text = $"Имя: {user.FirstName}, Email: {user.Email}, UID: {user.Uid}"
                };
            }
            else 
            {
                label = new Label
                {
                    Text = $"Имя: Не задано, Email: Не задано, UID: Не задано"
                };
            }

            

            emailEntry = new Entry { Placeholder = "Email", Keyboard = Keyboard.Email };
            passwordEntry = new Entry { Placeholder = "Password", IsPassword = true };
            registerButton = new Button { Text = "Register" };
            signOutButton = new Button { Text = "Выйти" };
            signInButton = new Button { Text = "Войти" };


            registerButton.Clicked += RegisterButton_Clicked;
            signOutButton.Clicked += SignOutButton_Clicked;
            signInButton.Clicked += SignInButton_Clicked;

            allStack = new StackLayout
            {
                Padding = new Thickness(20),
                Spacing = 20,
                Children =
                {
                    emailEntry,
                    passwordEntry,
                    registerButton,
                    signOutButton,
                    signInButton,
                    label
                }
            };

            Content = allStack;
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            var email = emailEntry.Text;
            var password = passwordEntry.Text;

            // Вызываем метод RegisterUser из класса AuthInDataBase
            string result = await AuthInDataBase.RegisterUser(email, password);

            // Проверяем результат регистрации
            if (result == "ok")
            {

                allStack.Children.Remove(label);

                user = CustomUser.GetCurrentUser();
                label = new Label 
                {
                    Text = $"Имя: {user.FirstName}, Email: {user.Email}, UID: {user.Uid}"
                };

                

                allStack.Children.Add(label);

                await DisplayAlert("Success", "User registered successfully!", "OK");
            }
            else
            {
                await DisplayAlert("Error", "User registration failed.", "OK");
            }

        }

        private async void SignOutButton_Clicked(object sender, EventArgs e)
        {

            AuthInDataBase.SignOut();

            CustomUser.ClearUser();

            allStack.Children.Remove(label);

            user = CustomUser.GetCurrentUser();

            await DisplayAlert("Success", "Ты успешно вышел!", "OK");

        }

        private async void SignInButton_Clicked(object sender, EventArgs e)
        {
            var email = emailEntry.Text;
            var password = passwordEntry.Text;

            // Вызываем метод RegisterUser из класса AuthInDataBase
            string result = await AuthInDataBase.SignIn(email, password);

            // Проверяем результат регистрации
            if (result == "ok")
            {

                allStack.Children.Remove(label);

                user = CustomUser.GetCurrentUser();
                label = new Label
                {
                    Text = $"Имя: {user.FirstName}, Email: {user.Email}, UID: {user.Uid}"
                };



                allStack.Children.Add(label);

                await DisplayAlert("Success", "User SIGN IN successfully!", "OK");
            }
            else
            {
                await DisplayAlert("Error", "User registration failed.", "OK");
            }

        }

    }
}
