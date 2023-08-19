using System.Collections.Generic;

public interface IInventory
{
    List<ItemData> Items { get; }
    int MaxCount { get; }
    bool TryAddItem(ItemData item);
    void RemoveItem(ItemData item);
}