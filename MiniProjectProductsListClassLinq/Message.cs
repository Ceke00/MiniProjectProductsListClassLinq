using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniProjectProductsListClassLinq
{
    //Printing messages in different colors.
    internal class Message
    {
        public static void GenerateMessage(string message, string type)
        {
            switch (type)
            {
                case "Error": Console.ForegroundColor = ConsoleColor.Red; break;
                case "Success": Console.ForegroundColor = ConsoleColor.Green; break;
                case "Divider": Console.ForegroundColor = ConsoleColor.Yellow; break;
                case "Header": Console.ForegroundColor = ConsoleColor.Cyan; break;
                case "TableHeader": Console.ForegroundColor = ConsoleColor.Blue; break;
            }
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
