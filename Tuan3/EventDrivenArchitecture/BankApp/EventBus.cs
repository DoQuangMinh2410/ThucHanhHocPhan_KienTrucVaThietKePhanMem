using BankApp.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp
{
    public class EventBus
    {
        private readonly Dictionary<Type, List<Action<IEvent>>> _handlers = new();
        public void Subscribe<T>(Action<T> handler) where T : IEvent
        {
            var type = typeof(T);
            if (!_handlers.ContainsKey(type))
                _handlers[type] = new List<Action<IEvent>>();
            _handlers[type].Add(e => handler((T)e));
        } 
        public void Publish<T>(T @event) where T : IEvent
        {
            var type = @event.GetType();
            if( _handlers.ContainsKey(type))
            {
                foreach(var handler in _handlers[type])
                    handler(@event);
            }    
        }    
    }
}
