using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data.SqlClient;

namespace LogPass
{
    class Program
    {
        static void Main(string[] args)
        {

           
            do
            {
                int n;
                Console.WriteLine("Sing In => press 1");
                Console.WriteLine("Create Account => press2");
                n = int.Parse(Console.ReadLine());
                switch (n)
                {
                    case 1:
                        {
                            Console.Clear();
                            Console.Write("Enter User Name : ");
                            string userName = Console.ReadLine();
                            // user Name
                            string path = @"C:\LogPass\some.txt";
                            List<string> str = new List<string>();
                            using (StreamReader sr = new StreamReader(path, Encoding.Default))
                            {
                                string line;
                                while ((line = sr.ReadLine()) != null)
                                {
                                    string[] temp = line.Split(' ');
                                    str.Add(temp[0]);
                                }
                            }
                            bool t = false;
                            for (int i = 0; i < str.Count; i++)
                            {
                                if (str[i] == userName)
                                    t = true;
                            }
                            if(!t)
                            {
                                Console.WriteLine("Your account does'nt exist, create new account");
                                break;
                            }
                            Console.Write("Enter Password :  ");
                            string password = "";
                            t = false;
                            while (!t)
                            {
                                str.Clear();
                                password = Console.ReadLine();
                                string path1 = @"C:\LogPass\some.txt";
                                using (StreamReader sr = new StreamReader(path1, Encoding.Default))
                                {
                                    string line;
                                    while ((line = sr.ReadLine()) != null)
                                    {
                                        string[] temp = line.Split(' ');
                                        str.Add(temp[1]);
                                    }
                                }
                                for (int i = 0; i < str.Count; i++)
                                {
                                    if (str[i] == password)
                                        t = true;
                                }
                                if (!t)
                                {
                                    Console.WriteLine("Wrong Password, try again");
                                }
                            }

                            SingIn account = new SingIn(userName, password);
                            account.info();
                            break;
                        }
                    case 2:
                        {
                            NewMethod2();

                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Wrong number");
                            break;
                        }
                }

                Console.WriteLine("Press Escape for breake or any key to continue");
            } while (Console.ReadKey().Key != ConsoleKey.Escape);


        }

        private static void NewMethod2()
        {
            Console.Clear();
            Console.Write("Enter Name : ");
            string name = Console.ReadLine();
            Console.Write("Enter SurName : ");
            string surName = Console.ReadLine();
            string email = "";
            while(true)
            {
                Console.Write("Enter Email : ");
                email = Console.ReadLine();
                if (email.Substring(email.LastIndexOf('@')) == "@mail.ru" || email.Substring(email.LastIndexOf('@')) == "@gmail.com")
                    break;
            }
            string userName = "";
            List<string> str = new List<string>();
            userName = NewMethod1(str, userName);
            string password = NewMethod();
            CreateAccount account = new CreateAccount(name, surName, email, userName, password);
        }

        private static string NewMethod1(List<string> str, string userName)
        {
            bool t = false;
            str.Clear();
            while (!t)
            {
                t = true;
                Console.Write("Enter User Name : ");
                string s = Console.ReadLine();
                if (s.Length < 4)
                {
                    t = false;
                    Console.WriteLine("Too short UserName");
                }
                if (t)
                {
                    string path = @"C:\LogPass\some.txt";
                    using (StreamReader sr = new StreamReader(path, Encoding.Default))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            string[] temp = line.Split(' ');
                            str.Add(temp[0]);
                        }
                    }
                    for (int i = 0; i < str.Count && t; i++)
                    {
                        if (s == str[i])
                        {
                            t = false;
                            Console.WriteLine("User Name Exsit, select new ");
                        }
                    }
                    if (t)
                    {
                        userName = s;
                    }
                }
            }

            return userName;
        }

        private static string NewMethod()
        {
            bool t = false;
            string password = "";
            while (!t)
            {
                Console.Write("Enter Password :  ");
                password = Console.ReadLine();
                for (int i = 0; i < password.Length; i++)
                {
                    if (password[i] >= 'A' && password[i] < 'Z' + 1)
                    {
                        t = true;
                        break;
                    }
                }
                if (t)
                {
                    t = false;
                    for (int i = 0; i < password.Length; i++)
                    {
                        if (password[i] >= 'a' && password[i] < 'z' + 1)
                        {
                            t = true;
                            break;
                        }
                    }
                }
                if (t)
                {
                    t = false;
                    for (int i = 0; i < password.Length; i++)
                    {
                        if (password[i] >= '0' && password[i] < '9' + 1)
                        {
                            t = true;
                            break;
                        }
                    }
                }
                if (t)
                {
                    t = false;
                    for (int i = 0; i < password.Length; i++)
                    {
                        if ((password[i] > (char)33 && password[i] < (char)47) || (password[i] > (char)57 && password[i] < (char)65) || (password[i] > (char)90 && password[i] < (char)97) || (password[i] > (char)123 && password[i] < (char)127))
                        {
                            t = true;
                            break;
                        }
                    }
                }
                Console.ForegroundColor = ConsoleColor.Red;
                if (password.Length < 6)
                {
                    Console.WriteLine("Too short password");
                    t = false;
                }
                if (!t)
                {
                    Console.WriteLine("weak password , try again");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Strong Password");
                }
                Console.ResetColor();

            }

            return password;
        }
    }
}

