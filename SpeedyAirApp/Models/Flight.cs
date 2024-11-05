using SpeedyAirApp;
using System.ComponentModel.DataAnnotations;

public class Flight
{
    private int orderBooked = 0;

    public Flight(int FlightNumber, string Departure, string Arrival, int Day)
    {
        this.FlightNumber = FlightNumber;
        this.Departure = Departure;
        this.Arrival = Arrival;
        this.Day = Day;
    }

    [Required]
    public int FlightNumber { get; set; }

    [Required]
    [Length(3, 3, ErrorMessage = "Departure should  be 3 characters.")]

    public string Departure { get; set; }

    [Required]
    [Length(3, 3, ErrorMessage = "Arrival should  be 3 characters.")]

    public string Arrival { get; set; }

    [Required]
    public int Day { get; set; }

    public int Capacity { get; protected set; } = Constants.FlightCapacity;

    public bool HasCapacity()
    {
         return orderBooked < Capacity;
    } 
    public void OrderBook()
    {
        orderBooked++;
    }
}