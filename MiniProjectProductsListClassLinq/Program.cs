using MiniProjectProductsListClassLinq;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Security.Cryptography.X509Certificates;


//Program init
class Program
{
    static void Main(string[] args)
    {
        ProductList productList = new ProductList();
        MainLoop.Loop(productList);
    }
}

////Main loop with product input
//public static class MainLoop
//{
//    public static void Loop(ProductList productList)
//    {
//        string category = "";
//        string productName = "";
//        int price = 0;
//        bool exitLoop = false;

//        while (!exitLoop)
//        {
//            Message.GenerateMessage("Add a new product | Q to quit.", "Header");
//            //Category
//            while (true && !exitLoop)
//            {
//                Console.Write("Product category: ");
//                string userInput = Console.ReadLine();
//                if (userInput.ToLower() == "q") { exitLoop = true; break; }
//                //Control input
//                if (Validator.ValidateInputString(userInput))
//                {
//                    category = userInput.ToUpper();
//                    break;
//                }
//                else Message.GenerateMessage("Not correct input. Write a category, use only letters.", "Error");
//            }

//            //Product name
//            while (true && !exitLoop)
//            {
//                Console.Write("Product name: ");
//                string userInput = Console.ReadLine();
//                if (userInput.ToLower() == "q") { exitLoop = true; break; }
//                //Control input
//                if (Validator.ValidateInputString(userInput))
//                {
//                    productName = userInput.ToUpper();
//                    break;
//                }
//                else Message.GenerateMessage("Not correct input. Write a product name, use only letters.", "Error");
//            }

//            //Price
//            while (true && !exitLoop)
//            {
//                Console.Write("Price: ");
//                string userInput = Console.ReadLine();
//                if (userInput.ToLower() == "q") { exitLoop = true; break; }
//                //Control input
//                if (Validator.ValidateInputPrice(userInput))
//                {
//                    price = int.Parse(userInput);
//                    break;
//                }
//                else Message.GenerateMessage("Not correct input. Write a price, only whole numbers.", "Error");
//            }

//            //Creating a new Product, adding it to sproductList
//            if (!exitLoop)
//            {
//                Product newProduct = new Product(category, productName, price);
//                productList.AddProduct(newProduct);
//            }
//            Message.GenerateMessage("--------------------------------------", "Divider");
//        }
//        //Display productList
//        productList.DisplaySortedList(true, "");
//        //Give user choice to continue. Attaching current productList
//        ContinueProgram.AskingUser(productList);
//    }
//}

////User choose if and how to continue program.
//public static class ContinueProgram
//{
//    public static void AskingUser(ProductList productList)
//    {
//        bool correctInput = false;
//        do
//        {
//            Message.GenerateMessage("-----------------------------------------------------------------", "Divider");
//            Message.GenerateMessage("| Enter a new product (P) | Search for a product (S) | Quit (Q) |", "Divider");
//            Message.GenerateMessage("-----------------------------------------------------------------", "Divider");
//            string inputUser = Console.ReadLine();
//            correctInput = Validator.ValidateInputString(inputUser);
//            if (correctInput && inputUser.ToLower() == "p") { MainLoop.Loop(productList); break; }

//            else if (correctInput && inputUser.ToLower() == "s")
//            {
//                var response = productList.SearchProduct();
//                bool found = response.Item1;
//                string foundProduct = response.Item2;

//                if (found)
//                {
//                    productList.DisplaySortedList(found, foundProduct); break;
//                }
//                else { ContinueProgram.AskingUser(productList); }
//            }
//            else if (correctInput && inputUser.ToLower() == "q") break;
//            else correctInput = false; Message.GenerateMessage("Only P, S or Q!", "Error");
//        } while (!correctInput);
//    }
//}

