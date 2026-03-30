using APBD_Cw1_s20788.Enums;

namespace APBD_Cw1_s20788.Rules;

public static class UserRules
{
    public const int StudentMaxActiveRentals  = 2;
    public const int EmployeeMaxActiveRentals = 5;
 
    public static int GetMaxActiveRentals(UserType userType)
    {
        return userType == UserType.Student ? StudentMaxActiveRentals : EmployeeMaxActiveRentals;
    }
}