using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TravelAgencyApp.BookingTypes;
namespace TravelAgencyApp.Factories
{
    public interface IBookingFactory
    {
        Booking CreateBooking();
    }

    public class TravelBookingFactory : IBookingFactory
    {
        private string _id;
        private string _name;
        private string _from;
        private string _to;
        private string _startDate;
        private string _endDate;
        public TravelBookingFactory(string id, string name, string from, string to, string startDate, string endDate) 
        {
            _id = id;
            _name = name;
            _from = from;
            _to = to;
            _startDate = startDate;
            _endDate = endDate;
        }
        public Booking CreateBooking()
        {
            return new TravelBooking(_id, _name, _from, _to, _startDate, _endDate);
        }
    }

    public class HotelBookingFactory : IBookingFactory
    {
        private string _id;
        private string _name;
        private string _bookingStartDate;
        private string _bookingEndDate;
        private string _roomNumber;
        public HotelBookingFactory(string id, string name, string room, string start, string end)
        {
            _id = id;
            _name = name;
            _roomNumber = room;
            _bookingStartDate = start;
            _bookingEndDate = end;
        }
        public Booking CreateBooking()
        {
            return new HotelBooking(_id, _name, _roomNumber, _bookingStartDate, _bookingEndDate);
        }
    }

    public class CarBookingFactory : IBookingFactory
    {
        private string _id;
        private string _name;
        private string _bookingStartDate;
        private string _bookingEndDate;
        private string _carID;
        public CarBookingFactory(string id, string name, string carID, string bookingStartDate, string bookingEndDate)
        {
            _id = id;
            _name = name;
            _bookingStartDate = bookingStartDate;
            _bookingEndDate = bookingEndDate;
            _carID = carID;
        }

        public Booking CreateBooking()
        {
            return new CarBooking(_id, _name, _carID, _bookingStartDate, _bookingEndDate);
        }
    }
}
