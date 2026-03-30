namespace APBD_Cw1_s20788.Exceptions;

public class ItemNotAvailableException(int id): Exception(message: $"Item with ID {id} is not available for rental")
{
    
}