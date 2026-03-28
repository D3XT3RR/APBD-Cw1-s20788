namespace APBD_Cw1_s20788.Models;

public abstract class Item(int id, string name, EquipmentStatus status): Entity(id)
{
    public string Name { get; set; } = name;
    public EquipmentStatus Status { get; set; } = status;
}