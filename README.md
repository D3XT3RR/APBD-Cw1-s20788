# APBD-Cw1-s20788
W projekcie klasy zostały podzielone ze względu na odpowiedzialności: Mamy klasy Service, które odpowiadają za logikę biznesową. Stałe są przechowywane w klasach statycznych. Repozytoria odpowiadają za aktualizację list obiektów. Dodatkowo każdy serwis odpowiada za "swoje" rzeczy RentalService odpowiada za obsługę wypożyczeń, a EquipmentService za obsługę sprzętu - np tworzenie i dodawanie do repozytorium. 

O coupling zadbałem poprzez brak mieszania UI, Serwisów i Repozytoriów. 
Główny program komunikuje się tylko z Serwisami, Serwisy tylko z Repozytorium.