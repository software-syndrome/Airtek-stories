
using System.IO;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace AirtekStories.Orders;

public class JsonOrderProvider : IOrderProvider
{
    public IEnumerable<Order> GetOrders()
    {
        const string path = "./coding-assigment-orders.json";
        if (!File.Exists(path))
        {
            throw new InvalidOperationException("File not exists");
        }

        var json = string.Empty;
        using (StreamReader sr = File.OpenText(path))
        {
            json = sr.ReadToEnd();
        }

        var orderDict = JsonSerializer.Deserialize<Dictionary<string, JsonOrderProperties>>(json);

        return orderDict?.Select(order =>
        {
            return new Order()
            { OrderId = order.Key, ArrivalCityCode = order.Value.ArrivalCityCode };
        }) ?? Enumerable.Empty<Order>();
    }
}

internal class JsonOrderProperties
{
    [JsonPropertyName("destination")]
    public string ArrivalCityCode { get; set; }
}