using APBD_Cw1_s20788.Enums;

namespace APBD_Cw1_s20788.Models;

public class Projector(int id, string name, EquipmentStatus status, bool is3dCompatible, int lumens): Item(id, name, status)
{
    public bool Is3dCompatible { get; set; } = is3dCompatible;
    public int Lumens { get; set; } = lumens;
    
}