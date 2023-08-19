using System.Collections.Generic;

public class Inventory
{
    public List<IItem> Items;

    public void AddItem(IItem item)
    {
        Items.Add(item);
    }
    
    public void RemoveItem(IItem item)
    {
        Items.Remove(item);
    }
}

public interface IItem
{

}