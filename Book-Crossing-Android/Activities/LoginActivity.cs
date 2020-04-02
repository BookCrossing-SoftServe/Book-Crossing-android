using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Authentication;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Book_Crossing_Android.DependencyInjection;
using RenameLater.models;
using RenameLater.services.implementations;
using RenameLater.services.interfaces;
using Unity;
using Xamarin.Essentials;

namespace Book_Crossing_Android.Activities
{
    [Activity(Label = "LoginActivity",MainLauncher = false)]
    public class LoginActivity : Activity
    {

        private IAuthenticate _authenticate;

        private EditText login;
        private EditText password;
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
            this.login = FindViewById<EditText>(Resource.Id.userName);
            this.password = FindViewById<EditText>(Resource.Id.password);
            this.loginBtn = FindViewById<Button>(Resource.Id.login);
            this.loginBtn.Click += LoginBtn_Click;
        }

        private async void LoginBtn_Click(object sender, EventArgs e)
        {
            try
            {

                var token = await this._authenticate.VerifyCredentialsAsync(new LoginModel(login.Text, password.Text));
                await SecureStorage.SetAsync("token", token.Token);
                Intent intent = new Intent(this,typeof(MainActivity));
                intent.PutExtra("firstName", token.FirstName);
                intent.PutExtra("lastName", token.LastName);
                intent.PutExtra("email", token.Email);
                StartActivity(intent);
            }
            catch (InvalidCredentialException ex)
            {
                Toast.MakeText(this,"Invalid credentials!",ToastLength.Long).Show();
            }
        }

    }
}