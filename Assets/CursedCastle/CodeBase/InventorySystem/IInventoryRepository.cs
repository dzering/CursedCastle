using System.Collections.Generic;

namespace CursedCastle.CodeBase.InventorySystem
{
    public interface IInventoryRepository
    {
        void AddItem(IItem item);
        void RemoveItem(IItem item);
        IReadOnlyList<IItem> Items { get; }
    }
}