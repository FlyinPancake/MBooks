using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MBooks
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        protected override void OnAppearing()
        {
            base.OnAppearing();

            using(SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Books>();

                var books = conn.Table<Books>().ToList();

                BooksList.ItemsSource = books;
            }
        }

        private void Navigation_AddBook(object sender, EventArgs e)
        {
            Navigation.PushAsync(new AddBookPage());
        }
    }
}
