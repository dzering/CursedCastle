using System.Collections.Generic;

namespace CursedCastle.CodeBase.InventorySystem
{
    public interface IInventoryRepository
    {
        void AddItem(IItem item);
        void RemoveItem(IItem item);
        void SelectItem(IItem itemBase);
        void DeselectItem(IItem itemBase);
        IReadOnlyList<IItem> Items { get; }
    }
}