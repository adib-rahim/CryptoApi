namespace CryptoAPI.Model.ResponseModel
{
    public class ResponseModel
    {
        public int StatusCode { get; set; }
        public string StatusDescription { get; set; } = string.Empty;
        public dynamic? Items { get; set; }
        public ResponseModel()
        {

        }
    }
}
