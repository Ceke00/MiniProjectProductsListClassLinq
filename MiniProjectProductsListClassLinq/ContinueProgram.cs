using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MiniProjectProductsListClassLinq
{
    //User choose if and how to continue program
    internal class ContinueProgram
    {
        public static void AskingUser(ProductList productList)
        {
            bool correctInput = false;
            do
            {
                Message.GenerateMessage("-----------------------------------------------------------------", "Divider");
                Message.GenerateMessage("| Enter a new product (P) | Search for a product (S) | Quit (Q) |", "Divider");
                Message.GenerateMessage("-----------------------------------------------------------------", "Divider");
                string inputUser = Console.ReadLine();
                correctInput = Validator.ValidateInputString(inputUser);
                if (correctInput && inputUser.ToLower() == "p") { MainLoop.Loop(productList); break; }

                else if (correctInput && inputUser.ToLower() == "s")
                {
                    var response = productList.SearchProduct();
                    bool found = response.Item1;
                    string foundProduct = response.Item2;

                    if (found)
                    {
                        productList.DisplaySortedList(found, foundProduct); break;
                    }
                    else { ContinueProgram.AskingUser(productList); }
                }
                else if (correctInput && inputUser.ToLower() == "q") break;
                else correctInput = false; Message.GenerateMessage("Only P, S or Q!", "Error");
            } while (!correctInput);
        }
    }
}
