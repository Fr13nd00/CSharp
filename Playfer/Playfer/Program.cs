using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playfer
{
    class Program
    {
        private static int Mod(int a, int b)
        {
            return (a % b + b) % b;
        }

        private static List<int> FindAllOccurrences(string str, char value)
        {
            List<int> indexes = new List<int>();

            int index = 0;
            while ((index = str.IndexOf(value, index)) != -1)
                indexes.Add(index++);

            return indexes;
        }

        private static string RemoveAllDuplicates(string str, List<int> indexes)
        {
            string retVal = str;

            for (int i = indexes.Count - 1; i >= 1; i--)
                retVal = retVal.Remove(indexes[i], 1);

            return retVal;
        }

        private static char[,] GenerateKeySquare(string key)
        {
            char[,] keySquare = new char[5, 5];
            string defaultKeySquare = "ABCDEFGHIKLMNOPQRSTUVWXYZ";
            string tempKey = string.IsNullOrEmpty(key) ? "CIPHER" : key.ToUpper();

            tempKey = tempKey.Replace("J", "");
            tempKey += defaultKeySquare;

            for (int i = 0; i < 25; ++i)
            {
                List<int> indexes = FindAllOccurrences(tempKey, defaultKeySquare[i]);
                tempKey = RemoveAllDuplicates(tempKey, indexes);
            }

            tempKey = tempKey.Substring(0, 25);

            for (int i = 0; i < 25; ++i)
                keySquare[(i / 5), (i % 5)] = tempKey[i];

            return keySquare;
        }

        private static void GetPosition(ref char[,] keySquare, char ch, ref int row, ref int col)
        {
            if (ch == 'J')
                GetPosition(ref keySquare, 'I', ref row, ref col);

            for (int i = 0; i < 5; ++i)
                for (int j = 0; j < 5; ++j)
                    if (keySquare[i, j] == ch)
                    {
                        row = i;
                        col = j;
                    }
        }

        private static char[] SameRow(ref char[,] keySquare, int row, int col1, int col2, int encipher)
        {
            return new char[] { keySquare[row, Mod((col1 + encipher), 5)], keySquare[row, Mod((col2 + encipher), 5)] };
        }

        private static char[] SameColumn(ref char[,] keySquare, int col, int row1, int row2, int encipher)
        {
            return new char[] { keySquare[Mod((row1 + encipher), 5), col], keySquare[Mod((row2 + encipher), 5), col] };
        }

        private static char[] SameRowColumn(ref char[,] keySquare, int row, int col, int encipher)
        {
            return new char[] { keySquare[Mod((row + encipher), 5), Mod((col + encipher), 5)], keySquare[Mod((row + encipher), 5), Mod((col + encipher), 5)] };
        }

        private static char[] DifferentRowColumn(ref char[,] keySquare, int row1, int col1, int row2, int col2)
        {
            return new char[] { keySquare[row1, col2], keySquare[row2, col1] };
        }

        private static string RemoveOtherChars(string input)
        {
            string output = input;

            for (int i = 0; i < output.Length; ++i)
                if (!char.IsLetter(output[i]))
                    output = output.Remove(i, 1);

            return output;
        }

        private static string AdjustOutput(string input, string output)
        {
            StringBuilder retVal = new StringBuilder(output);

            for (int i = 0; i < input.Length; ++i)
            {
                if (!char.IsLetter(input[i]))
                    retVal = retVal.Insert(i, input[i].ToString());

                if (char.IsLower(input[i]))
                    retVal[i] = char.ToLower(retVal[i]);
            }

            return retVal.ToString();
        }

        private static string Cipher(string input, string key, bool encipher)
        {
            string retVal = string.Empty;
            char[,] keySquare = GenerateKeySquare(key);
            string tempInput = RemoveOtherChars(input);
            int e = encipher ? 1 : -1;

            if ((tempInput.Length % 2) != 0)
                tempInput += "X";

            for (int i = 0; i < tempInput.Length; i += 2)
            {
                int row1 = 0;
                int col1 = 0;
                int row2 = 0;
                int col2 = 0;

                GetPosition(ref keySquare, char.ToUpper(tempInput[i]), ref row1, ref col1);
                GetPosition(ref keySquare, char.ToUpper(tempInput[i + 1]), ref row2, ref col2);

                if (row1 == row2 && col1 == col2)
                {
                    retVal += new string(SameRowColumn(ref keySquare, row1, col1, e));
                }
                else if (row1 == row2)
                {
                    retVal += new string(SameRow(ref keySquare, row1, col1, col2, e));
                }
                else if (col1 == col2)
                {
                    retVal += new string(SameColumn(ref keySquare, col1, row1, row2, e));
                }
                else
                {
                    retVal += new string(DifferentRowColumn(ref keySquare, row1, col1, row2, col2));
                }
            }

            retVal = AdjustOutput(input, retVal);

            return retVal;
        }

        public static string Encipher(string input, string key)
        {
            return Cipher(input, key, true);
        }

        public static string Decipher(string input, string key)
        {
            return Cipher(input, key, false);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("For Enciper press e , for Decipher pres d");
            char c = Console.ReadLine()[0];
            if (c == 'e')
            {
                Console.WriteLine("          ---Enciper---");
                Console.Write("Enter Text : ");
                string Text = Console.ReadLine();
                Console.Write("Enter Key : ");
                string Key = Console.ReadLine();
                string PlainText = Playfair.Prepare(Text);
                Console.WriteLine("Plain Text : " + PlainText);
                List<char> NewKey = Algoritm.NewKey(Key);
                char[] ch = NewKey.ToArray();
                Key = "";
                foreach (char item in ch)
                {
                    Key += item;
                }
                Console.WriteLine("Enciper : " + Playfair.Encipher(Key, PlainText));
            }
            else if (c == 'd')
            {
                Console.WriteLine("          ---Deciper---");
                Console.Write("Enter Text : ");
                string Text = Console.ReadLine();
                Console.Write("Enter Key : ");
                string Key = Console.ReadLine();
                List<char> NewKey = Algoritm.NewKey(Key);
                char[] ch = NewKey.ToArray();
                Key = "";
                foreach (char item in ch)
                {
                    Key += item;
                }
                Console.WriteLine("Deciper : " + Playfair.Decipher(Key, Text));
            }
        }
    }

    public class Playfair
    {

        /*
            'Prepare' removes all characters that are not letters i.e. all numbers, punctuation,
            spaces etc. are removed (uppercase is also converted to lowercase).

            If the seond letter of a pair is the same as the first letter, an 'x' is inserted.

            Also, if the length of the string is odd, an 'x' is appended to make it an even length
            as Playfair can only encrypt even length strings.

            If you want numbers, punctuation etc. you must spell it out e.g.
            'stop' for period, 'one', 'two' etc.
        */

        public static string Prepare(string originalText)
        {
            int length = originalText.Length;
            originalText = originalText.ToLower();
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                char c = originalText[i];
                if (c >= 97 && c <= 122)
                {
                    // If the second letter of a pair is the same as the first, insert an 'x' 
                    if (sb.Length % 2 == 1 && sb[sb.Length - 1] == c)
                    {
                        sb.Append('x');
                    }
                    sb.Append(c);
                }
            }

            // If the string is an odd length, append an 'x'
            if (sb.Length % 2 == 1)
            {
                sb.Append('x');
            }

            return sb.ToString();
        }

        /*
            'Encipher' uses the Playfair cipher to encipher some text.
            The key is a string containing all 26 letters in the alphabet, except one'.
        */
        public static string Encipher(string key, string plainText)
        {
            int length = plainText.Length;
            char a, b;
            int a_ind, b_ind, a_row, b_row, a_col, b_col;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < length; i += 2)
            {
                a = plainText[i];
                b = plainText[i + 1];

                a_ind = key.IndexOf(a);
                b_ind = key.IndexOf(b);
                a_row = a_ind / 5;
                b_row = b_ind / 5;
                a_col = a_ind % 5;
                b_col = b_ind % 5;

                if (a_row == b_row)
                {
                    if (a_col == 4)
                    {
                        sb.Append(key[a_ind - 4]);
                        sb.Append(key[b_ind + 1]);
                    }
                    else if (b_col == 4)
                    {
                        sb.Append(key[a_ind + 1]);
                        sb.Append(key[b_ind - 4]);
                    }
                    else
                    {
                        sb.Append(key[a_ind + 1]);
                        sb.Append(key[b_ind + 1]);
                    }
                }
                else if (a_col == b_col)
                {
                    if (a_row == 4)
                    {
                        sb.Append(key[a_ind - 20]);
                        sb.Append(key[b_ind + 5]);
                    }
                    else if (b_row == 4)
                    {
                        sb.Append(key[a_ind + 5]);
                        sb.Append(key[b_ind - 20]);
                    }
                    else
                    {
                        sb.Append(key[a_ind + 5]);
                        sb.Append(key[b_ind + 5]);
                    }
                }
                else
                {
                    sb.Append(key[5 * a_row + b_col]);
                    sb.Append(key[5 * b_row + a_col]);
                }
            }
            return sb.ToString();
        }


        /*
            'Decipher' uses the Playfair cipher to decipher some text.
            The key is a string containing all 26 letters of the alphabet, except one.
        */
        public static string Decipher(string key, string cipherText)
        {
            int length = cipherText.Length;
            char a, b;
            int a_ind, b_ind, a_row, b_row, a_col, b_col;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < length; i += 2)
            {
                a = cipherText[i];
                b = cipherText[i + 1];

                a_ind = key.IndexOf(a);
                b_ind = key.IndexOf(b);
                a_row = a_ind / 5;
                b_row = b_ind / 5;
                a_col = a_ind % 5;
                b_col = b_ind % 5;

                if (a_row == b_row)
                {
                    if (a_col == 0)
                    {
                        sb.Append(key[a_ind + 4]);
                        sb.Append(key[b_ind - 1]);
                    }
                    else if (b_col == 0)
                    {
                        sb.Append(key[a_ind - 1]);
                        sb.Append(key[b_ind + 4]);
                    }
                    else
                    {
                        sb.Append(key[a_ind - 1]);
                        sb.Append(key[b_ind - 1]);
                    }
                }
                else if (a_col == b_col)
                {
                    if (a_row == 0)
                    {
                        sb.Append(key[a_ind + 20]);
                        sb.Append(key[b_ind - 5]);
                    }
                    else if (b_row == 0)
                    {
                        sb.Append(key[a_ind - 5]);
                        sb.Append(key[b_ind + 20]);
                    }
                    else
                    {
                        sb.Append(key[a_ind - 5]);
                        sb.Append(key[b_ind - 5]);
                    }
                }
                else
                {
                    sb.Append(key[5 * a_row + b_col]);
                    sb.Append(key[5 * b_row + a_col]);
                }
            }
            return sb.ToString();
        }
    }
}



