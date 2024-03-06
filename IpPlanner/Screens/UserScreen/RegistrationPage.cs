using Firebase.Auth.Providers;
using Firebase.Auth;
using Firebase.Auth.Repository;




namespace IpPlanner.Screens.UserScreen
{

    public partial class RegistrationPage : ContentPage
    {
        //FirebaseAuthProvider authProvider;
        private Entry emailEntry;
        private Entry passwordEntry;
        private Button registerButton;

        public RegistrationPage()
        {

            emailEntry = new Entry { Placeholder = "Email", Keyboard = Keyboard.Email };
            passwordEntry = new Entry { Placeholder = "Password", IsPassword = true };
            registerButton = new Button { Text = "Register" };
            registerButton.Clicked += RegisterButton_Clicked;

            Content = new StackLayout
            {
                Padding = new Thickness(20),
                Children =
                {
                    emailEntry,
                    passwordEntry,
                    registerButton
                }
            };
        }

        private async void RegisterButton_Clicked(object sender, EventArgs e)
        {
            var email = emailEntry.Text;
            var password = passwordEntry.Text;
            var config = new FirebaseAuthConfig
            {
                ApiKey = "AIzaSyARoqME43rFRS4ZgfYzwJD9W8KToFdtg40",
                //AuthDomain = "ipplanner-4ca92.firebaseapp.com",
                AuthDomain = "ipplanner-4ca92.firebaseapp.com",
                Providers = new FirebaseAuthProvider[]
                {
                    // Add and configure individual providers
                    //new GoogleProvider().AddScopes("email"),
                    new EmailProvider()
                    // ...
                },
                // You can specify a UserRepository for data persistence
                UserRepository = new FileUserRepository("FirebaseSample") // Persist data into %AppData%\FirebaseSample
            };

            var client = new FirebaseAuthClient(config);

            try
            {
                //var userCredential = await client.SignInWithEmailAndPasswordAsync(email, password);
                var userCredential = await client.CreateUserWithEmailAndPasswordAsync(email, password);

                var user = userCredential.User;
                var uid = user.Uid;
                var name = user.Info.DisplayName;

                // Проверяем успешность регистрации
                if (uid != null && user != null)
                {
                    await DisplayAlert("Success", $"user uid - {uid}", "OK");
                }
                else
                {
                    await DisplayAlert("Error", "User registration failed.", "OK");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
                await DisplayAlert("Error", ex.Message, "OK");


            }
            


        }
    }
}
