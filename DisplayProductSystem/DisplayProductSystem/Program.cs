using System.Drawing;

namespace DisplayProductSystem
{
    public interface IProduct
    {
        void Display();
    }
    public interface IPlatform
    {
        void ShowClothes(string name, string brand, string size, int price);
        void ShowElectronics(string name, string brand, string specs, int price);
        void ShowElectroDomestics(string name, string brand, string size, int price);
    }

    public class Mobile : IPlatform
    {
        public void ShowClothes(string name, string brand, string size, int price)
        {
            Console.WriteLine("Mobile Mode");

            Console.WriteLine($"NAME:{name}\tBRAND:{brand}\nSIZE:{size}\tPRICE:{price}\n");
        }

        public void ShowElectroDomestics(string name, string brand, string size, int price)
        {
            Console.WriteLine("Mobile Mode");

            Console.WriteLine($"NAME:{name}\tBRAND:{brand}\nSIZE:{size}\tPRICE:{price}\n");

        }

        public void ShowElectronics(string name, string brand, string specs, int price)
        {
            Console.WriteLine("Mobile Mode");

            Console.WriteLine($"NAME:{name}\tBRAND:{brand}\nSPECS:{specs}\tPRICE:{price}\n");

        }
    }
    public class Web : IPlatform
    {
        public void ShowClothes(string name, string brand, string size, int price)
        {
            Console.WriteLine("Web Mode");

            Console.WriteLine($"NAME:{name}\nBRAND:{brand}\nSIZE:{size}\tPRICE:{price}\n");
        }

        public void ShowElectroDomestics(string name, string brand, string size, int price)
        {
            Console.WriteLine("Web Mode");

            Console.WriteLine($"NAME:{name}\nBRAND:{brand}\nSIZE:{size}\tPRICE:{price}\n");

        }

        public void ShowElectronics(string name, string brand, string specs, int price)
        {
            Console.WriteLine("Web Mode");

            Console.WriteLine($"NAME:{name}\tBRAND:{brand}\nSPECS:{specs}\nPRICE:{price}\n");

        }
    }
    public class AdminPanel : IPlatform
    {
        public void ShowClothes(string name, string brand, string size, int price)
        {
            Console.WriteLine("Administrator Panel");
            Console.WriteLine($"NAME:{name}\tBRAND:{brand}\tSIZE:{size}\tPRICE:{price}\n");
        }

        public void ShowElectroDomestics(string name, string brand, string size, int price)
        {
            Console.WriteLine("Administrator Panel");

            Console.WriteLine($"NAME:{name}\tBRAND:{brand}\tSIZE:{size}\tPRICE:{price}\n");

        }

        public void ShowElectronics(string name, string brand, string specs, int price)
        {
            Console.WriteLine("Administrator Panel");

            Console.WriteLine($"NAME:{name}\tBRAND:{brand}\tSPECS:{specs}\tPRICE:{price}\n");

        }
    }
    public class Clothes : IProduct
    {
        private string _name;
        private string _brand;
        private string _size;
        private int _price;
        private IPlatform _platform;
        public Clothes(string name, string brand, string size, int price, IPlatform platform)
        {
            _name = name;
            _brand = brand;
            _size = size;
            _price = price;
            _platform = platform;
        }

        public void Display()
        {
            _platform.ShowClothes(_name, _brand, _size, _price);
        }
    }

    public class Electronics : IProduct
    {
        private string _name;
        private string _brand;
        private string _specs;
        private int _price;
        private IPlatform _platform;
        public Electronics(string name, string brand, string specs, int price, IPlatform platform)
        {
            _name = name;
            _brand = brand;
            _specs = specs;
            _price = price;
            _platform = platform;
        }

        public void Display()
        {
            _platform.ShowElectronics(_name, _brand, _specs, _price);
        }
    }

    public class ElectroDomestics : IProduct
    {
        private string _name;
        private string _brand;
        private string _size;
        private int _price;
        private IPlatform _platform;
        public ElectroDomestics(string name, string brand, string size, int price, IPlatform platform)
        {
            _name = name;
            _brand = brand;
            _size = size;
            _price = price;
            _platform = platform;
        }

        public void Display()
        {
            _platform.ShowElectroDomestics(_name, _brand, _size, _price);
        }
    }
    
    internal class Program
    {
        public static void ListProducts(List<IProduct> types)
        {
            foreach(var element in types)
            {
                element.Display();
            }
        }
        static void Main(string[] args)
        {
            Mobile mobile = new Mobile();
            Web web = new Web();
            AdminPanel adminPanel = new AdminPanel();
            List<IProduct> clothes = new List<IProduct>()
            {
                new Clothes("Jackout", "Versace", "M", 4500, mobile),
                new Clothes("Jackout", "Versace", "M", 4500, web),
                new Clothes("Jackout", "Versace", "M", 4500, adminPanel)
            };
            List<IProduct> es = new List<IProduct>()
            {
                new Electronics("Legion", "Lenovo", "32 RAM | 1 TB SDD | 400hz", 4500, mobile),
                new Electronics("Legion", "Lenovo", "32 RAM | 1 TB SDD | 400hz", 4500, web),
                new Electronics("Legion", "Lenovo", "32 RAM | 1 TB SDD | 400hz", 4500, adminPanel),
            };
            List<IProduct> domestics = new List<IProduct>()
            {
                new ElectroDomestics("Coffee Machine", "Delta", "24x24", 4500, mobile),
                new ElectroDomestics("Tea Machine", "Delta", "24x24", 4500, web),
                new ElectroDomestics("Mixer", "Mixertape", "24x24", 4500, adminPanel)
            };

            ListProducts(clothes);
            ListProducts(es);
            ListProducts(domestics);
            
            Console.ReadKey();
        }
    }
}
