using System.ComponentModel;
using System.Security.Cryptography.X509Certificates;

class Program
{
    static void Main(string[] args)
    {
        ProductList pl = new ProductList();
        MainLoop mainLoop = new MainLoop();
        mainLoop.Loop(pl);
    }
}

public class MainLoop
{
    public void Loop(ProductList productList)
    {
        string category = "";
        string productName = "";
        int price = 0;
        bool exitLoop = false;

        while (!exitLoop)
        {
            Message.GenerateMessage("Add a new product or write Q to quit.", "Header");
            while (true && !exitLoop)
            {
                //reading input
                Console.Write("Product category: ");
                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "q") { exitLoop = true; break; }
                //Control input

                if (Validator.ValidateInputString(userInput))
                {
                   
                    category = userInput.ToUpper();
                    break;
                }
                else
                {
                    Message.GenerateMessage("Not correct input. Write a category, use only letters.", "Error");
                };
            }

            while (true && !exitLoop)
            {
                //reading input
                Console.Write("Product name: ");
                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "q") { exitLoop = true; break; }
                //Control input
                if (Validator.ValidateInputString(userInput))
                {
                    productName = userInput.ToUpper();
                    break;
                }
                else
                {
                    Message.GenerateMessage("Not correct input. Write a product name, use only letters.", "Error");
                };
            }

            while (true && !exitLoop)
            {
                //reading input
                Console.Write("Price: ");
                string userInput = Console.ReadLine();
                if (userInput.ToLower() == "q") { exitLoop = true; break; }
                //Control input
                if (Validator.ValidateInputPrice(userInput))
                {
                    price = int.Parse(userInput);
                    break;
                }
                else
                {
                    Message.GenerateMessage("Not correct input. Write a price, only whole numbers.", "Error");
                };
            }

            if (!exitLoop)
            {
                Product newProduct = new Product(category, productName, price);
                productList.AddProduct(newProduct);
            }
            Message.GenerateMessage("--------------------------------------", "Divider");
        }

        productList.DisplaySortedList();
        ContinueProgram continueProgram = new ContinueProgram();
        continueProgram.AskingUser(productList);
    }
}


public class ContinueProgram
{
    public void AskingUser(ProductList productList)
    {
        bool correctInput = false;
        do
        {
            Console.WriteLine("Enter a new product (P) | Search for a product (S) | Quit (Q)");
            string inputUser = Console.ReadLine();
            correctInput = Validator.ValidateInputString(inputUser);
            if (correctInput && inputUser.ToLower() == "p")
            {
                MainLoop mainLoop = new MainLoop();
                mainLoop.Loop(productList);
                break;
            }
            else if (correctInput && inputUser.ToLower() == "s") { productList.DisplayListWithSearchHighlight(); break; }
            else if (correctInput && inputUser.ToLower() == "q") break;
            
            else correctInput = false; Message.GenerateMessage("Only P, S or Q!", "Error"); //if not y or n

        } while (!correctInput);
    }
}

public static class Message
{
    public static void GenerateMessage(string message, string type)
    {
        switch (type)
        {
            case "Error":

                Console.ForegroundColor = ConsoleColor.Red;
                break;

            case "Success":

                Console.ForegroundColor = ConsoleColor.Green; break;

            case "Divider": Console.ForegroundColor = ConsoleColor.Yellow; break;
            case "Header": Console.ForegroundColor = ConsoleColor.Cyan; break;

        }
        Console.WriteLine(message);
        Console.ResetColor();
    }
}

public static class Validator
{
    //Control if string is empty or contains invalid chars(non-letters)
    public static bool ValidateInputString(string inputString)
    {
        if (string.IsNullOrEmpty(inputString) || !inputString.All(char.IsLetter)) return false;
        else return true;
    }
    //Control if string is empty or cannot be parsed to int
    public static bool ValidateInputPrice(string inputPrice)
    {
        if (string.IsNullOrEmpty(inputPrice) || !int.TryParse(inputPrice, out int price)) return false;
        else return true;
    }
}

public class Product
{
    public Product(string category, string name, int price)
    {
        Category = category;
        Name = name;
        Price = price;
    }

    public string Category { get; set; }
    public string Name { get; set; }
    public int Price { get; set; }
}


public class ProductList
{
    List<Product> Products { get; set; }

    public ProductList()
    {
        Products = new List<Product>();
    }


    //add Product to list
    public void AddProduct(Product product)
    {
        Products.Add(product);
        Message.GenerateMessage("The product was added !", "Success");
    }

    public List<Product> SortList()
    {
        return Products.OrderBy(prod => prod.Price).ToList();
    }

    public int TotalSum()
    {
        return Products.Sum(prod => prod.Price);

    }

    public void DisplayListWithSearchHighlight()
    {
        int sum = TotalSum();
        var sortedProducts = SortList();
        Console.WriteLine("Search Product: ");
        string userInput=Console.ReadLine();
        bool correctInput=Validator.ValidateInputString(userInput);
        if (correctInput)
        {
            userInput = userInput.ToUpper();
           
            var foundProducts = Products.Where(p=>p.Name.Contains(userInput)).ToList();
            if (foundProducts.Any()) {
                Message.GenerateMessage("**********************************************", "Header");
                Message.GenerateMessage("****** Product List (sorted by price) ********", "Header");
                Message.GenerateMessage("**********************************************", "Header");
                Console.WriteLine("Category".PadRight(20) + "Product name".PadRight(20) + "Price");
                foreach (Product product in sortedProducts)
                {
                    if (product.Name.Contains(userInput)) {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.WriteLine(product.Category.PadRight(20) + product.Name.PadRight(20) + product.Price);
                        Console.ResetColor();
                    }
                    else Console.WriteLine(product.Category.PadRight(20) + product.Name.PadRight(20) + product.Price);

                }
                Console.WriteLine("----------------------------------------------");
                Console.WriteLine("Total: ".PadLeft(40) + sum);
            }
            else Console.WriteLine(userInput +" was not found.");
        }
        else Message.GenerateMessage("Not correct input. Try again.", "Error");
        ContinueProgram continueProgram = new ContinueProgram();
        continueProgram.AskingUser(this);
    }

    public void DisplaySortedList()
    {
        int sum = TotalSum();
        //sorting by price
        var sortedProducts = SortList();
        //printing list
        Message.GenerateMessage("**********************************************", "Header");
        Message.GenerateMessage("****** Product List (sorted by price) ********", "Header");
        Message.GenerateMessage("**********************************************", "Header");
        Console.WriteLine("Category".PadRight(20) + "Product name".PadRight(20) + "Price");
        foreach (Product product in sortedProducts)
        {
            Console.WriteLine(product.Category.PadRight(20) + product.Name.PadRight(20) + product.Price);
        }
        Console.WriteLine("----------------------------------------------");
        Console.WriteLine("Total: ".PadLeft(40) + sum);

    }
}

