using System.Collections.Generic;
using System.Linq;

namespace Kata.Potter
{
    public class PriceCalculator
    {
        private const int CostOfBook = 8;
        private Dictionary<string, int> _books { get; set; }
        private Dictionary<int, decimal> _appliedDiscounts { get; set; }
        private decimal _total;

        public decimal Total
        {
            get
            {
                this.CalculateTotal();
                return _total;
            }
        }

        public PriceCalculator()
        {
            _books = new Dictionary<string, int>();
            _appliedDiscounts = new Dictionary<int, decimal>();
            _total = 0;
        }

        public void AddBook(string id)
        {
            this.AddBook(id, 1);
        }

        public void AddBook(string id, int quantity)
        {
            if (_books.ContainsKey(id))
                _books[id] += quantity;
            else
                _books.Add(id, quantity);
        }

        private void CalculateTotal()
        {
            _total = _books.Select(x => x.Value).Sum() * CostOfBook;

            this.ApplyDiscounts();
        }

        private void ApplyDiscounts()
        {
            var booksToDiscount = _books.Clone();

            while(booksToDiscount.Where(x => x.Value > 0).Count() > 1)
            {
                var discount = 0m;

                switch (booksToDiscount.Count)
                {
                    case 5:
                        discount = 0.25m;
                        break;
                    case 4:
                        discount = 0.20m;
                        break;
                    case 3:
                        discount = 0.10m;
                        break;
                    case 2:
                        discount = 0.05m;
                        break;
                }

                _appliedDiscounts.Add(booksToDiscount.Count, discount);

                var booksToReduceQuantity = booksToDiscount
                    .Where(x => x.Value > 0)
                    .ToDictionary(x => x.Key, x => x.Value);

                foreach (var book in booksToReduceQuantity)
                {
                    var newQuantity = book.Value - 1;

                    if (newQuantity >= 0)
                        booksToDiscount[book.Key] = newQuantity;
                }
            }

            foreach (var discount in _appliedDiscounts)
            {
                var costOfBooksBeforeDiscount = (discount.Key * CostOfBook);

                _total -= (costOfBooksBeforeDiscount * discount.Value);
            }
        }
    }

    public static class DictionaryExtentions
    {
        public static Dictionary<TKey, TValue> Clone<TKey, TValue>(this Dictionary<TKey, TValue> original)
        {
            var result = new Dictionary<TKey, TValue>();

            foreach (var item in original)
                result.Add(item.Key, item.Value);

            return result;
        }
    }
}
