using APBD_Cw1_s20788.Enums;
using APBD_Cw1_s20788.Models;
using APBD_Cw1_s20788.Repositories;

namespace APBD_Cw1_s20788.Services;

public class EquipmentService(EquipmentRepository equipmentRepository)
{
   
   public Projector CreateProjector(string name, bool is3dCompatible, int lumens)
   {
       var projector = new Projector(name, EquipmentStatus.Available, is3dCompatible, lumens);
       equipmentRepository.Add(projector);
       return projector;
   }
   
   public Laptop CreateLaptop(string name, bool hasDedicatedGpu, int gpuMemory)
   {
       var laptop = new Laptop(name, EquipmentStatus.Available, hasDedicatedGpu, gpuMemory);
       equipmentRepository.Add(laptop);
       return laptop;
   }
   
   public Camera CreateCamera(string name, bool isMirrorless, int megapixels)
    {
        var camera = new Camera(name, EquipmentStatus.Available, isMirrorless, megapixels);
        equipmentRepository.Add(camera);
        return camera;
    }
   
   public IEnumerable<Item> GetAll()
   {
       return equipmentRepository.GetAll();
   }
   
   public IEnumerable<Item> GetAvailable()
   {
       return equipmentRepository.GetAll().Where(item => item.Status == EquipmentStatus.Available);
   }

   public void MarkAsBroken(int id)
   {
       var item = equipmentRepository.Get(id);
       item.Status = EquipmentStatus.Broken;
       equipmentRepository.Update(item);
   }
   
}