using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TravelAgencyApp.BookingTypes
{
    public abstract class Booking
    {
        protected string _id;
        protected string _name;
        protected string _type;

        protected Booking(string id, string name)
        {
            _id = id;
            _name = name;
        }
        public abstract string GetBooking();
    }

    public class TravelBooking : Booking
    {
        private string _from;
        private string _to;
        private string _startDate;
        private string _endDate;
        public TravelBooking(string id, string name, string from, string to, string startDate, string endDate) : base(id, name)
        {
            _from = from;
            _to = to;
            _startDate = startDate;
            _endDate = endDate;
            _type = "Travel";
        }

        public override string GetBooking()
        {
            return $"BOOKING TYPE : {_type}\n========================\nNAME : {_name}\tID : {_id}\nFROM : {_from}\tSTART DATE: {_startDate}\nTO : {_to}\tEND DATE: {_endDate}\n";
        }


    }

    public class HotelBooking : Booking
    {
        private string _bookingStartDate;
        private string _bookingEndDate;
        private string _roomNumber;
        public HotelBooking(string id, string name, string room, string start, string end):base(id, name) 
        {
            _roomNumber = room;
            _bookingStartDate = start;
            _bookingEndDate = end;
            _type = "Hotel";
        }

        public override string GetBooking()
        {
            return $"BOOKING TYPE : {_type}\n========================\nNAME : {_name}\tID : {_id}\tROOM : {_roomNumber}\nSTART DATE: {_bookingStartDate}\tEND DATE: {_bookingEndDate}\n";
        }
    }

    public class CarBooking : Booking
    {
        private string _bookingStartDate;
        private string _bookingEndDate;
        private string _carID;
        public CarBooking(string id, string name,string carID, string bookingStartDate, string bookingEndDate) : base(id, name)
        {
            _bookingStartDate = bookingStartDate;
            _bookingEndDate = bookingEndDate;
            _type = "Car";
            _carID = carID;
        }

        public override string GetBooking()
        {
            return $"BOOKING TYPE : {_type}\n========================\nNAME : {_name}\tID : {_id}\tCAR ID : {_carID}\nSTART DATE: {_bookingStartDate}\tEND DATE: {_bookingEndDate}\n";
        }
    }


}
