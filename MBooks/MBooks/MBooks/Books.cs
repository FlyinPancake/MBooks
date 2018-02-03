using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace MBooks
{
    public class Books
    {
        [PrimaryKey, AutoIncrement]

        public int index { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }
    }
}
