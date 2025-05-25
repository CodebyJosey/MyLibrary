// Copyright (c) 2025 Josey van Aarsen
// Licensed under the MIT License. See LICENSE file in the project root for full license information.
namespace CodeByJosey.MyLibrary.Data.Repositories;

using MyLibrary.Data.Models;
public interface IOrderRepository
{
    Order GetOrderById(int id);
    IEnumerable<Order> GetOrdersByUserId(int userId);
    void AddOrder(Order order);
}