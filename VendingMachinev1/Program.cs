// See https://aka.ms/new-console-template for more information

using VendingMachinev1;



var Bank = new Bank();
var Account = new Account(100, "abcdef4");
Bank.Accounts.Add(Account);
var Inventory = new Inventory();
var User = new User( "John Does", Account, Inventory);

var VendingMachine = new VendingMachine(User);

VendingMachine.Run();
