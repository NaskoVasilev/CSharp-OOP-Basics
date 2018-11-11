using System;
using System.Text;

namespace BookLibrary
{
    public class Book
    {
        private string title;
        private decimal price;
        private string author;

        public Book(string author, string title, decimal price)
        {
            Title = title;
            Author = author;
            Price = price;
        }

        public string Title
        {
            get { return title; }
            set
            {
                if (value.Length < 3)
                {
                    throw new ArgumentException("Title not valid!");
                }
                title = value;
            }
        }

        public string Author
        {
            get { return author; }
            set
            {
                if (char.IsDigit(value[value.IndexOf(' ') + 1]))
                {
                    throw new ArgumentException("Author not valid!");
                }
                author = value;
            }
        }

        public virtual decimal Price
        {
            get { return price; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Price not valid!");
                }
                price = value;
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"Type: {this.GetType().Name}\n");
            sb.Append($"Title: {this.Title}\n");
            sb.Append($"Author: {this.Author}\n");
            sb.Append($"Price: {this.Price:F2}");

            return sb.ToString();
        }
    }
}
