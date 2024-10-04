using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectProductsListClassLinq
{
    internal class MainLoop
    {
        public static void Loop(ProductList productList)
        {
            string category = "";
            string productName = "";
            int price = 0;
            bool exitLoop = false;

            while (!exitLoop)
            {
                Message.GenerateMessage("Add a new product | Q to quit.", "Header");
                //Category
                while (true && !exitLoop)
                {
                    Console.Write("Product category: ");
                    string userInput = Console.ReadLine();
                    if (userInput.ToLower() == "q") { exitLoop = true; break; }
                    //Control input
                    if (Validator.ValidateInputString(userInput))
                    {
                        category = userInput.ToUpper();
                        break;
                    }
                    else Message.GenerateMessage("Not correct input. Write a category, use only letters.", "Error");
                }

                //Product name
                while (true && !exitLoop)
                {
                    Console.Write("Product name: ");
                    string userInput = Console.ReadLine();
                    if (userInput.ToLower() == "q") { exitLoop = true; break; }
                    //Control input
                    if (Validator.ValidateInputString(userInput))
                    {
                        productName = userInput.ToUpper();
                        break;
                    }
                    else Message.GenerateMessage("Not correct input. Write a product name, use only letters.", "Error");
                }

                //Price
                while (true && !exitLoop)
                {
                    Console.Write("Price: ");
                    string userInput = Console.ReadLine();
                    if (userInput.ToLower() == "q") { exitLoop = true; break; }
                    //Control input
                    if (Validator.ValidateInputPrice(userInput))
                    {
                        price = int.Parse(userInput);
                        break;
                    }
                    else Message.GenerateMessage("Not correct input. Write a price, only whole numbers.", "Error");
                }

                //Creating a new Product, adding it to sproductList
                if (!exitLoop)
                {
                    Product newProduct = new Product(category, productName, price);
                    productList.AddProduct(newProduct);
                }
                Message.GenerateMessage("--------------------------------------", "Divider");
            }
            //Display productList
            productList.DisplaySortedList(true, "");
            //Give user choice to continue. Attaching current productList
            ContinueProgram.AskingUser(productList);
        }
    }
}
