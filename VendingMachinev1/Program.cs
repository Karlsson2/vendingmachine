// See https://aka.ms/new-console-template for more information

using VendingMachinev1;


//create all the initial values
var bank = new Bank();
var account = new Account(100, "abcdef4");
bank.Accounts.Add(account);
var inventory = new Inventory();
var user = new User( "John Does", account, inventory);

var vendingMachine = new VendingMachine(user);

vendingMachine.Run();
