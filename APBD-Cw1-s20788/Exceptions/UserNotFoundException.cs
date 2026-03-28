namespace APBD_Cw1_s20788.Exceptions;

public class UserNotFoundException(int id): NotFoundException($"User not found with id: {id}")
{
    
}