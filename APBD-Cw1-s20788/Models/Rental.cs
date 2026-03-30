using APBD_Cw1_s20788.Enums;

namespace APBD_Cw1_s20788.Models;

public class Rental(int id, DateTime startDate, User user, Item item): Entity(id)
{
    
    public User User { get; set; } = user;
    public Item Item { get; set; } = item;
    public DateTime StartDate { get; set; } = startDate;
    public DateTime? ReturnDate { get; set; }
    
    public RentStatus Status => ReturnDate is null ? RentStatus.Returned : RentStatus.Active;
    
}