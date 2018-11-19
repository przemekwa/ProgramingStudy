using PetaPoco;
using System;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            var db = new Database("Data Source=.\\SQLEXPRESS;Initial Catalog=SelgrosPG;User Id=SelgrosPGLogin;Password=SelgrosPGLogin;","System.Data.SqlClient");

           
        }
    }
}
