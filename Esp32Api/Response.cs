namespace Esp32Api
{
    public class Response
    {
        public bool IsSuccess { set; get; } = true;
        public string Message { set; get; } = "OK";
    }

    public class Response<T>
    {
        public T? Data { get; set; }
        public bool IsSuccess { set; get; } = true;
        public string Message { set; get; } = "OK";
    }
}
