using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace LogPass
{
    class CreateAccount
    {
        private string name;
        private string surName;
        private string userName;
        private string password;
        private string email;

        public CreateAccount(string name, string surName, string email, string userName, string password)
        {
            Name = name;
            SurName = surName;
            UserName = userName;
            Password = password;
            Email = email;
            NewMethod();
        }

        private void NewMethod()
        {
            Console.WriteLine("Thank you for your registration");
            string writePath = @"C:\LogPass\some.txt";
            try
            {
                using (StreamWriter sw = new StreamWriter(writePath, true, Encoding.Default))
                {
                    sw.WriteLine(this.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public string Name { get => name; set => name = value; }
        public string SurName { get => surName; set => surName = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public string Email { get => email; set => email = value; }

        public override string ToString()
        {
            return userName + " " + Password + " " + SurName + " " + Name +" " + Email;
        }




    }
}
