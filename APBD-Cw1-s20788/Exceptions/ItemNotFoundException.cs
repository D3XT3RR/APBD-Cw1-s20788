namespace APBD_Cw1_s20788.Exceptions;

public class ItemNotFoundException(int id): NotFoundException($"Item not found with id: {id}")
{
    
}