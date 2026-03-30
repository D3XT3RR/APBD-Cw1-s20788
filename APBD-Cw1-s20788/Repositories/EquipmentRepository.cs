using APBD_Cw1_s20788.Exceptions;
using APBD_Cw1_s20788.Models;

namespace APBD_Cw1_s20788.Repositories;

public class EquipmentRepository
{
    private int _nextId = 1;
    private readonly List<Item> _items = [];
    
    public Item Add(Item item)
    {
        item.Id = _nextId++;
        _items.Add(item);
        return item;
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
    
    public void Update(Item item)
    {
        var index = _items.FindIndex(e => e.Id == item.Id);
        if (index == -1)
            throw new ItemNotFoundException(item.Id);
        _items[index] = item;
    }
}