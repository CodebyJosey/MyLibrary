using MyLibrary.Data.Models;

namespace MyLibrary.Data.Repositories;

public interface IUserRepository
{
    User GetUserById(int id);
    void AddUser(User user);
    void UpdateUser(User user);
    void DeleteUser(User user);
}