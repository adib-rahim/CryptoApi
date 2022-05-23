using System;
using System.Collections.Generic;

namespace CryptoAPI.Model
{
    public partial class Currencysymbol
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = null!;
        public decimal Price { get; set; }
        public int? CategoryId { get; set; }

        public virtual Currencycategory? Category { get; set; }
    }
}
