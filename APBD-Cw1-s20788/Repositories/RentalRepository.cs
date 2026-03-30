using APBD_Cw1_s20788.Enums;
using APBD_Cw1_s20788.Exceptions;
using APBD_Cw1_s20788.Models;
using APBD_Cw1_s20788.Rules;

namespace APBD_Cw1_s20788.Repositories;

public class RentalRepository
{
    private int _nextId = 1;
    private readonly List<Rental> _rentals = [];
    
    public Rental Add(Rental rental)
    {
        rental.Id = _nextId++;
        _rentals.Add(rental);
        return rental;
    }
    public IEnumerable<Rental> GetAll()
    {
        return _rentals.AsReadOnly();
    }
    
    public Rental Get(int id)
    {
        var item = _rentals.Find(e => e.Id == id);
        return item ?? throw new RentalNotFoundException(id);
    }
    
    public IEnumerable<Rental> GetRentalsByUser(int userId)
    {
        return _rentals.Where(r => r.User.Id == userId);
    }
    
    public IEnumerable<Rental> GetActiveRentalsByUser(int userId)
    {
        return _rentals.Where(r => r.User.Id == userId && r.Status == RentalStatus.Active);
    }
    
    public IEnumerable<Rental> GetActiveRentals()
    {
        return _rentals.Where(r => r.Status == RentalStatus.Active); }
    
    public IEnumerable<Rental> GetActiveRentalByUser(int userId)
    {
        return _rentals.Where(r => r.User.Id == userId && r.Status == RentalStatus.Active);
    }
    
    public Rental Update(Rental rental)
    {
        var index = _rentals.FindIndex(e => e.Id == rental.Id);
        if (index == -1)
            throw new RentalNotFoundException(rental.Id);
        _rentals[index] = rental;
        return rental;
    }
}