using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GraphPassword
{
    class Program
    {
        static void Main(string[] args)
        {
            string password = "1234567890";
            do
            {
                bool t = true;
                while (t)
                {
                    Console.Write("Enter your password : ");
                    password = Console.ReadLine();
                    t = false;
                    if (password.Length != 10)
                    {
                        t = true;
                        Console.WriteLine("must be 10 symbols");
                    }
                    for (int i = 0; i < password.Length && !t; i++)
                    {
                        for (int j = i + 1; j < password.Length && !t; j++)
                        {
                            if (password[i] == password[j])
                            {
                                Console.WriteLine("don't repeat symbols");
                                t = true;
                            }
                        }
                    }

                }
                Password pas = new Password(password);
                if(pas.Access())
                {
                    Console.WriteLine("Access");
                }
                else
                    Console.WriteLine("Wrong Password");
                Console.WriteLine("Press Enter For continue");
            }
            while (Console.ReadKey().Key == ConsoleKey.Enter);
        }
    }
}
