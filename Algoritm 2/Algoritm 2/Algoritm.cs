using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algoritm_2
{
    static class Algoritm
    {
        public static string Codint(string text , string key)
        {
            List<char> used = NewKey(key);
            List<char> Original = new List<char>();
            for (int i = 'a'; i < ('z') + 1; i++)
            {
                Original.Add((char)i);
            }
            string result = "";
            for (int i = 0; i < text.Length; i++)
            {
                if(Original.IndexOf(text[i]) != -1)
                {
                    result += used[Original.IndexOf(text[i])];
                }
                else
                {
                    result += text[i];
                }
            }
            return result;

        }

        private static List<char> NewKey(string key)
        {
            string s = key.ToLower();
            List<char> used = new List<char>();
            foreach (char i in s)
            {
                if (used.IndexOf(i) == -1 && i != ' ')
                {
                    used.Add(i);
                }
            }
            for (int i = 'a'; i < ('z') + 1; i++)
            {
                if (used.IndexOf((char)i) == -1)
                {
                    used.Add((char)i);
                }
            }
            return used;
        }

        public static string DeCoding(string text , string key)
        {
            List<char> used = NewKey(key);
            List<char> Original = new List<char>();
            for (int i = 'a'; i < ('z') + 1; i++)
            {
                Original.Add((char)i);
            }
            string result = "";
            for (int i = 0; i < text.Length; i++)
            {
                if (used.IndexOf(text[i]) != -1)
                {
                    result += Original[used.IndexOf(text[i])];
                }
                else
                {
                    result += text[i];
                }
            }
            return result;
        }
    }
}
