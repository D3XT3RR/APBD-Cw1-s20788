using APBD_Cw1_s20788.Exceptions;
using APBD_Cw1_s20788.Models;

namespace APBD_Cw1_s20788.Repositories;

public class EquipmentRepository
{
    private readonly List<Item> _items = [];
    
    public void Add(Item item)
    {
        _items.Add(item);
    }
    public IEnumerable<Item> GetAll()
    {
        return _items.AsReadOnly();
    }
    public Item Get(int id)
    {
        var item = _items.Find(e => e.Id == id);
        return item ?? throw new ItemNotFoundException(id);
    }
}