using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.DomainEvents
{
    public class AddEventsToEntity : IEntityEvents
    {
        private readonly List<IDomainEvent> _domainEvents = new List<IDomainEvent>();

        public void AddEvent(IDomainEvent domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public ICollection<IDomainEvent> GetEventsThenClear()
        {
            var eventsCopy = _domainEvents.ToList();
            _domainEvents.Clear();
            return eventsCopy;
        }
    }
}
