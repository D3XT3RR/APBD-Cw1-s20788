using APBD_Cw1_s20788.Enums;
using APBD_Cw1_s20788.Exceptions;
using APBD_Cw1_s20788.Models;
using APBD_Cw1_s20788.Repositories;
using APBD_Cw1_s20788.Rules;

namespace APBD_Cw1_s20788.Services;

public class RentalService(RentalRepository rentalRepository, 
    UserRepository userRepository, 
    EquipmentRepository equipmentRepository): IRentalService
{
    public Rental RentEquipment(int userId, int itemId, DateTime? startDate)
    {
        if (userId <= 0 || itemId <= 0)
            throw new ArgumentException("User and item IDs must be positive");
        var user = userRepository.Get(userId);
        var item = equipmentRepository.Get(itemId);
        
        if (item.Status != EquipmentStatus.Available)
            throw new ItemNotAvailableException(itemId);

        if (rentalRepository.GetActiveRentalByUser(userId).Count() >= UserRules.GetMaxActiveRentals(user.Type))
            throw new MaxActiveRentalsReachedException(userId, UserRules.GetMaxActiveRentals(user.Type));
        
        var rental = new Rental(user, item, startDate ?? DateTime.Now);
        rental.Item.Status = EquipmentStatus.Rented;
        rentalRepository.Add(rental);
        return rental;
    }

    public Rental ReturnEquipment(int rentalId)
    {
        var rent = rentalRepository.Get(rentalId);
        rent.ReturnDate = DateTime.Now;
        rent.Item.Status = EquipmentStatus.Available;
        rentalRepository.Update(rent);
        return rent;
    }
    
    public IEnumerable<Rental> GetOverdueRentals()
    {
        return rentalRepository.GetActiveRentals()
            .Where(r => r.StartDate.AddDays(RentalRules.DefaultRentDuration) < DateTime.Now);
    }
    
    public IEnumerable<Rental> GetActiveRentalsByUser(int userId)
    {
        return rentalRepository.GetActiveRentalByUser(userId);
    }
}