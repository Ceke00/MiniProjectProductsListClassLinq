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

