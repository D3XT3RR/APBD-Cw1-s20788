using APBD_Cw1_s20788.Enums;
using APBD_Cw1_s20788.Exceptions;
using APBD_Cw1_s20788.Models;
using APBD_Cw1_s20788.Repositories;
using APBD_Cw1_s20788.Services;



var userRepository = new UserRepository();
var equipmentRepository = new EquipmentRepository();
var rentalRepository = new RentalRepository();

var rentalService = new RentalService(rentalRepository, userRepository, equipmentRepository);
var userService = new UserService(userRepository);
var equipmentService = new EquipmentService(equipmentRepository);

// Dodanie nowego użytkownika do systemu
var user = userService.CreateUser("Bartosz", "Żarłok", UserType.Employee);
var user2 = userService.CreateUser("Bartłomiej", "Żarłok",  UserType.Student);

Console.WriteLine("All users:");
var users = userRepository.GetAll();
foreach (var u in users)
{
    Console.WriteLine(u);
}

//Dodanie nowego sprzętu danego typu
var laptop = equipmentService.CreateLaptop("MacBook Pro", true, 16);
var camera = equipmentService.CreateCamera("Canon EOS 100D", false, 12);
var projector = equipmentService.CreateProjector("Epson CO-W01", false, 3000);

//Wyświetlenie listy całego sprzętu z aktualnym statusem
Console.WriteLine("All equipment:");
var equipment = equipmentService.GetAll();
foreach (var e in equipment)
{
    Console.WriteLine(e);
}



//Oznaczenie sprzętu jako niedostępnego
equipmentService.MarkAsBroken(projector.Id);
Console.WriteLine($"Projector {projector.Id} marked as broken.");

//Wyświetlenie wyłącznie sprzętu dostępnego do wypożyczenia
Console.WriteLine("Available equipment:");
var availableEquipment = equipmentService.GetAvailable();
foreach (var e in availableEquipment)
{
    Console.WriteLine(e);
}

//Wypożyczenie sprzętu użytkownikowi
var rental = rentalService.RentEquipment(user.Id, laptop.Id, new DateTime(2026, 1,1));
availableEquipment = equipmentService.GetAvailable();
foreach (var e in availableEquipment)
{
    Console.WriteLine(e);
}

//Wyświetlenie listy przeterminowanych wypożyczeń
Console.WriteLine("Overdue rentals:");
var overdueRentals = rentalService.GetOverdueRentals();
foreach (var r in overdueRentals)
{
    Console.WriteLine(r);
}

//Wyświetlenie listy aktywnych wypożyczeń danego użytkownika
Console.WriteLine("Active rentals:");
var activeRentals = rentalService.GetActiveRentalsByUser(user.Id);
foreach (var r in activeRentals)
{
    Console.WriteLine(r);
}

//Próba wypożyczenia niedostępnego sprzętu sprzętu
try
{
    rentalService.RentEquipment(user.Id, projector.Id, DateTime.Now);
}
catch (ItemNotAvailableException e)
{
    Console.WriteLine(e.Message);
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}





//Zwrot sprzętu z przeliczeniem ewentualnej kary za opóźnienie
rental = rentalService.ReturnEquipment(rental.Id);
Console.WriteLine($"Rental {rental.Id} returned with penalty: {rental.Penalty}");

rental = rentalService.RentEquipment(user2.Id, laptop.Id, DateTime.Now);
Console.WriteLine($"Rental {rental.Id} created for user {user2.Id}.");
rental = rentalService.ReturnEquipment(rental.Id);
Console.WriteLine($"Rental {rental.Id} returned. Penalty: {rental.Penalty}");




