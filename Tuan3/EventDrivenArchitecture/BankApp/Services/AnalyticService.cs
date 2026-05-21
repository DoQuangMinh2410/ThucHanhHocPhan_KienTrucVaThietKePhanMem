using BankApp.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Services
{
    public class AnalyticService
    {
        private double _totalDeposited = 0;
        private double _totalWithdrew = 0;
        private int _totalAccount = 0;
        public AnalyticService(EventBus bus) 
        {
            bus.Subscribe<AccountCreatedEvent>(AccountCreatedHandler);
            bus.Subscribe<AccountDepositedEvent>(DepositedHandler);
            bus.Subscribe<AccountWithdrewEvent>(WithdrewHandler);
        }

        private void WithdrewHandler(AccountWithdrewEvent @event)
        {
            _totalWithdrew += @event.amount;
            Log();
        }

        private void DepositedHandler(AccountDepositedEvent @event)
        {
            _totalDeposited += @event.amount;
            Log();
        }

        private void AccountCreatedHandler(AccountCreatedEvent @event)
        {
            _totalAccount++;
            Log();
        }

        private void Log()
        {
            Console.WriteLine($"{DateTime.Now}[Analytic Service]");
            Console.WriteLine($"- Total Deposited: {_totalDeposited}");
            Console.WriteLine($"- Total Withdrew: {_totalWithdrew}");
            Console.WriteLine($"- Total Account: {_totalAccount}");
        }

    }
}
