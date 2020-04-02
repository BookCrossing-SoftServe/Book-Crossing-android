using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Widget;
using Java.Lang;

namespace Book_Crossing_Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class MainActivity : AppCompatActivity
    {
        private TextView _welcomeTextView;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);

            ConnectControls();

            string firstName = Intent.GetStringExtra("firstName");
            string lastName = Intent.GetStringExtra("lastName");
            string email = Intent.GetStringExtra("email");
            StringBuilder sb = new StringBuilder();
            sb.Append("Welcome ").Append(firstName).Append(" ").Append(lastName);
            _welcomeTextView.Text = sb.ToString();
        }
        private void ConnectControls()
        {
            _welcomeTextView = FindViewById<TextView>(Resource.Id.welcomeText);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}