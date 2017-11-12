using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritm_2
{
    class Program
    {
        static void Main(string[] args)
        {
            do
            {
                int n;
                Console.WriteLine("Enter 1 for coding, 2 for decoding");
                n = int.Parse(Console.ReadLine());
                if(n==1)
                {
                    Console.Write("Enter Text : ");
                    string text = Console.ReadLine();
                    Console.WriteLine("Enter Key : ");
                    string key = Console.ReadLine();
                    Console.WriteLine(Algoritm.Codint(text , key));

                }
                else if(n == 2)
                {
                    Console.Write("Enter Text : ");
                    string text = Console.ReadLine();
                    Console.WriteLine("Enter Key : ");
                    string key = Console.ReadLine();
                    Console.WriteLine(Algoritm.DeCoding(text , key));
                }
                Console.WriteLine("Press Enter for continue");
            } while (Console.ReadKey().Key == ConsoleKey.Enter);

        }
    }
}
