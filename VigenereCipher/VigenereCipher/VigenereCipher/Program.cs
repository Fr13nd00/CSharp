using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VigenereCipher
{
    class Program
    {
        public static  char[,] VigenereMatrix()
        {
            char[,] table = new char[26, 26];
            char[] alphabet = {'A','B','C','D','E','F','G','H','I','J','K','L','M','N','O','P','Q','R','S','T','U','V','W','X','Y','Z'};
            int a;
            for (int i = 0; i < alphabet.Length; i++)
            {
                for (int j = 0; j < alphabet.Length; j++)
                {
                    a = i + j;
                    if (a >= alphabet.Length)
                    {
                        a = a - alphabet.Length;
                    }
                    table[i, j] = alphabet[a];
                }
            }
            return table;
        }

        public static void ShowVigenereMatrix(char[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    Console.Write(matrix[i,j] + " ");
                }
                Console.WriteLine();
            }
        }

        public static string NewKey(string key, string text)
        {
            string newKey = "";
            int j = 0;
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                    continue;
                while (j >= key.Length)
                {
                    j -= key.Length; 
                }
                if (key[j] == ' ')
                    j++;
                newKey += key[j++];
            }
            return newKey;
        }

        public static string NewText(string key, string text)
        {
            string newText = "";
            string newKey = NewKey(key, text);
            string textWidthoutSpace = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (text[i] == ' ')
                    continue;
                textWidthoutSpace += text[i];
            }
            for (int i = 0; i < newKey.Length; i++)
            {
                newText += textWidthoutSpace[i];
                newText += newKey[i];
            }
            return newText;
        }

        public static string VigenereEncrypt(string key, string textInput)
        {
            string newText = "";
            string text = NewText(key,textInput).ToUpper();
            char[,] matrix = VigenereMatrix();
            for (int k = 0; k < text.Length - 1; k++)
            {
                char first = text[k];
                char second = text[++k];
                int firstIndex = 0;
                int secondIndex = 0;
                char[] alphabet = { 'A', 'B', 'C', 'D', 'E', 'F', 'G', 'H', 'I', 'J', 'K', 'L', 'M', 'N', 'O', 'P', 'Q', 'R', 'S', 'T', 'U', 'V', 'W', 'X', 'Y', 'Z' };
                for (int i = 0; i < alphabet.Length; i++)
                {
                    if (alphabet[i] == first)
                        secondIndex = i;
                    if (alphabet[i] == second)
                        firstIndex = i;
                }
                newText += matrix[secondIndex, firstIndex];
            }
            return newText;
        }

        public static string VigenereDecrypt(string key, string textInput)
        {
            string newText = "";
            string text = NewText(key, textInput).ToUpper();
            char[,] matrix = VigenereMatrix();
            for (int k = 0; k < text.Length - 1; k++)
            {
                char first = text[k];
                char second = text[++k];
                int firstIndex = 0;
                int secondIndex = 0;
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        if (matrix[i, 0] == second)
                        {
                            firstIndex = i;
                            if (matrix[firstIndex, j] == first)
                                secondIndex = j;
                        }
                        else 
                            
                            break;
                    }
                }
                newText += matrix[0, secondIndex];
            }
            return newText;
        }

        static void Main(string[] args)
        {
            //Console.ForegroundColor = ConsoleColor.DarkRed;
            //Console.WriteLine("Vigenere Miatrix:");
            //Console.ResetColor();
            ShowVigenereMatrix(VigenereMatrix());
            Console.WriteLine("For Enciper press e , for Decipher pres d");
            char c = Console.ReadLine()[0];
            if (c == 'e')
            {
                Console.WriteLine("          ---Enciper---");
                Console.Write("Enter Text : ");
                string Text = Console.ReadLine();
                Console.Write("Enter Key : ");
                string Key = Console.ReadLine();
                Console.WriteLine(NewKey(Key, Text));
                Console.WriteLine(NewText(Key, Text));
                Console.WriteLine("Enciper : " + VigenereEncrypt(Key, Text).ToLower());

            }
            else if (c == 'd')
            {
                Console.WriteLine("          ---Deciper---");
                Console.Write("Enter Text : ");
                string Text = Console.ReadLine();
                Console.Write("Enter Key : ");
                string Key = Console.ReadLine();
                Console.WriteLine(NewKey(Key, Text));
                Console.WriteLine(NewText(Key, Text));
                Console.WriteLine("Deciper : " + VigenereDecrypt(Key, Text).ToLower());
            }
            

         
        }
    }
}
