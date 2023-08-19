using System.Collections.Generic;

public class GlobalInventory : IInventory
{
    public List<IItem> Items { get; private set; }
    public int MaxCount => int.MaxValue;

    public GlobalInventory()
    {
        Items = new List<IItem>();
    }

    public bool TryAddItem(IItem item)
    {
        if (Items.Count >= MaxCount) return false;
        Items.Add(item);
        return true;
    }
    
    public void RemoveItem(IItem item)
    {
        Items.Remove(item);
    }

    public void ClearItems()
    {
        Items.Clear();
    }

    public void WriteInventory(IInventory inventory)
    {
        foreach (var item in inventory.Items)
        {
            if (TryAddItem(item))
            {
                inventory.RemoveItem(item);
            }
        }
    }
}

public class PlayerInventory : IInventory
{
    public List<IItem> Items { get; set; }
    public int MaxCount => 4;

    public PlayerInventory()
    {
        Items = new List<IItem>();
    }

    public bool TryAddItem(IItem item)
    {
        if (Items.Count >= MaxCount) return false;
        Items.Add(item);
        return true;
    }

    public void RemoveItem(IItem item)
    {

    }
}

public interface IInventory
{
    List<IItem> Items { get; }
    int MaxCount { get; }
    bool TryAddItem(IItem item);
    void RemoveItem(IItem item);
}

public interface IItem
{

}