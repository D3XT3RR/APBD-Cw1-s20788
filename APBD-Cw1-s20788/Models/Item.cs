using APBD_Cw1_s20788.Enums;

namespace APBD_Cw1_s20788.Models;

public abstract class Item(string name, EquipmentStatus status): Entity()
{
    public string Name { get; set; } = name;
    public EquipmentStatus Status { get; set; } = status;

    public override string ToString()
    {
        return $"Item {Id}: {Name} ({Status})";
    }
}