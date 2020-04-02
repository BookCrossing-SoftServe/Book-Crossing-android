using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Unity;

namespace Book_Crossing_Android.DependencyInjection
{
    [Application]
    public class App : Application
    {
        public App(IntPtr handle, JniHandleOwnership transfer) : base(handle, transfer)
        {

        }

        public override void OnCreate()
        {
            Initialize();
            base.OnCreate();

        }
        public static UnityContainer Container { get; set; }
        private static void Initialize()
        {
            App.Container = new UnityContainer();

        }
    }
}