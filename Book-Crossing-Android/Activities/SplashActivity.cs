using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;

namespace Book_Crossing_Android.Activities
{
    [Activity(Label = "SplashActivity",Theme = "@style/MyTheme.splash",MainLauncher = true,NoHistory = true,ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class SplashActivity : AppCompatActivity
    {
        private ISharedPreferences _sharedPreferences;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your application here
            _sharedPreferences = Application.Context.GetSharedPreferences("userInfo", FileCreationMode.Private);
            string firstName = _sharedPreferences.GetString("firstName", string.Empty);
            string lastName = _sharedPreferences.GetString("lastName", string.Empty);
            string email = _sharedPreferences.GetString("email", string.Empty);
            if (firstName == string.Empty && lastName == string.Empty)
            {
                StartActivity(typeof(LoginActivity));
            }
            else
            {
                Intent intent = new Intent(this, typeof(MainActivity));
                intent.PutExtra("firstName", firstName);
                intent.PutExtra("lastName", lastName);
                intent.PutExtra("email", email);
                StartActivity(intent);
            }
        }
        //  private void RetrieveData()
    }
}