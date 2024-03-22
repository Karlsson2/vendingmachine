using System.Globalization;

namespace VendingMachinev1;
public class VendingMachine
{
    public List<Product> Products;
    public User CurrentUser;
    
    public List<string> Commands { get; } = new List<string>
    {
        "1. Show products",
        "2. Show inventory",
        "3. Check Out",
        "4. Quit"
    };
    
    public VendingMachine(User user)
    {
        Products = new List<Product>();
        //maybe implement a "document reading" property to store the products between loads.
        GenerateSampleProducts();
        CurrentUser = user;
    }
    
    private void GenerateSampleProducts()
    {
        // Create and add sample products to the Products list
        Products.Add(new Product("World Domination Axe", 10, 5));
        Products.Add(new Product("The creator of damnation, aka the cool sword", 20, 10));
        Products.Add(new Product("Bludgeon of Doom", 15, 3));
        Products.Add(new Product("CUTE KITTY :3", 5, 8));
    }

    //render the pretty header
    public void RenderHeader()
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++");
        Console.WriteLine("+++ Welcome to The Vending Machine of Doom +++");
        Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++");
        Console.ResetColor(); 
    }

    //run the vendingmachine 
    public void Run()
    {
        //code to run the vending machine.
        int command;
        do
        {
                command = GetCommand(Commands);
                //show products
                if (command == 1)
                {
                    Console.Clear(); 
                    AddProductToInventory(); 
                }
                //show inventory
                else if (command == 2)
                {
                    Console.Clear(); 
                    ShowUserInventory();
                }
                //checkout
                else if (command == 3)
                {
                    Console.Clear(); 
                    RenderHeader();
                    Checkout();
                }
        } while (command != 4);
    }

    public void ShowUserInventory()
    {
        RenderHeader();
        DisplayUserInventory();
        Console.WriteLine("Press 1 to edit Inventory or Enter to return to the main menu...");
        var userInput = Console.ReadLine();
        if (userInput == "1")
        {
            while (true){
                Console.Clear(); 
                RenderHeader();
                DisplayUserInventory();
                Console.WriteLine(
                    "Enter the number of the product you wish to Remove or Enter to go back");
                var productIndex = Console.ReadLine();
                if (productIndex == "")
                {
                    break;
                }
                var index = int.Parse(productIndex);
                CurrentUser.Inventory.RemoveFromInventory(index-1);
                            
            }
        }
    }

    public void DisplayUserInventory()
    {
        Console.WriteLine($"{CurrentUser.Name}'s Inventory" );
        RenderLine();
        if (CurrentUser.Inventory.UserProducts.Count <= 0)
        {
            Console.WriteLine("Inventory is empty, go back and add some items");
        }
        else
        {
            CurrentUser.Inventory.DisplayInventory();
            RenderLine();
            Console.WriteLine($"Total Cost: {CurrentUser.Inventory.GetTotalofInventory()}");
            
        }
    }

    public void RenderLine()
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++");
        Console.ResetColor(); 
    }

    public int GetCommand(List<string> commands)
    {
        while (true)
        {
            Console.Clear();
            RenderHeader();
            
            Console.WriteLine("Choose your command by number: ");
            DisplayCommands(commands);
            var input = Console.ReadLine();
            try
            {
                int inputNumber = int.Parse(input);
                if (inputNumber >= 1 && inputNumber <= commands.Count)
                {
                    return inputNumber;
                }
                else
                {
                    Console.WriteLine("Invalid command. Please enter a number between 1 and the number of commands.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
        }
    }

    public void DisplayCommands(List<string> commands)
    {
        int i = 1;
        foreach (var command in commands)
        {
            Console.WriteLine(command);
            i++; 
        }
    }
    public void DisplayProducts()
    {
        int i = 1; // Initialize the iterator variable
        Console.WriteLine("Products Available Today:");
        foreach (var product in Products)
        {
            Console.WriteLine($"+++ {i}. {product.Name} ${product.Price} -- {product.Quantity} left");
            i++; 
        }
    }

    public void Checkout()
    {
        DisplayUserInventory();
        var balance = CurrentUser.Account.CheckBalance();
        var total = CurrentUser.Inventory.GetTotalofInventory();
        if ( balance >= total && CurrentUser.Inventory.CountInventory() > 0)
        {
            Console.WriteLine("Would you like to check out? (yes/no)");
            var input = Console.ReadLine();
            if (input.ToLower() == "yes"){
                Console.WriteLine($"Your balance is: {balance}");
                Console.WriteLine($"The total is: {total}");
                Console.WriteLine($"You will have {balance - total} left in your account, proceed? (yes/no)");
                var confirmationInput = Console.ReadLine();
                if (confirmationInput.ToLower() == "yes")
                {
                    CurrentUser.Account.DeductFromBalance(total);
                    CurrentUser.Inventory.EmptyInventory();
                    Console.WriteLine("Completed!");
                    Console.WriteLine("Press Enter to return");
                    Console.ReadLine();
                }
            }
        }
        else
        {
            //to do: would have been nice to have a way to display a different error message....
            Console.WriteLine("Sorry you don't have enough for that purchase or your inventory is empty!");
            Console.WriteLine("Press Enter to return");
            Console.ReadLine();
        }
    }

    public bool CheckProduct(int productIndex)
    {
        //check if the product Index the user selected exists in the list
        if (Products.Count <= productIndex-1)
        {
            return true;
        }

        return false;
    }
    

    public bool AddProduct(Product product)
    {
        //check if quantity is high enough
        if (product.Quantity < 1)
        {
            return false;
        }
        else
        {
            CurrentUser.Inventory.AddToInventory(product);
            product.Quantity--;
            return true;
        }
    }

    public void AddProductToInventory()
    {
        bool continueAdding = true; // Variable to track whether to continue adding products
        while (continueAdding)
        {   
            Console.Clear();
            RenderHeader();
            DisplayProducts();
            Console.WriteLine("add a product by entering its index number.");
            Console.WriteLine("Or press enter to exit:");
            var input = Console.ReadLine();
            //if the user enters an empty string, break the loop
            if (input == "")
            {
                break;
            }
            //check that the input number is within the lists options
            try
            {
                int inputNumber = int.Parse(input);
                if (inputNumber >= 1 && inputNumber <= Products.Count)
                {
                    Console.WriteLine(
                        $"{inputNumber} chosen, attempting to add {Products[inputNumber - 1].Name} to your inventory");
                    //check if the product can be added or not,
                    if (AddProduct(Products[inputNumber - 1]))
                    {
                        Console.WriteLine("Added Successfully");
                    }
                    else
                    {
                        Console.WriteLine("There are too few products available");
                    }
                }
                else
                {
                    Console.WriteLine($"Invalid Product. Please enter a number between 1 and {Products.Count}.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter a valid integer.");
            }
            // Ask user whether to continue adding products
            Console.WriteLine("Do you want to add another product? (yes/no)");
            string continueInput = Console.ReadLine();
            continueAdding = (continueInput.ToLower() == "yes"); 
        }
    }
}