using System;
using System.Collections.Generic;

namespace SereApi.Models
{
    public partial class Event
    {
        public Event()
        {
            PersonEvents = new HashSet<PersonEvent>();
        }

        public int IdEvent { get; set; }
        public string NameEvent { get; set; } = null!;
        public DateTime DateEvent { get; set; }
        public string DescriptionEvent { get; set; } = null!;
        public int ObjectiveEvent { get; set; }
        public int? IdEventType { get; set; }
        public int? SizeEvent { get; set; }
        public decimal CostEvent { get; set; }
        public int IdOrganization { get; set; }

        public virtual EventType? IdEventTypeNavigation { get; set; }
        public virtual Organization IdOrganizationNavigation { get; set; } = null!;
        public virtual Objective ObjectiveEventNavigation { get; set; } = null!;
        public virtual ICollection<PersonEvent> PersonEvents { get; set; }
    }
}
