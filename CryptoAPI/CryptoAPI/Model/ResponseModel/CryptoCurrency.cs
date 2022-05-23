namespace CryptoAPI.Model.ResponseModel
{
    public class CryptoCurrency
    {
        public int symbolId { get; set; }
        public string Symbol { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public int CategoryId { get; set; }
    }
}
