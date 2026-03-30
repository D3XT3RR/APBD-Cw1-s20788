using APBD_Cw1_s20788.Exceptions;
using APBD_Cw1_s20788.Models;

namespace APBD_Cw1_s20788.Repositories;

public class UserRepository
{
    private int _nextId = 1;
    private readonly List<User> _users = [];
    
    public void Add(User user)
    {
        user.Id = _nextId++;
        _users.Add(user);
    }
    
    public User Get(int id)
    {
        var user = _users.Find(u => u.Id == id);
        return user ?? throw new UserNotFoundException(id);
    }
    
    public IReadOnlyList<User> GetAll()
    {
        return _users.AsReadOnly();
    }

}