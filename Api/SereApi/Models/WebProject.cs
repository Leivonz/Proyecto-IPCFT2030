using System;
using System.Collections.Generic;

namespace SereApi.Models
{
    public partial class WebProject
    {
        public WebProject()
        {
            WebProjectPeople = new HashSet<WebProjectPerson>();
        }

        public int IdWebProject { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string Status { get; set; } = null!;
        public string? Img { get; set; }

        public virtual ICollection<WebProjectPerson> WebProjectPeople { get; set; }
    }
}
