using TravelAgencyApp.Factories;

namespace TravelAgencyApp
{
    public class AgencyFacade
    {
        private static AgencyFacade instance;
        private List<string> _bookings = new List<string>();
        private AgencyFacade() { }

        public static AgencyFacade GetInstance()
        {
            if (instance == null)
            {
                instance = new AgencyFacade();
            }
            return instance;
        }

        // Método para criar uma reserva de viagem
        public void CreateTravelBooking(string id, string name, string from, string to, string startDate, string endDate)
        {
            // Tratamento de erros para garantir que os dados de entrada não sejam nulos ou vazios
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(from) ||
                string.IsNullOrEmpty(to) || string.IsNullOrEmpty(startDate) || string.IsNullOrEmpty(endDate))
            {
                Console.WriteLine("Error: Missing or invalid input data. Please provide all required information.");
                return;
            }

            // Criação da reserva de viagem
            _bookings.Add(new TravelBookingFactory(id, name, from, to, startDate, endDate).CreateBooking().GetBooking());
        }

        // Método para criar uma reserva de hotel
        public void CreateHotelBooking(string id, string name, string room, string startDate, string endDate)
        {
            // Tratamento de erros para garantir que os dados de entrada não sejam nulos ou vazios
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(room) ||
                string.IsNullOrEmpty(startDate) || string.IsNullOrEmpty(endDate))
            {
                Console.WriteLine("Error: Missing or invalid input data. Please provide all required information.");
                return;
            }

            // Criação da reserva de hotel
            _bookings.Add(new HotelBookingFactory(id, name, room, startDate, endDate).CreateBooking().GetBooking());
        }

        // Método para criar uma reserva de carro
        public void CreateCarBooking(string id, string name, string carID, string startDate, string endDate)
        {
            // Tratamento de erros para garantir que os dados de entrada não sejam nulos ou vazios
            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(name) || string.IsNullOrEmpty(carID) ||
                string.IsNullOrEmpty(startDate) || string.IsNullOrEmpty(endDate))
            {
                Console.WriteLine("Error: Missing or invalid input data. Please provide all required information.");
                return;
            }

            // Criação da reserva de carro
            _bookings.Add(new CarBookingFactory(id, name, carID, startDate, endDate).CreateBooking().GetBooking());
        }

        // Método para exibir todas as reservas
        public void DisplayBookings()
        {
            if (_bookings.Count == 0)
            {
                Console.WriteLine("No bookings to display.");
                return;
            }

            foreach (string booking in _bookings)
            {
                Console.WriteLine(booking);
            }
        }
    }
    public class Person
    {
        private static Person instance;
        private string _name;
        private string _id;

        // Métodos para definir e obter o nome
        public void SetName(string name)
        {
            if (!string.IsNullOrEmpty(name))
            {
                _name = name;
            }
            else
            {
                Console.WriteLine("Error: Name cannot be empty.");
            }
        }

        public string GetName()
        {
            return _name;
        }

        // Métodos para definir e obter o ID
        public void SetID(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                _id = id;
            }
            else
            {
                Console.WriteLine("Error: ID cannot be empty.");
            }
        }

        public string GetID()
        {
            return _id;
        }

        private Person() { }

        public static Person GetInstance()
        {
            if (instance == null)
                instance = new Person();
            return instance;
        }
    }

    internal class Program
    {
        public static void MainMenu(ref int option)
        {
            Console.WriteLine("1 - Create a travel booking.");
            Console.WriteLine("2 - Create a hotel booking.");
            Console.WriteLine("3 - Create a car booking.");
            Console.WriteLine("4 - Display Bookings.");
            Console.WriteLine("0 - Exit.");
            int.TryParse(Console.ReadLine(), out option);
            Console.Clear();
        }
        static void Main(string[] args)
        {
            int option = 0;
            AgencyFacade agencyFacade = AgencyFacade.GetInstance();
            Person person = Person.GetInstance();


            Console.WriteLine("Welcome to TravelIT!");

            Console.WriteLine("Introduza o seu nome:");
            person.SetName(Console.ReadLine());
            Console.WriteLine("Introduza o seu ID:");
            person.SetID(Console.ReadLine());

            do
            {
                MainMenu(ref option);

                switch (option)
                {
                    case 0:
                        break;
                    case 1:
                        Console.WriteLine("Introduza o comeco:");
                        string from = Console.ReadLine();
                        Console.WriteLine("Introduza o destino:");
                        string to = Console.ReadLine();
                        Console.WriteLine("Introduza a data de partida:");
                        string startDate = Console.ReadLine();
                        Console.WriteLine("Introduza a data de regresso:");
                        string endDate = Console.ReadLine();
                        agencyFacade.CreateTravelBooking(person.GetID(), person.GetName(), from, to, startDate, endDate);
                        break;
                    case 2:
                        Console.WriteLine("Introduza o quarto:");
                        string room = Console.ReadLine();
                        Console.WriteLine("Introduza o comeco da estadia:");
                        string bookingStart = Console.ReadLine();
                        Console.WriteLine("Introduza o fim da estadia:");
                        string bookingEnd = Console.ReadLine();
                        agencyFacade.CreateHotelBooking(person.GetID(), person.GetName(), room, bookingStart, bookingEnd);
                        break;
                    case 3:
                        Console.WriteLine("Introduza o numero da placa do carro:");
                        string carID = Console.ReadLine();
                        Console.WriteLine("Introduza o comeco do aluguer:");
                        string bookingCarStart = Console.ReadLine();
                        Console.WriteLine("Introduza o fim do aluguer:");
                        string bookingCarEnd = Console.ReadLine();
                        agencyFacade.CreateCarBooking(person.GetID(), person.GetName(), carID, bookingCarStart, bookingCarEnd);
                        break;
                    case 4:
                        agencyFacade.DisplayBookings();
                        break;
                    default:
                        break;
                }

            }while(option != 0);


            Console.ReadKey();
        }
    }
}
