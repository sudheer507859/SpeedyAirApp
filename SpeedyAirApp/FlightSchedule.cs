namespace SpeedyAirApp
{
    /// <summary>
    /// To manage flight and orders.
    /// </summary>
    public class FlightSchedule
    {
        private List<Flight> Flights { get; set; }

        #region Flight methods
        
        /// <summary>
        /// Add the flights to private variable flights.
        /// </summary>
        public void LoadFlights()
        {
            var flight = new List<Flight>{
                new Flight(1, "YUL", "YYZ", 1),
                new Flight(2, "YUL", "YYC", 1),
                new Flight(3, "YUL", "YVR", 1),
                new Flight( 4, "YUL", "YYZ", 2),
                new Flight(5, "YUL", "YYC", 2),
                new  Flight(6, "YUL", "YVR", 2)
                };

            Flights = flight;
        }

        /// <summary>
        /// Display the list flights.
        /// </summary>
        public void DisplayFlights()
        {
            foreach (var flight in Flights)
            {
                Console.WriteLine($"Flight {flight.FlightNumber}, departure: {flight.Departure}, arrival: {flight.Arrival} , day: {flight.Day}");
            }
        }

        #endregion

        #region Flight order methods
        
        /// <summary>
        /// Schedule the flight with an orders
        /// </summary>
        /// <param name="orders">input data</param>
        public void ScheduleFlightOrders(List<Order> orders)
        {
            foreach (var order in orders)
            {
                var flight = Flights.Find(f => f.Arrival == order.Arrival && f.HasCapacity());
                if (flight != null)
                {
                    order.FlightNumber = flight.FlightNumber;
                    order.Day = flight.Day;
                    order.Departure = flight.Departure;
                    flight.OrderBook();
                }
            }
        }

        /// <summary>
        /// Display the flight orders.
        /// </summary>
        /// <param name="orders">input data</param>
        public void DisplayFlightOrders(List<Order> orders)
        {
            foreach(var order in orders)
            {
                if(order.FlightNumber.HasValue)
                {
                    Console.WriteLine($"order: {order.OrderNumber}, flightNumber: {order.FlightNumber}, departure: {order.Departure}, arrival: {order.Arrival}, day: {order.Day}");
                }
                else
                {
                    Console.WriteLine($"order: {order.OrderNumber}, flightNumber: not scheduled");
                }
            }
        }

        #endregion
    }
}
