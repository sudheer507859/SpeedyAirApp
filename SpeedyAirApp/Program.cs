using SpeedyAirApp;

Console.WriteLine("Welcome to Speedy Airline application!");

try
{
    FlightSchedule flightSchedule = new FlightSchedule();
    flightSchedule.LoadFlights();
    flightSchedule.DisplayFlights();

    List<Order> orders = Helper.GetOrders();
    flightSchedule.ScheduleFlightOrders(orders);
    flightSchedule.DisplayFlightOrders(orders);
}
catch (Exception ex)
{
    Console.WriteLine(ex.Message);
}

Console.ReadKey();