using System;
using System.Collections.Generic;

namespace SereApi.Models
{
    public partial class EventType
    {
        public EventType()
        {
            Events = new HashSet<Event>();
        }

        public int IdEvent { get; set; }
        public string NameEventType { get; set; } = null!;

        public virtual ICollection<Event> Events { get; set; }
    }
}
