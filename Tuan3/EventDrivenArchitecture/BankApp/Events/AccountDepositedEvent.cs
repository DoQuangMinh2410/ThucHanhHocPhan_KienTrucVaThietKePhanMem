using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Events
{
    public record AccountDepositedEvent(string id, double amount) : IEvent;
    
}
