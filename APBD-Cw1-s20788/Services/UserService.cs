using APBD_Cw1_s20788.Enums;
using APBD_Cw1_s20788.Models;
using APBD_Cw1_s20788.Repositories;

namespace APBD_Cw1_s20788.Services;

public class UserService(UserRepository userRepository)
{
    public User CreateUser(string firstName, string lastName, UserType type)
    {
        var user = new User(firstName, lastName, type);
        userRepository.Add(user);
        return user;
    }

    public User GetUser(int id)
    {
        return userRepository.Get(id);
    }

    public IReadOnlyList<User> GetAllUsers()
    {
        return userRepository.GetAll();
    }
}