namespace SereApi.Models
{
    public class Response
    {
        public bool Sucess { get; set; }
        public string Message { get; set; }
        public object Data { get; set; }

        public Response()
        {
            Sucess = false;
        }
    }
}
