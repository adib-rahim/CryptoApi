using System;
using System.Collections.Generic;

namespace CryptoAPI.Model
{
    public partial class Currencycategory
    {
        public Currencycategory()
        {
            Currencysymbols = new HashSet<Currencysymbol>();
        }

        public int Id { get; set; }
        public string Category { get; set; } = null!;

        public virtual ICollection<Currencysymbol> Currencysymbols { get; set; }
    }
}
