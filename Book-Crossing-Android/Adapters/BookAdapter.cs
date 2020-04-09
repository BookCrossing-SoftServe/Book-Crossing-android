using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using RenameLater.models;

namespace Book_Crossing_Android.Adapters
{
    class BookAdapter : BaseAdapter<BookModel>
    {
        private List<BookModel> _books;

        Context context;

        public BookAdapter(Context context, List<BookModel> books)
        {
            this.context = context;
            this._books = books;
        }

        public override int Count => _books.Count;

        public override BookModel this[int position] => _books[position];

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
           
            View view = convertView;
            if (view == null)
            {
                view = LayoutInflater.From(this.context).Inflate(Resource.Layout.BookItem, null, false);

            }

            TextView bookName = view.FindViewById<TextView>(Resource.Id.bookName);
            TextView authors = view.FindViewById<TextView>(Resource.Id.bookAuthors);
            TextView categories = view.FindViewById<TextView>(Resource.Id.Category);

            bookName.Text = _books[position].Name;
            StringBuilder authorsBuilder = new StringBuilder();
            foreach (var author in _books[position].Authors)
            {
                authorsBuilder.Append(author.FirstName).Append(" ").Append(author.LastName);
                authorsBuilder.Append(", ");
            }

            authors.Text = authorsBuilder.ToString();
            authorsBuilder.Clear();
            foreach (var category in _books[position].Genres)
            {
                authorsBuilder.Append(category.Name).Append(",");
            }

            categories.Text = authorsBuilder.ToString();
            authorsBuilder.Clear();


            return view;

        }

        public override long GetItemId(int position)
        {
            return position;
        }

    }
}