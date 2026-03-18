using APBD_Cw1_s20788.Models;

namespace APBD_Cw1_s20788.Services;

public interface IUserService
{
    User CreateUser(string firstName, string lastName, UserType type);
    User GetUser(int id);
    IReadOnlyList<User> GetAllUsers();
}