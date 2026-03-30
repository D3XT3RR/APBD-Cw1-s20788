using APBD_Cw1_s20788.Enums;

namespace APBD_Cw1_s20788.Models;

public class User(string firstName, string lastName, UserType type)
    : Entity()
{
    public string FirstName { get; set; } = firstName;
    public string LastName { get; set; } = lastName;
    public UserType Type {get; set;} = type;

    public override string ToString()
    {
        return $"User {Id}: {FirstName} {LastName}, Type: {Type}";
    }
}