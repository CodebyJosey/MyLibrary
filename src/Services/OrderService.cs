using System.Reflection.Metadata.Ecma335;
using MyLibrary.Data.Models;
using MyLibrary.Data.Repositories;

namespace MyLibrary.Services;

public class OrderService
{
    private readonly IOrderRepository _orderRepository;
    private readonly IEmailService _emailService;

    public OrderService(IOrderRepository orderRepository, IEmailService emailService)
    {
        _orderRepository = orderRepository;
        _emailService = emailService;
    }

    public Order GetOrderById(int orderId)
    {
        if (_orderRepository.GetOrderById(orderId) == null)
        {
            throw new KeyNotFoundException("Order ID was not found!");
        }
        return _orderRepository.GetOrderById(orderId);
    }

    public IEnumerable<Order> GetOrdersByUserId(int userId) => _orderRepository.GetOrdersByUserId(userId);

    public void AddOrder(Order order)
    {
        if (_orderRepository.GetOrderById(order.Id) != null)
        {
            throw new InvalidOperationException("Order is already used!");
        }

        _orderRepository.AddOrder(order);
    }
}