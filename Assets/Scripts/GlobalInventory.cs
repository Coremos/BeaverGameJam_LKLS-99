using System.Collections.Generic;

public class GlobalInventory : IInventory
{
    public List<ItemData> Items { get; private set; }
    public int MaxCount => int.MaxValue;

    public GlobalInventory()
    {
        Items = new List<ItemData>();
    }

    public bool TryAddItem(ItemData item)
    {
        if (Items.Count >= MaxCount) return false;
        Items.Add(item);
        return true;
    }

    public void RemoveItem(ItemData item)
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
    public List<ItemData> Items { get; set; }
    public int MaxCount => 4;

    public PlayerInventory()
    {
        Items = new List<ItemData>();
    }

    public bool TryAddItem(ItemData item)
    {
        if (Items.Count >= MaxCount) return false;
        Items.Add(item);
        return true;
    }

    public void RemoveItem(ItemData item)
    {

    }
}

public interface IInventory
{
    List<ItemData> Items { get; }
    int MaxCount { get; }
    bool TryAddItem(ItemData item);
    void RemoveItem(ItemData item);
}