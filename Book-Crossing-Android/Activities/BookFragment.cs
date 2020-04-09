﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace Book_Crossing_Android.Activities
{
    public class BookFragment : Android.Support.V4.App.Fragment
    {
        private TextView textView;
        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View view = inflater.Inflate(Resource.Layout.BooksFragment,container,false);
            textView = view.FindViewById<TextView>(Resource.Id.textView1);
            textView.Click += (sender,e)=>{
                Toast.MakeText(view.Context,"hello",ToastLength.Long).Show();
            };
            return view;
        }

       
    }
}