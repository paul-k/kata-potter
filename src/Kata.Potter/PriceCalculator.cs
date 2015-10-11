using System.Collections.Generic;

namespace Kata.Potter
{
    public class PriceCalculator
    {
        public List<string> Books { get; set; }
        public int Total
        {
            get { return Books.Count * 8; }
        }

        public PriceCalculator()
        {
            Books = new List<string>();
        }

        public void AddBook(string id)
        {
            Books.Add(id);
        }
    }
}
