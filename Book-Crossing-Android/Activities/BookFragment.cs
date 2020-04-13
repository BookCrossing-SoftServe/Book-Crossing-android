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
using Android.Support.V7.Widget;
using Android.Util;
using Android.Views;
using Android.Widget;
using Book_Crossing_Android.Adapters;
using Book_Crossing_Android.DependencyInjection;
using Newtonsoft.Json;
using RestApiClient.models;
using RestApiClient.services.interfaces;
using Unity;

namespace Book_Crossing_Android.Activities
{
    public class BookFragment : Android.Support.V4.App.Fragment
    {
        private RecyclerView _recycler;
        private RecyclerViewAdapter _adapter;
        private RecyclerView.LayoutManager _layoutManager;
        private ProgressBar _progressBar;

        private List<BookModel> books;
        
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
            _recycler = view.FindViewById<RecyclerView>(Resource.Id.bookRecyclerView);
            _recycler.HasFixedSize = true;
            _layoutManager = new LinearLayoutManager(view.Context);
            _recycler.SetLayoutManager(_layoutManager);
            
            _progressBar = view.FindViewById<ProgressBar>(Resource.Id.progressBar1);
            Test(view.Context);
            return view;
        }

       

      

        public async Task Test(Context currContext)
        {
            var booksService = App.Container.Resolve<IBooksService>();
            try
            {
                books = await booksService.GetAllBooksAsync();
                _progressBar.Visibility = ViewStates.Gone;
                _recycler.Visibility = ViewStates.Visible;
                _adapter = new RecyclerViewAdapter(books);

                _recycler.SetAdapter(_adapter);
                
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