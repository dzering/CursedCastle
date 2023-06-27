using System.Collections.Generic;

namespace CursedCastle.CodeBase.Inventory
{
    public class InventoryRepository : IInventoryRepository
    {
        private List<IItemModel> _items;
        public IReadOnlyList<IItemModel> Items => _items;

        public void AddItem(IItemModel itemBase)
        {
            _items.Add(itemBase);
        }

        public void RemoveItem(IItemModel itemBase)
        {
            _items.Remove(itemBase);
        }

        public void SelectItem(IItemModel itemBase)
        {
            
        }

        public void DeselectItem(IItemModel itemBase)
        {
        }

    }
}