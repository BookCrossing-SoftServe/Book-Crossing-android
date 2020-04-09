using Android.App;
using Android.OS;
using Android.Support.V7.App;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Java.Lang;

using Book_Crossing_Android.Activities;
using Java.IO;
using RenameLater.services.interfaces;
using V7Toolbar = Android.Support.V7.Widget.Toolbar;
namespace Book_Crossing_Android
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = false)]
    public class MainActivity : AppCompatActivity
    {
        DrawerLayout drawerLayout;
        NavigationView navigationView;
        private V7Toolbar toolBar;
        private View headerView;

        public MainActivity(IBooksService booksService)
        {

        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.activity_main);

            SetUpSupportActionBar();

            SetUpNavigationView();
           
            
           

            var txtUsername = headerView.FindViewById<TextView>(Resource.Id.userNameTextView);
            var stringBuidler = new StringBuilder();
            stringBuidler.Append(Intent.GetStringExtra("lastName")).Append(" ")
                .Append(Intent.GetStringExtra("firstName"));

            txtUsername.Text = stringBuidler.ToString();
        }
        private void SetUpNavigationView()
        {
            drawerLayout = FindViewById<Android.Support.V4.Widget.DrawerLayout>(Resource.Id.drawer_layout);
            navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;
            headerView = navigationView.GetHeaderView(0);
        }

        private void SetUpSupportActionBar()
        {
            toolBar = FindViewById<V7Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolBar);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDisplayShowTitleEnabled(false);
            SupportActionBar.SetHomeButtonEnabled(true);
            SupportActionBar.SetHomeAsUpIndicator(Resource.Drawable.abc_btn_check_material);
        }


        private void NavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            switch (e.MenuItem.ItemId)
            {
                case Resource.Id.nav_books:
                    var trans = SupportFragmentManager.BeginTransaction();
                    trans.Add(Resource.Id.frameLayout1, new BookFragment(), "Fragment1");
                    trans.Commit();
                    break;
                     
            }
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Log.Debug("number",item.ItemId.ToString());


            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    drawerLayout.OpenDrawer(Android.Support.V4.View.GravityCompat.Start);
                    return true;

            }
            return base.OnOptionsItemSelected(item);
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }
}