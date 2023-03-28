namespace AirtekStories.Orders;

public interface IOrderProvider
{
    IEnumerable<Order> GetOrders();
}