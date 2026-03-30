using APBD_Cw1_s20788.Enums;

namespace APBD_Cw1_s20788.Models;

public class User(int id, string firstName, string lastName, UserType type)
    : Entity(id)
{
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public UserType Type {get; set;} = type;
}