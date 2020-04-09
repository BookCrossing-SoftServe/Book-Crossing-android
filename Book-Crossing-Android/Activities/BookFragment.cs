using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Book_Crossing_Android.Adapters;
using Book_Crossing_Android.DependencyInjection;
using Newtonsoft.Json;
using RenameLater.models;
using RenameLater.services.interfaces;
using Unity;

namespace Book_Crossing_Android.Activities
{
    public class BookFragment : Android.Support.V4.App.Fragment
    {
        private ListView listView;
        private List<BookModel> books;
        public override async void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Create your fragment here
            
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            // return inflater.Inflate(Resource.Layout.YourFragment, container, false);
            View view = inflater.Inflate(Resource.Layout.BooksFragment,container,false);
            listView = view.FindViewById<ListView>(Resource.Id.booksListView);
            Test(view.Context);
            return view;
        }

        public async Task Test(Context currContext)
        {
            var booksService = App.Container.Resolve<IBooksService>();
            try
            {
                books = await booksService.GetAllBooksAsync();
                listView.Adapter = new BookAdapter(currContext,books);
            }
            catch (JsonException)
            {
                Toast.MakeText(currContext, "Error parsing data, try later", ToastLength.Long).Show();
            }
            catch (System.Net.Http.HttpRequestException) 
            {
                Toast.MakeText(currContext, "No internet, try later", ToastLength.Long).Show();
            }

        }
       
    }
}