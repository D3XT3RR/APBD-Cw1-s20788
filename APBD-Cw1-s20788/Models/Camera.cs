using APBD_Cw1_s20788.Enums;

namespace APBD_Cw1_s20788.Models;

public class Camera(int id, string name, EquipmentStatus status, bool isMirrorless, int megapixels): Item(id, name, status)
{
    public bool IsMirrorless { get; set; } = isMirrorless;
    public int Megapixels { get; set; } = megapixels;
    
}