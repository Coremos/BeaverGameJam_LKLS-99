using System.Collections.Generic;

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
        Items.Remove(item);
    }

    public void ClearItems()
    {
        Items.Clear();
    }
}