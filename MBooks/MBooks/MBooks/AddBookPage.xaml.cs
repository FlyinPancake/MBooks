using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MBooks
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class AddBookPage : ContentPage
	{
		public AddBookPage ()
		{
			InitializeComponent ();
		}

        private void NewBook_Saved(object sender, EventArgs e)
        {
            Books book = new Books()
            {
                Title = titleEntry.Text,
                Author = authorEntry.Text
            };

            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.DB_PATH))
            {
                conn.CreateTable<Books>();
                var numberOfRows = conn.Insert(book);

                if (numberOfRows > 0)
                {
                    DisplayAlert("Success!", "You saved you bloody book!", "Great");  
                }

                else
                {
                    DisplayAlert("Error", "The book wasn't saved", "I'm sad too");
                }
            }
            

            //DisplayAlert("Success", "You clicked a fucking button!", "I'll fuck myself");
        }
    }
}