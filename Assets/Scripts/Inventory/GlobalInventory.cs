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
        while (inventory.Items.Count > 0)
        {
            var item = inventory.Items[0];
            if (TryAddItem(item))
            {
                inventory.RemoveItem(item);
            }
        }
    }
}