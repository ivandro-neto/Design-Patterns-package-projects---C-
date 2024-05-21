namespace VehicleFactory
{
    public interface IEngine
    {
        void Start();
    }

    public interface ITire
    {
        void Mount();
    }

    public interface IChasis
    {
        void Assemble();
    }

    public interface IFactory
    {
        IEngine Create();
        ITire Build();
        IChasis Mount();
    }

    public class CarEngine : IEngine
    {
        public void Start() => Console.WriteLine("car engine started."); 
    }

    public class CarChasis : IChasis
    {
        public void Assemble() => Console.WriteLine("Car chasis added.");
    }

    public class CarTire : ITire
    {
        public void Mount() => Console.WriteLine("Car tire mounted."); 
    }

    public class CarFactory : IFactory
    {

        public IEngine Create()
        {
            return new CarEngine();
        }
        public ITire Build() 
        {
            return new CarTire();
        }
        public IChasis Mount()
        {
            return new CarChasis();
        }
    }
    public class MotocycleEngine : IEngine
    {
        public void Start() => Console.WriteLine("Moto engine started.");
    }

    public class MotocycleChasis : IChasis
    {
        public void Assemble() => Console.WriteLine("Moto chasis added.");
    }

    public class MotocycleTire : ITire
    {
        public void Mount() => Console.WriteLine("Moto tire mounted.");
    }

    public class MotocycleFactory : IFactory
    {

        public IEngine Create()
        {
            return new MotocycleEngine();
        }
        public ITire Build()
        {
            return new MotocycleTire();
        }
        public IChasis Mount()
        {
            return new MotocycleChasis();
        }
    }

    public class Client
    {
        private readonly IFactory _factory;
        public Client(IFactory factory)
        {
            _factory = factory;
        }
        public void MountVehicle()
        {
            Console.WriteLine("Mounting vehicle:");
            IEngine engine = _factory.Create();
            ITire tire = _factory.Build();
            IChasis chasis = _factory.Mount();
            
            tire.Mount();
            chasis.Assemble();
            engine.Start();

            Console.WriteLine("Vehicle Mounted successfully!");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Client carClient = new(new CarFactory());
            carClient.MountVehicle();

            Client MotoClient = new(new MotocycleFactory());
            MotoClient.MountVehicle();

            Console.ReadKey();
        }
    }
}
