using BankApp.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Services
{
    public class AccountService
    {
        private Dictionary<string, double> _accounts = new();
        private EventBus _bus;
        public AccountService(EventBus bus)
        {
            _bus = bus;
        }
        public void CreateAccount(string id, string owner)
        {
            _accounts[id] = 0;
            Console.WriteLine($"{DateTime.Now} [Account Service]" + $"created account {id} for {owner}");
            _bus.Publish(new AccountCreatedEvent(id, owner));

        }
        public void Deposit(string id, double amount)
        {
            _accounts[id] += amount;
            Console.WriteLine($"{DateTime.Now} [Account Service]" + $"deposited {amount} for {id}");
            _bus.Publish(new AccountDepositedEvent(id, amount));
        }
        public void Withdraw(string id, double amount)
        {
            if (_accounts[id] >= amount) 
            {
                _accounts[id] -= amount;
                Console.WriteLine($"{DateTime.Now} [Account Service]" + $"withdrew {amount} for {id}");
                _bus.Publish(new AccountWithdrewEvent(id, amount));
            }
        }
    }
}