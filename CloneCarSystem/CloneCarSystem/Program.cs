using System.Drawing;
using System.Globalization;

namespace CloneCarSystem
{
    public abstract class Vehicle
    {
        private string _id;
        private string _brand;
        private string _model;
        private string _color;
        private uint _year;

        #region Setters
        public void SetColor(string Color)
        {
            _color = Color;
        }

        public void SetYear(int newYear)
        {
            _year = (uint)newYear;
        }
        #endregion

        #region Getters
        public string GetId()
        {
            return _id;
        }
        public string GetBrand()
        {
            return _brand;
        }
        public string GetModel()
        {
            return _model;
        }
        public string GetColor()
        {
            return _color;
        }
        public int GetYear()
        {
            return (int)_year;
        }
        #endregion

        protected Vehicle(string id, string brand, string model, string color, uint year)
        {
            _id = id;
            _brand = brand;
            _model = model;
            _color = color;
            _year = year;
        }
        public string GetInfo()
        {
            return $"ID : {_id}\nBRAND : {_brand}\t MODEL : {_model}\nCOLOR : {_color}\t YEAR : {_year}\n";
        }
        public abstract Vehicle Clone();
    }

    public class Car : Vehicle
    {
        public Car(string id, string brand, string model, string color, uint year) : base(id, brand, model, color, year) { }

        
        public override Vehicle Clone()
        {
            
            return new Car(GetId() + "(Clone)", GetBrand(), GetModel(), GetColor(), (uint)GetYear());
        }
    }

    public class Director
    {
        private Dictionary<string, Vehicle> _vehicleList = new Dictionary<string, Vehicle>();
        public Dictionary<string, Vehicle> vehicleList => _vehicleList;
        public Vehicle this[string name]
        {
            get
            {
                if (vehicleList.ContainsKey(name))
                    return vehicleList[name];
                return null;
            }
        }

        public void AddVehicle(Vehicle vehicle)
        {
            if (!vehicleList.ContainsKey(vehicle.GetId()))
            {
                _vehicleList.Add(vehicle.GetId(), vehicle);
            }
            else
            {
                Console.WriteLine("This vehicle already exist!");
            }
        }

        public Car CloneVehicle(string id)
        {
            if (vehicleList.ContainsKey(id))
            {
                return (Car) vehicleList[id].Clone();
            }else
            {
                Console.WriteLine("Cannot find this vehicle.");
                return null;
            }
        }

        public void UpdateVehicle(Vehicle vehicle)
        {
            if (!_vehicleList.ContainsKey(vehicle.GetId()))
            {
                _vehicleList.Add(vehicle.GetId(), vehicle);
            }
            else
            {
                _vehicleList[vehicle.GetId()] = vehicle;
            }
        }

        public void ListVehicle()
        {
            foreach (Car vehicle in vehicleList.Values)
            {
                vehicle.GetInfo();
            }
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Director director = new();

            // Adicionar um novo veículo
            director.AddVehicle(new Car("ABC1234", "Toyota", "Corolla", "Prata", 2019));

            // Clonar um veículo existente
            Car clone = director.CloneVehicle("ABC1234");
            clone.SetColor("Azul");
            clone.SetYear(2020);
            // Atualizar atributos de um veículo
            director.UpdateVehicle(clone);

            // Imprimir informações do veículo original e do clone
            Console.WriteLine("Veículo Original:");
            Console.WriteLine(director["ABC1234"].GetInfo());
            Console.WriteLine("Clone:");
            Console.WriteLine(director["ABC1234(Clone)"].GetInfo());

            Console.ReadKey();

        }
    }
}
