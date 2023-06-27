using System.Collections.Generic;

namespace CursedCastle.CodeBase.Inventory
{
    public interface IInventoryRepository
    {
        void AddItem(IItemModel itemBase);
        void RemoveItem(IItemModel itemBase);
        void SelectItem(IItemModel itemBase);
        void DeselectItem(IItemModel itemBase);
        IReadOnlyList<IItemModel> Items { get; }
    }
}