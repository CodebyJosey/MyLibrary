using MyLibrary.Data.Models;

namespace MyLibrary.Data.Repositories;

public interface IOrderRepository
{
    Order GetOrderById(int id);
    IEnumerable<Order> GetOrdersByUserId(int userId);
    void AddOrder(Order order);
}