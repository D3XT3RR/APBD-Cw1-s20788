using APBD_Cw1_s20788.Enums;

namespace APBD_Cw1_s20788.Models;

public class Laptop(string name, EquipmentStatus status, bool hasDedicatedGpu, int gpuMemory): Item(name, status)
{
    public bool HasDedicatedGpu { get; set; } = hasDedicatedGpu;
    public int GpuMemory { get; set; } = gpuMemory;
    
}