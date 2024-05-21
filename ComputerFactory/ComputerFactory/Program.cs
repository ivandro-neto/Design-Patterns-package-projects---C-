using System;

namespace ComputerFactory
{
    public enum ComputerTypes
    {
        LAPTOP = 1,
        DESKTOP = 2
    }

    public interface IComputer
    {
        void Mount();
    }

    public interface IRAM
    {
        void Info();
    }

    public interface ICPU
    {
        void Info();
    }

    public class LaptopRAM : IRAM
    {
        public void Info() => Console.WriteLine("RAM: 16GB");
    }

    public class LaptopCPU : ICPU
    {
        public void Info() => Console.WriteLine("Quad-Core");
    }

    public class DesktopRAM : IRAM
    {
        public void Info() => Console.WriteLine("RAM: 64GB");
    }

    public class DesktopCPU : ICPU
    {
        public void Info() => Console.WriteLine("Hexa-Core");
    }

    public class Laptop : IComputer
    {
        public void Mount()
        {
            Console.WriteLine("Laptop Mounted successfully.");
            LaptopRAM ram = new();
            LaptopCPU cpu = new();
            cpu.Info();
            ram.Info();
        }
    }

    public class Desktop : IComputer
    {
        public void Mount()
        {
            Console.WriteLine("Desktop Mounted successfully.");
            DesktopRAM ram = new();
            DesktopCPU cpu = new();
            cpu.Info();
            ram.Info();
        }
    }

    public class ComputerFactory
    {
        public IComputer MountComputer(ComputerTypes type)
        {
            switch (type)
            {
                case ComputerTypes.LAPTOP:
                    return new Laptop();
                case ComputerTypes.DESKTOP:
                    return new Desktop();
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input, please choose 1 for Laptop or 2 for Desktop.");
                    return null;
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            ComputerFactory computerFactory = new ComputerFactory();
            Console.WriteLine("1- Laptop; 2- Desktop: (1 or 2)");

            if (Enum.TryParse(Console.ReadLine(), out ComputerTypes choice))
            {
                IComputer computer = computerFactory.MountComputer(choice);
                if (computer != null)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    computer.Mount();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Invalid Input! Please enter 1 for Laptop or 2 for Desktop.");
            }

            Console.ReadKey();
        }
    }
}
