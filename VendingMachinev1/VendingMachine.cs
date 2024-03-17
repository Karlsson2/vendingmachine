namespace VendingMachinev1;



public class VendingMachine
{
    public List<Product> Products;
    public User currentUser;
    
    public List<string> Commands { get; } = new List<string>
    {
        "1. Show products",
        "2. Show inventory",
        "3. Check Out",
        "4. Quit"
   
    };
    public List<string> ProductCommands { get; } = new List<string>
    {
        "1. Add Product",
        "2. Back to Main Menu"
   
    };
    
 

    public VendingMachine(User user)
    {
        Products = new List<Product>();
        //maybe implement a "document reading" property to store the products between loads.
        GenerateSampleProducts();
        currentUser = user;
    }
    
    private void GenerateSampleProducts()
    {
        // Create and add sample products to the Products list
        Products.Add(new Product("Product 1", 10, 5));
        Products.Add(new Product("Product 2", 20, 10));
        Products.Add(new Product("Product 3", 15, 3));
        Products.Add(new Product("Product 4", 5, 8));
    }

    public void RenderHeader()
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.ForegroundColor = ConsoleColor.DarkMagenta;
        Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++");
        Console.WriteLine("+++ Welcome to The Vending Machine of Doom +++");
        Console.WriteLine("++++++++++++++++++++++++++++++++++++++++++++++");
        Console.ResetColor(); 
    }

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
                    Console.Clear(); // Clear the console
                    RenderHeader();
                    Console.WriteLine("Display the user inventory");
                    if (currentUser.Inventory.UserProducts.Count <= 0)
                    {
                        Console.WriteLine("Inventory is empty, go back and add some items");
                        Console.WriteLine("Press Enter to return to the main menu...");
                        Console.ReadLine(); // Wait for user input
                    }
                    else
                    {
                        currentUser.Inventory.DisplayInventory();

                    }
                }
                else if (command == 3)
                {
                    //checkout
                    Console.WriteLine("check out");
                }
        } while (command != 4);
        
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
                    Console.WriteLine($"{inputNumber} chosen, rerouting you to Command {commands[inputNumber-1]}");
                    Console.WriteLine();
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

    public bool CheckProduct(int productIndex)
    {
        //check if the product Index the user selected exists in the list
        if (Products.Count <= productIndex-1)
        {
            return true;
        }

        return false;
    }

    public void removeProduct()
    {
    }

    public bool addProduct(Product product)
    {
        if (product.Quantity <= 1)
        {
            return false;
        }
        else
        {
            currentUser.Inventory.AddToInventory(product);
            product.Quantity--;
            return true;
        }
    }

    public void PurchaseProducts()
    {
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
            continueAdding = !string.IsNullOrEmpty(input);
            try
            {
                int inputNumber = int.Parse(input);
                if (inputNumber >= 1 && inputNumber <= Products.Count)
                {
                    Console.WriteLine(
                        $"{inputNumber} chosen, attempting to add {Products[inputNumber - 1].Name} to your inventory");
                    if (addProduct(Products[inputNumber - 1]))
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
            continueAdding = (continueInput.ToLower() == "yes"); // Set continueAdding based on user input
        }
    }

    
}