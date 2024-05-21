using System.Globalization;
using System.Net.Security;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace LoginSystem
{

    public class User
    {
        private string Name;
        private string Password;
        private int Age;
        private string Email;
        private readonly bool isAdmin;
        
        public User(string  name, string password, int age, string email, bool admin = false)
        {
            Name = name;
            Password = password;
            Age = age;
            Email = email;
            isAdmin = admin;
        }
        public bool IsAdmin() { return isAdmin; }
        public string GetPass() { return Password; }
        public void GetUserInfo()
        {
            Console.WriteLine($"USER: {Name}\nAGE: {Age}\nEMAIL: {Email}");
        }
    }
    public class LoginSystem
    {
        private static int _adminCount;
        private const int salt = 126;
        private static LoginSystem _instance;
        private Dictionary<string, User> Users;

        private string Encrypt(string password)
        {
            string encrypted = null;
            foreach (char letter in password)
            {
                encrypted += Convert.ToChar(letter + salt);
            }
            return encrypted;
        }
        private string Decrypt(string password)
        {
            string encrypted = null;
            foreach (char letter in password)
            {
                encrypted += Convert.ToChar(letter - salt);
            }
            return encrypted;
        }
        private LoginSystem()
        {
            Users = new Dictionary<string, User>()
            {
                {"Paul", new User("Paul", Encrypt("12345C"), 25, "paul.test@loginsystem.ao", setAdmin()) },
                {"Marcos", new User("Marcos", Encrypt("12345A"), 32, "marcos.test@loginsystem.ao", setAdmin())  }
            };
        }
        public bool setAdmin()
        {
            if(_adminCount < 1)
            {
                Message.Success("Admin setted successfully.");
                _adminCount++;
                return true;
            }
            else
            {
                Message.Error("Just an admin is allowed");
                return false;
            }
        }
        public static LoginSystem GetInstance()
        {
            if (_instance == null)
            {
                _instance = new LoginSystem();
            }
            return _instance;
        }
        public void CreateUser(string username, string password, int age, string email)
        {
            if (!string.IsNullOrEmpty(username) || !string.IsNullOrEmpty(password))
            {
                if(!Users.ContainsKey(username)) 
                {
                    Users.Add(username, new User(username, Encrypt(password), age, email, setAdmin()));
                }
                else
                {
                    Message.Warning("This user already exist.");
                }
            }
            else
            {
                Message.Warning("Name and password should not be empty.");
            }
        }
        public User Login(string name, string password)
        {
            if (Users.ContainsKey(name))
            {
                return ValidateUser(name, password);
            }
            Message.Warning("User not found."); 
            return null;
        }
        private User ValidateUser(string name, string password)
        {
            Users.TryGetValue(name, out User user);
            if (user != null && Decrypt(user.GetPass()) == password)
            {
                Message.Success("Successfull login.");
                return user;
            }
            Message.Error("Wrong password.");
            return null;
        }
        public static LoginSystem Logout()
        {
            Console.WriteLine("Logout...");
            _instance = null;
            return _instance;
        }
        public void ListAllUser()
        {
            foreach (User user in Users.Values)
            {
                user.GetUserInfo();
            }
        }
    }
    public static class Message
    {
        public static void message(ConsoleColor type, string sms)
        {
            Console.ForegroundColor = type;
            Console.WriteLine(sms);
            Console.ForegroundColor = ConsoleColor.White;

        }

        public static void Error(string sms)
        {
            message(ConsoleColor.Red, sms);
        }

        public static void Warning(string sms)
        {
            message(ConsoleColor.DarkYellow, sms);
        }

        public static void Success(string sms)
        {
            message(ConsoleColor.Green, sms);
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            int input = 0;
            LoginSystem Session = LoginSystem.GetInstance();

            Console.WriteLine("Welcome to LoginSystem!");
            do
            {
                Console.WriteLine("1 - Login.");
                Console.WriteLine("2 - Create new user.");
                Console.WriteLine("0 - Exit.");
                int.TryParse(Console.ReadLine(), out input);
                switch (input)
                {
                    case 0: 
                        Console.WriteLine("Exiting...");
                        break;
                    case 1:
                        Session = LoginSystem.GetInstance();
                        Console.WriteLine("Login:");
                        Console.WriteLine("Username:");
                        string username = Console.ReadLine();
                        Console.WriteLine("Password:");
                        string userpassword= Console.ReadLine();
                        User user = Session.Login(username, userpassword);
                        if(user != null)
                        {
                            Console.WriteLine("1 - User Info.");
                            Console.WriteLine("2 - List All User.");
                            Console.WriteLine("0 - Exit.");
                            switch (Convert.ToInt32(Console.ReadLine()))
                                {
                                    case 1:
                                        user.GetUserInfo();
                                        break;
                                    case 2:
                                        if (user.IsAdmin()) { 
                                            Session.ListAllUser();
                                        }
                                        else
                                        {
                                            Message.Error("This User cannot list all users");
                                        }
                                        break;
                                    case 0:
                                        
                                        break;
                                }
                        }
                        else
                        {
                            Session = LoginSystem.Logout();
                        }
                        break;
                        case 2:
                            LoginSystem newSession = LoginSystem.GetInstance();
                            Message.Warning(Session == newSession? "Same Session":"Different Session");
                            Console.WriteLine("New User:");
                            Console.WriteLine("Username:");
                            string name = Console.ReadLine();
                            Console.WriteLine("Password:");
                            string password = Console.ReadLine();
                            Console.WriteLine("Age:");
                            int.TryParse(Console.ReadLine(), out int age);
                            Console.WriteLine("Email:");
                            string email= Console.ReadLine();
                            newSession.CreateUser(name, password, age, email);
                        break;
                    default:
                        Message.Error("Wrong input.");
                        break;
                }
            } while (input != 0);
            Console.ReadKey();
        }
    }
}
