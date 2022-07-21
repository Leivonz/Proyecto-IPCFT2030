namespace SereApi.Models
{
    public class EventeFile
    {
        public string name { get; set; }
        public string description { get; set; }
        public DateTime date { get; set; }
        public IFormFile file { get; set; }

    }
}
