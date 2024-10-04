using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectProductsListClassLinq
{
    //Validate user input, string or int
    internal class Validator
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
}

