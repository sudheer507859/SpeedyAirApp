using System.Text.Json;

namespace SpeedyAirApp
{
    public static class Helper
    {
        /// <summary>
        /// Read the orders data json data and get the orders. 
        /// </summary>
        /// <returns></returns>
        public static List<Order> GetOrders()
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, Constants.OrdersDataFilePath);
            string fileContent = File.ReadAllText(filePath);
            //De-serializing JSON orders data to C# Order
            var ordersData = JsonSerializer.Deserialize<Dictionary<string, OrderData>>(fileContent);

            if (ordersData is null)
            {
                return Enumerable.Empty<Order>().ToList();
            }

            List<Order> orders = new List<Order>();
            Parallel.ForEach(ordersData, orderData =>
            {
                Order order = new Order
                {
                    OrderNumber = orderData.Key,
                    Arrival = orderData.Value.Destination
                };
                orders.Add(order);
            });
            return orders;
        }
    }
}
