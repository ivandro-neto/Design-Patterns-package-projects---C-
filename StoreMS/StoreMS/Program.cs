namespace StoreMS
{
    public interface IProduct
    {
        void DisplayInfo();
    }


    public class ElectronicProduct : IProduct
    {
       
        public void DisplayInfo() 
        {
            Console.WriteLine($"Name:PS5\nDescription:Game Console\nPrice:$3.000,00 USD");
        }
    }

    public class ClothingProduct: IProduct
    {
       
        public void DisplayInfo()
        {
            Console.WriteLine($"Name:MidNightJacket\nDescription:Versaci clothe\nPrice:$500,00USD");
        }
    }

    public class BookProduct : IProduct
    {
        public void DisplayInfo()
        {
            Console.WriteLine("I'm the HOLY BIBLE the most worth book in the entire World!");
        }
    }

    public abstract class ProductFactory
    {
        public abstract IProduct CreateProduct();
    }
    public class ElectronicFactory: ProductFactory
    {
        public override IProduct CreateProduct() => new ElectronicProduct();
    }
    public class ClothingFactory: ProductFactory
    {
        public override IProduct CreateProduct() => new ClothingProduct();
    }
    public class BookFactory: ProductFactory
    {
        public override IProduct CreateProduct() => new BookProduct();
    }
    

    public class StoreMS
    {
        public IProduct GetProduct(string name)
        {
            try
            {
                switch (name.ToLower())
                {
                    case "electronics":
                        return new ElectronicFactory().CreateProduct();
                    case "clothes":
                        return new ClothingFactory().CreateProduct();
                    case "books":
                        return new BookFactory().CreateProduct();
                    default:
                        Console.WriteLine("Wrong input.");
                        return null;

                }
            }
            catch (Exception)
            {

                throw new Exception();
            }
            
        }
    }


    internal class Program
    {
        static void Main(string[] args)
        {
            StoreMS store = new StoreMS();
            Console.WriteLine("Choose a Product type: Electronics | Clothes | Books:");
            string input = Console.ReadLine();
            if (input != null || input != string.Empty)
            {
                IProduct product = store.GetProduct(input);
                if (product != null)
                {

                    product.DisplayInfo();
                }
            }
            else
            {
                Console.WriteLine("Wrong input!");
            }

            Console.ReadLine();
        }
    }
}
