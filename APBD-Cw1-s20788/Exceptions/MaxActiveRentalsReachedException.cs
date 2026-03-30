namespace APBD_Cw1_s20788.Exceptions;

public class MaxActiveRentalsReachedException(int userId, int maxRentals): Exception($"User with ID {userId} has reached the maximum number of active rentals ({maxRentals})")
{
    
}