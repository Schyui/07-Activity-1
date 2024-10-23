using System.Xml.Linq;
using UserNamespace;

namespace UserInformation
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Administrator administrator = new Administrator("Harvey", "111", "meow");

            
            Console.Write("Enter name: ");
            string name = Console.ReadLine().ToLower();
            Console.Write("Enter id:");
            string id = Console.ReadLine();
            Console.Write("Enter password: ");
            string password = Console.ReadLine();

            if (administrator.verifyLogin(id, password))
            {
                Console.WriteLine("Login Verified! You can now change your name and password");
                Console.Write("Enter new name: ");
                string newName = Console.ReadLine();
                Console.Write("Enter new password: ");
                string newpassword = Console.ReadLine();
                administrator.updatePassword(newpassword);
                administrator.updateAdminName(newName);
                administrator.PrintNewNameAndPass();
            }
            else {
                Console.WriteLine("Account does not exist");
            }
            
        }
    }
}
namespace UserNamespace {
    abstract class User {
        private string user_id;
        protected string user_password;

        public User(string id, string password) { 
            this.user_id = id;
            this.user_password = password;
        }
        public bool verifyLogin(string id, string password) { 
            return user_id.Equals(id) && user_password.Equals(password);
        }
        public abstract void updatePassword(string newPassword);
    }
    class Administrator:User {
        private string admin_name;
        public Administrator(string name, string id, string pass):base(id, pass) { 
            this.admin_name = name;
        }
        public override void updatePassword(string newPassword) { 
            this.user_password=newPassword;
        }
        public void updateAdminName(string name) {
            this.admin_name = name;
        }
        public void PrintNewNameAndPass() {
            Console.WriteLine($"New name: {admin_name}\nNew password: {user_password}");
        }
    }
}