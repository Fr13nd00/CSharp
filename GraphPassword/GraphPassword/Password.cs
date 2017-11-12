using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace GraphPassword
{
    class Password
    {
        public static Random rand = new Random();
        public string PASSWORD { get; set; }
        public Password(string password)
        {
            PASSWORD = password;
        }
        List<char> Symbols= new List<char>();
        List<char> PassSymbols = new List<char>();
        public bool Access()
        {
            foreach (char item in PASSWORD)
            {
                PassSymbols.Add(item);
            }
            for (int i = 33; i < 126; i++)
            {
                if (PassSymbols.IndexOf((char)i) == -1)
                {
                    Symbols.Add((char)i);
                }
            }
            bool t = true;
            for (int i = 0; i < 3 && t; i++)
            {
                Thread.Sleep(500);
                List<char> colum = new List<char>();
                char[,] ch = new char[5, 5];
                while(colum.Count <25)
                {
                    int index = rand.Next(0, Symbols.Count);
                    if(colum.IndexOf(Symbols[index]) == -1)
                    {
                        colum.Add(Symbols[index]);
                    }
                }
                int index1 = 0;
                Console.WriteLine();
                for (int j = 0; j < ch.GetLength(0); j++)
                {
                    for (int k = 0; k < ch.GetLength(1); k++)
                    {
                        ch[j, k] = colum[index1];
                        index1++;
                    }
                }
                List<char> list = new List<char>();
                while(list.Count < 3)
                {
                    int l = rand.Next(0, 10);
                    if (list.IndexOf(PassSymbols[l]) == -1)
                        list.Add(PassSymbols[l]);
                }
                ch[rand.Next(0, 2), rand.Next(0, 5)] = list[0];
                ch[2, rand.Next(0, 5)] = list[1];
                ch[rand.Next(3, 5), rand.Next(0, 5)] = list[2];
                for (int j = 0; j < ch.GetLength(0); j++)
                {
                    for (int k = 0; k < ch.GetLength(1); k++)
                    {
                        Console.Write(ch[j,k] + "\t");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
                Console.WriteLine("Enter 3 characters");
                Console.Write("First : ");
                char c1 = char.Parse(Console.ReadLine());
                Console.Write("Second : ");
                char c2 = char.Parse(Console.ReadLine());
                Console.Write("Therd : ");
                char c3 = char.Parse(Console.ReadLine());

                char[] ans ={ c1, c2, c3 };
                if(ans.Length > 3)
                {
                    t = false;
                    Console.WriteLine("Wrong input");
                }
                else if (ans.Length == 3)
                {
                    for (int i1 = 0; i1 < ans.Length; i1++)
                    {
                        if (!list.Contains(ans[i1]))
                            t = false;
                        else
                            list.Remove(ans[i1]);
                    }
                }
                if (t)
                    Console.WriteLine("Correct");
                else
                    Console.WriteLine("Wrong");
            }

            return t;
        }
    }
}
