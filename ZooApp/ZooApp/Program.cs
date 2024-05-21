namespace ZooApp
{
    internal class Program
    {
        public interface IAnimal
        {
            void FazerSom();
        }

        public class Animal : IAnimal
        {
            private string _name;
            private string _sound;

            public Animal(string name, string? sound)
            {
                _name = name;
                _sound = sound;
            }

            public virtual void FazerSom() 
            {
                Console.WriteLine("Eu faco este som : {0}", _sound);
            }
           
        }

        public class Dog : Animal
        {
            public Dog(string name, string? sound) : base(name, sound)
            {
            }
            override public void FazerSom()
            {
                Console.WriteLine("Eu faco Roof roof!");
            }
        }
        public class Cat : Animal
        {
            public Cat(string name, string? sound) : base(name, sound) { }

            override public void FazerSom()
            {
                Console.WriteLine("Eu faco Meow Meow!");
            }
        }
        public class Zoo
        {
            private Dictionary<string ,Func<Animal>> _animals;
            public Zoo() 
            {
                _animals = new Dictionary<string, Func<Animal>>()
                {
                    {"dog", () => new Dog("Dog","Roof")},
                    {"cat", () => new Cat("Cat","Meow")},
                };
            }
            
            public void CreateAnimal(string type, string som)
            {
                if (!_animals.ContainsKey(type))
                {

                    _animals.Add(type.ToLower(), () => new Animal(type, som));
                }
            }

            public void ListAnimals()
            {
                foreach (var item in _animals)
                {
                    Console.WriteLine("I'm a {0}", item.Value().GetType().Name);
                }
            }

            public void EmitSound(string type)
            {
                if (_animals.ContainsKey(type.ToLower()))
                {
                    _animals[type.ToLower()]().FazerSom();
                }
                else
                {
                    Console.WriteLine("Animal doesn't exist!");
                }
            }
        }


        static void Main(string[] args)
        {
            Zoo zootopia = new();
            int input = -1;
            do
            {

                Console.WriteLine("welcome to the Zootopia!");
                Console.WriteLine("1 - Add new Animal.");
                Console.WriteLine("2 - List all animal.");
                Console.WriteLine("3 - Search for a animal.");
                Console.WriteLine("0 - Exit.");
                input = Convert.ToInt32(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        Console.WriteLine("Introduce the animal's name:");
                        string type = Console.ReadLine();
                        Console.WriteLine("Introduce the animal's sound:");
                        string sound = Console.ReadLine();
                        zootopia.CreateAnimal(type, sound);
                        zootopia.EmitSound(type);
                        break;
                    case 2:
                        zootopia.ListAnimals();
                        break;
                    case 3:
                        Console.WriteLine("Introduce the animal's name:");
                        string typeAnimal = Console.ReadLine();
                        zootopia.EmitSound(typeAnimal);
                        break;
                    case 0:
                        Console.WriteLine("Exiting...");
                        break;
                    default:
                        Console.WriteLine("Wrong input!");
                        break;

                }
            } while (input != 0);
            Console.ReadKey();



        }
    }
}