//Printing messages in different colors.
//public static class Message
//{
//    public static void GenerateMessage(string message, string type)
//    {
//        switch (type)
//        {
//            case "Error": Console.ForegroundColor = ConsoleColor.Red; break;
//            case "Success": Console.ForegroundColor = ConsoleColor.Green; break;
//            case "Divider": Console.ForegroundColor = ConsoleColor.Yellow; break;
//            case "Header": Console.ForegroundColor = ConsoleColor.Cyan; break;
//            case "TableHeader": Console.ForegroundColor = ConsoleColor.Blue; break;
//        }
//        Console.WriteLine(message);
//        Console.ResetColor();
//    }
//}

////Validate user input, string or int
//public static class Validator
//{
//    //Control if string is empty or contains invalid chars(non-letters)
//    public static bool ValidateInputString(string inputString)
//    {
//        if (string.IsNullOrEmpty(inputString) || !inputString.All(char.IsLetter)) return false;
//        else return true;
//    }
//    //Control if string is empty or cannot be parsed to int
//    public static bool ValidateInputPrice(string inputPrice)
//    {
//        if (string.IsNullOrEmpty(inputPrice) || !int.TryParse(inputPrice, out int price)) return false;
//        else return true;
//    }
//}

//public class Product
//{
//    public Product(string category, string name, int price)
//    {
//        Category = category;
//        Name = name;
//        Price = price;
//    }

//    public string Category { get; set; }
//    public string Name { get; set; }
//    public int Price { get; set; }
//}


//public class ProductList
//{
//    List<Product> Products { get; set; }

//    public ProductList()
//    {
//        Products = new List<Product>();
//    }

//    //add Product to list
//    public void AddProduct(Product product)
//    {
//        Products.Add(product);
//        Message.GenerateMessage("The product was added !", "Success");
//    }

//    //Sorting by price
//    public List<Product> SortList()
//    {
//        return Products.OrderBy(prod => prod.Price).ToList();
//    }

//    //Calculating sum
//    public int TotalSum()
//    {
//        return Products.Sum(prod => prod.Price);

//    }

//    //Check if product in list
//    public (bool, string) SearchProduct()
//    {
//        Console.Write("Search Product: ");
//        string userInput = Console.ReadLine();
//        bool correctInput = Validator.ValidateInputString(userInput);
//        if (correctInput)
//        {
//            userInput = userInput.ToUpper();
//            var foundProducts = Products.Where(p => p.Name.Equals(userInput)).ToList();
//            if (foundProducts.Any()) return (true, userInput);
//            else Message.GenerateMessage(userInput + " was not found.", "Error"); return (false, "");
//        }
//        else Message.GenerateMessage("Not correct input. Try again.", "Error"); return (false, "");

//    }

//    public void DisplaySortedList(bool foundProduct = false, string userInput = "")
//    {

//        int sum = TotalSum();
//        var sortedProducts = SortList();
//        //if (showList == 1)
//        //{
//        Message.GenerateMessage("**********************************************", "Header");
//        Message.GenerateMessage("****** PRODUCT LIST (sorted by price) ********", "Header");
//        Message.GenerateMessage("**********************************************", "Header");
//        Message.GenerateMessage("Category".PadRight(20) + "Product name".PadRight(20) + "Price", "TableHeader");
//        foreach (Product product in sortedProducts)
//        {
//            if (foundProduct && product.Name.Equals(userInput))
//            {
//                Console.ForegroundColor = ConsoleColor.Yellow;
//                Console.WriteLine(product.Category.PadRight(20) + product.Name.PadRight(20) + product.Price);
//                Console.ResetColor();
//            }
//            else Console.WriteLine(product.Category.PadRight(20) + product.Name.PadRight(20) + product.Price);

//        }
//        Console.WriteLine("----------------------------------------------");
//        Console.WriteLine("TOTAL: ".PadLeft(40) + sum);
//        Message.GenerateMessage("**********************************************", "Header");
//        // }
//        // showList = 0;
//        ContinueProgram.AskingUser(this);
//    }
//}

