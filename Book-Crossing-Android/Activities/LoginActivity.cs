using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Authentication;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Book_Crossing_Android.DependencyInjection;
using RenameLater.models;
using RenameLater.models.response;
using RenameLater.services.implementations;
using RenameLater.services.interfaces;
using Unity;
using Xamarin.Essentials;

namespace Book_Crossing_Android.Activities
{
    [Activity(Label = "LoginActivity",MainLauncher = false)]
    public class LoginActivity : AppCompatActivity
    {

        private IAuthenticate _authenticate;
        private ISharedPreferences _preferences;
        private ISharedPreferencesEditor _preferencesEditor;


        private CoordinatorLayout rootView;
        private TextInputLayout login;
        private TextInputLayout password;
        private Button loginBtn;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.activity_login);
            // Create your application here

            _authenticate = App.Container.Resolve<Authenticate>();
            ConnectControllers();
        }

        private void ConnectControllers()
        {
            this.rootView = FindViewById<CoordinatorLayout>(Resource.Id.rootView);
            this.login = FindViewById<TextInputLayout>(Resource.Id.userName);
            this.password = FindViewById<TextInputLayout>(Resource.Id.password);
            this.loginBtn = FindViewById<Button>(Resource.Id.login);
            this.loginBtn.Click += LoginBtn_Click;
        }

        private async void LoginBtn_Click(object sender, EventArgs e)
        {
            try
            {

                var token = await this._authenticate.VerifyCredentialsAsync(new LoginModel(login.EditText.Text, password.EditText.Text));
                await SaveUserInfo(token);
                Intent intent = new Intent(this,typeof(MainActivity));
                intent.PutExtra("firstName", token.FirstName);
                intent.PutExtra("lastName", token.LastName);
                intent.PutExtra("email", token.Email);
                StartActivity(intent);
            }
            catch (InvalidCredentialException)
            {
                Snackbar.Make(rootView,"Invalid credentials",Snackbar.LengthLong).Show();
                
            }
        }

        private async Task SaveUserInfo(LoggedUser user)
        {
            _preferences = Application.Context.GetSharedPreferences("userInfo", FileCreationMode.Private);
            _preferencesEditor = _preferences.Edit();

            _preferencesEditor.PutString("firstName", user.FirstName);
            _preferencesEditor.PutString("lastName", user.LastName);
            _preferencesEditor.PutString("email", user.Email);  

            _preferencesEditor.Apply();
            
            await SecureStorage.SetAsync("token", user.Token);

        }

    }
}