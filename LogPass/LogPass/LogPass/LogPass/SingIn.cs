using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LogPass
{
    class SingIn
    {
        private string userName;
        private string password;

        public SingIn(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }

        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }

        public void info()
        {
            Console.WriteLine("Personal Info");
            string path = @"C:\LogPass\some.txt";
            try
            {
                using (StreamReader sr = new StreamReader(path, Encoding.Default))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] temp = line.Split(' ');
                        if (temp[0] == userName)
                        {
                            Console.WriteLine(temp[2] + "\t" + temp[3]);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
