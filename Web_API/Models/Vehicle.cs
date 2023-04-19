namespace Web_API.Models
{
    public class Vehicle
    {
        public Vehicle()
        {
            Cars = new List<Car>();
            Boats = new List<Boat>();
            Buses = new List<Bus>();
        }
        public string Color { get; set; }
        public ICollection<Car> Cars { get; set; }
        public ICollection<Boat> Boats { get; set; }
        public ICollection<Bus> Buses { get; set; }

    }
    public class Car : Vehicle
    {
        public int CarID { get; set; } 
        public string Wheels { get; set; }
        public string Headlights { get; set; }

    }
    public class Boat : Vehicle { }
    public class Bus : Vehicle { }
}

