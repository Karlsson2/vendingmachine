namespace VendingMachinev1;

public class Inventory
{
    public List<Product> UserProducts { get; }

    public Inventory()
    {
        UserProducts = new List<Product>(); 
    }

    //add products to the inventory list
    public void AddToInventory(Product product)
    {
        UserProducts.Add(product);
    }
    //remove products from the inventory list
    public void RemoveFromInventory(int index)
    {
        if (index >= 0 && index < UserProducts.Count)
        {
            UserProducts.RemoveAt(index);
        }
    }
    //caluclate the total price of the inventory list
    public int GetTotalofInventory()
    {
        var total = 0;
        foreach (var product in UserProducts)
        {
            total += product.Price;
        }
        return total;
    }

    public int CountInventory()
    {
        return UserProducts.Count;
    }

    //show all the products in the inventory
    public void DisplayInventory()
    {
        var counter = 1;
        foreach (var product in UserProducts)
        {
            Console.WriteLine($"{counter}. {product.Name}");
            counter++;
        }
    }
    //clear the inventory of products
    public void EmptyInventory()
    {
      UserProducts.Clear();  
    }

}