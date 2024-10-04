using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectProductsListClassLinq
{
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

        //Sorting by price
        public List<Product> SortList()
        {
            return Products.OrderBy(prod => prod.Price).ToList();
        }

        //Calculating sum
        public int TotalSum()
        {
            return Products.Sum(prod => prod.Price);

        }

        //Check if product in list
        public (bool, string) SearchProduct()
        {
            Console.Write("Search Product: ");
            string userInput = Console.ReadLine();
            bool correctInput = Validator.ValidateInputString(userInput);
            if (correctInput)
            {
                userInput = userInput.ToUpper();
                var foundProducts = Products.Where(p => p.Name.Equals(userInput)).ToList();
                if (foundProducts.Any()) return (true, userInput);
                else Message.GenerateMessage(userInput + " was not found.", "Error"); return (false, "");
            }
            else Message.GenerateMessage("Not correct input. Try again.", "Error"); return (false, "");

        }

        public void DisplaySortedList(bool foundProduct = false, string userInput = "")
        {

            int sum = TotalSum();
            var sortedProducts = SortList();
            //if (showList == 1)
            //{
            Message.GenerateMessage("**********************************************", "Header");
            Message.GenerateMessage("****** PRODUCT LIST (sorted by price) ********", "Header");
            Message.GenerateMessage("**********************************************", "Header");
            Message.GenerateMessage("Category".PadRight(20) + "Product name".PadRight(20) + "Price", "TableHeader");
            foreach (Product product in sortedProducts)
            {
                if (foundProduct && product.Name.Equals(userInput))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(product.Category.PadRight(20) + product.Name.PadRight(20) + product.Price);
                    Console.ResetColor();
                }
                else Console.WriteLine(product.Category.PadRight(20) + product.Name.PadRight(20) + product.Price);

            }
            Console.WriteLine("----------------------------------------------");
            Console.WriteLine("TOTAL: ".PadLeft(40) + sum);
            Message.GenerateMessage("**********************************************", "Header");
            // }
            // showList = 0;
            ContinueProgram.AskingUser(this);
        }
    }
}
