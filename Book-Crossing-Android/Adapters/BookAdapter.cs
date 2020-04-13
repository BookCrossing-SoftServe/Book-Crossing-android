using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Book_Crossing_Android.DependencyInjection;
using RestApiClient.models;
using RestApiClient.models.response;
using RestApiClient.services.interfaces;
using Unity;

namespace Book_Crossing_Android.Adapters
{
   class RecyclerViewHolder : RecyclerView.ViewHolder
   {
       public TextView BookNameTextView;
       public TextView AuthorsTextView;
       public TextView CategoriesTextView;

       public Button RequestButton;
       public ProgressBar ProgressBar;

       public RecyclerViewHolder(View ItemView) : base(ItemView)
       {
           BookNameTextView = ItemView.FindViewById<TextView>(Resource.Id.bookName);
           AuthorsTextView = ItemView.FindViewById<TextView>(Resource.Id.bookAuthors);
           CategoriesTextView = ItemView.FindViewById<TextView>(Resource.Id.Category);
            RequestButton = ItemView.FindViewById<Button>(Resource.Id.requestButton);
            ProgressBar = ItemView.FindViewById<ProgressBar>(Resource.Id.requestProgressBar);
       }
   }


    class RecyclerViewAdapter : RecyclerView.Adapter
    {
        private List<BookModel> _books = new List<BookModel>();
        public override int ItemCount => _books.Count;

        private IRequest _requestService;

        public RecyclerViewAdapter(List<BookModel> books)
        {
            _books = books;
            _requestService = App.Container.Resolve<IRequest>();
        }

        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            RecyclerViewHolder viewHolder = holder as RecyclerViewHolder;
            viewHolder.BookNameTextView.Text = _books[position].Name;
            viewHolder.RequestButton.Click += async (e, s) =>
            {
                viewHolder.ProgressBar.Visibility = ViewStates.Visible;
                viewHolder.RequestButton.Visibility = ViewStates.Gone;

                await _requestService.CreateRequestAsync(_books[position].Id, new LoggedUser());

                viewHolder.ProgressBar.Visibility = ViewStates.Gone;
                viewHolder.RequestButton.Visibility = ViewStates.Visible;
                viewHolder.RequestButton.Text = "Requested!";
                viewHolder.RequestButton.SetBackgroundResource(Resource.Drawable.RoundedButtonSucess);

            };
        }

        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            LayoutInflater inflater = LayoutInflater.From(parent.Context);
            View itemView = inflater.Inflate(Resource.Layout.BookItem, parent,false);
            return new RecyclerViewHolder(itemView);

        }
    }
}