namespace APBD_Cw1_s20788.Exceptions;

public class ItemAlreadyRentedException(int id): Exception($"Item with ID {id} is already rented")
{
    
}