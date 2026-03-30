using APBD_Cw1_s20788.Enums;
using APBD_Cw1_s20788.Rules;

namespace APBD_Cw1_s20788.Models;

public class Rental(User user, Item item, DateTime startDate): Entity
{
    
    public User User { get; set; } = user;
    public Item Item { get; set; } = item;
    public DateTime StartDate { get; set; } = startDate;
    public DateTime? ReturnDate { get; set; }
    
    public RentalStatus Status => ReturnDate is null ? RentalStatus.Active : RentalStatus.Returned;
    private DateTime DueDate => StartDate.AddDays(RentalRules.DefaultRentDuration);
    public decimal Penalty =>
        ReturnDate == null || ReturnDate <= DueDate
            ? 0
            : (ReturnDate.Value - DueDate).Days * RentalRules.PenaltyPerDay;
    public override string ToString()
    {
        return $"Rental ID: {Id}, User: {User.Id}, Item: {Item.Id}, Start Date: {StartDate}, Return Date: {ReturnDate}, Status: {Status}";
    }
    
    
}