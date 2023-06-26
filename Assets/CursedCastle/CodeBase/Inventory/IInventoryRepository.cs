using System.Collections.Generic;

namespace CursedCastle.CodeBase.Inventory
{
    public interface IInventoryRepository
    {
        void AddItem(IInventoryItem item);
        void RemoveItem(IInventoryItem item);
        void SelectItem(IInventoryItem item);
        void DeselectItem(IInventoryItem item);
        IReadOnlyList<IInventoryItem> Items { get; }
    }
}