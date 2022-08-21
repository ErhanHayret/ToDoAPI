namespace Data.Models
{
    public class ResultDataModel<T> where T : class
    {
        public ResultDataModel(int statusCode)
        {
            StatusCode = statusCode;
            Data = null;
            Message = string.Empty;
        }
        public ResultDataModel(int statusCode, T data)
        {
            StatusCode = statusCode;
            Data = data;
            Message = string.Empty;
        }

        public ResultDataModel(int statusCode, string message, T data)
        {
            StatusCode = statusCode;
            Data = data;
            Message = message;
        }

        public int StatusCode { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
