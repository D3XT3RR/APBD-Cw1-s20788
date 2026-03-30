using APBD_Cw1_s20788.Enums;
using APBD_Cw1_s20788.Models;
using APBD_Cw1_s20788.Repositories;

namespace APBD_Cw1_s20788.Services;

public class UserService(UserRepository userRepository): IUserService
{
    private int _nextUserId = 1;
    private readonly UserRepository _userRepository = userRepository;
    
    public User CreateUser(string firstName, string lastName, UserType type)
    {
        var user = new User(_nextUserId++, firstName, lastName, type);
        _userRepository.Add(user);
        return user;
    }

    public User GetUser(int id)
    {
        return _userRepository.Get(id);
    }

    public IReadOnlyList<User> GetAllUsers()
    {
        return _userRepository.GetAll();
    }
}