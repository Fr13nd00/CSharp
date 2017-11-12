using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DistributionOfData
{
    class Program
    {
        public static Random rand = new Random();
        public static string ToBinary(int number)
        {
            string binary = Convert.ToString(number, 2);
            return binary;
        }

        public static string[] CreateRandoms(string binary, int distribution)
        {
            string[] randoms = new string[distribution - 1];
            for (int i = 0; i < distribution - 1; i++)
            {
                randoms[i] = "";
                for (int j = 0; j < binary.Length; j++)
                {
                    randoms[i] += rand.Next(0,2);
                }
            }
            return randoms;
        }

        public static string XorForFinal(string[] randoms, int number)
        {
            int final = number; 
            for (int i = 0; i < randoms.Length; i++)
            {
                int dec = Convert.ToInt32(randoms[i], 2);
                final ^= dec;
            }
            return ToBinary(final);
        }

        public static string[] CreateArray(int number, int distribution)
        {
            string[] newArray = new string[distribution];
            string[]randoms = CreateRandoms(ToBinary(number),distribution);
            string final = XorForFinal(randoms,number);
            for (int i = 0; i < distribution - 1; i++)
            {
                newArray[i] = randoms[i];
            }
            newArray[distribution - 1] = final;
            return newArray;
        }

        public static void ShowArray(string[] newArray)
        {
            for (int i = 0; i < newArray.Length; i++)
            {
                Console.WriteLine("S" + (i + 1) + ": " + newArray[i]);
            }
        }

        public static string CalculateS(string[] newArray)
        {
            int s =Convert.ToInt32(newArray[0], 2);
            for (int i = 1; i < newArray.Length; i++)
            {
                s ^= Convert.ToInt32(newArray[i], 2);
            }
            return ToBinary(s);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Enter Number:");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("\nEnter Count Of Distribution:");
            int distribution = int.Parse(Console.ReadLine());
            Console.WriteLine("\nBinary Number:\n" + ToBinary(number));
            Console.WriteLine("\nDistributions:");
            ShowArray(CreateArray(number, distribution));
            Console.WriteLine("\nBinary Number After XOR:");
            Console.WriteLine(CalculateS(CreateArray(number, distribution)));
        }
    }
}
