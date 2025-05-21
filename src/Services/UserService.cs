using MyLibrary.Data.Models;
using MyLibrary.Data.Repositories;

namespace MyLibrary.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;
    private readonly IEmailService _emailService;

    public UserService(IUserRepository userRepository, IEmailService emailService)
    {
        _userRepository = userRepository;
        _emailService = emailService;
    }

    public User GetUserById(int userId)
    {
        return _userRepository.GetUserById(userId);
    }

    public void RegisterUser(User user)
    {
        if (_userRepository.GetUserById(user.Id) != null)
        {
            throw new InvalidOperationException("Username is already in use!");
        }

        _userRepository.AddUser(user);
        _emailService.SendEmail(user.Email, "Registration confirmation", "Your registration was successfully made.");
    }

    public void UpdateUser(User user)
    {
        if (_userRepository.GetUserById(user.Id) == null)
        {
            throw new KeyNotFoundException("User was not found!");
        }

        _userRepository.UpdateUser(user);
    }

    public void DeleteUser(int id)
    {
        if (_userRepository.GetUserById(id) == null)
        {
            throw new KeyNotFoundException("User was not found!");
        }

        _userRepository.DeleteUser(_userRepository.GetUserById(id));
    }
}