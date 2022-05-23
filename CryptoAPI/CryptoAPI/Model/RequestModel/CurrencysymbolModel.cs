namespace CryptoAPI.Model.RequestModel
{
    public class CurrencysymbolModel
    {
        public string Symbol { get; set; } = null!;
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
    }
}
