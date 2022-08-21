namespace Data.Models
{
    public class ResultModel
    {
        public ResultModel(int statusCode)
        {
            this.StatusCode = statusCode;
            this.Message = string.Empty;
        }

        public ResultModel(int statusCode, string message)
        {
            this.StatusCode = statusCode;
            this.Message = message;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
    }
}
