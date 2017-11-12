using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playfer
{
    class Algoritm
    {


        public static List<char> NewKey(string key)
        {
            string s = key.ToLower();
            List<char> used = new List<char>();
            foreach (char i in s)
            {
                if(i == 'j')
                {
                    if (used.IndexOf('i') == -1 )
                    {

                        used.Add('i');
                    }
                }
                else if (used.IndexOf(i) == -1 && i != ' ')
                {
                    
                    used.Add(i);
                }
            }
            for (int i = 'a'; i < ('z') + 1; i++)
            {
                if (used.IndexOf((char)i) == -1 && i != 'j')
                {
                    used.Add((char)i);
                }
            }
            foreach (var item in used)
            {
             //   Console.Write(item);
            }
            return used;
        }
    }
}
