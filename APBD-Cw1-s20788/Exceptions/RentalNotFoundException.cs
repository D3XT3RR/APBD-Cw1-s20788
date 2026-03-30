namespace APBD_Cw1_s20788.Exceptions;

public class RentalNotFoundException(int id): NotFoundException($"Rental with ID {id} not found")
{
    
}