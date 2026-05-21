using BankApp;
using BankApp.Services;

Console.WriteLine("Hello, World!");
Console.WriteLine("WELCOME TO DIEU DA BANK");
var bus = new EventBus();
var accountService = new AccountService(bus);
var analyticService = new AnalyticService(bus);

//EXAMPLE
accountService.CreateAccount("VIP1", "David");

