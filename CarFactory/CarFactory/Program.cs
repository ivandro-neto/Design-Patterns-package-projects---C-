namespace CarFactory
{
    // Builder interface
    public interface ICarBuilder
    {
        void BuildEngine();
        void BuildRoad();
        void BuildBody();
        Car GetCar();
    }

    // Concrete Builder
    public class CarBuilder : ICarBuilder
    {
        private Car _car = new();
        public void BuildEngine()
        {
            _car.AddPart("Engine");
        }
        public void BuildRoad()
        {
            _car.AddPart("Roads");

        }
        public void BuildBody()
        {
            _car.AddPart("Body");

        }
        public Car GetCar()
        {
            return _car;
        } 

    }
    //Product
    public class Car
    {
        private List<string> _parts = new();
        public void AddPart(string part)
        {
            _parts.Add(part);
        }
        public void ShowParts()
        {
            foreach (string part in _parts)
            {
                Console.WriteLine(part);
            }
        }
    }
    // Manager
    public class Manager
    {
        private ICarBuilder _carBuilder;

        public Manager(ICarBuilder builder)
        {
            _carBuilder = builder;
        }

        public void BuildCar()
        {
            _carBuilder.BuildEngine();
            _carBuilder.BuildRoad();
            _carBuilder.BuildBody();
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ICarBuilder builder = new CarBuilder();
            Manager manager = new Manager(builder);

            manager.BuildCar();

            Car car = builder.GetCar();

            car.ShowParts();

            Console.ReadKey();
        }
    }
}
