using System;
using System.Collections.Generic;
using System.Text;

namespace BookLibrary
{
    public class GoldenEditionBook : Book
    {
        public GoldenEditionBook(string author, string title, decimal price)
            : base(author, title, price)
        {
        }

        public override decimal Price
        {
            get => base.Price * 1.3M;
            set => base.Price = value;
        }
    }
}
