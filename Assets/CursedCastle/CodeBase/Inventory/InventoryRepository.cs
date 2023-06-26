using System.Collections.Generic;

namespace CursedCastle.CodeBase.Inventory
{
    public class InventoryRepository : IInventoryRepository
    {
        private List<IInventoryItem> _items;
        public IReadOnlyList<IInventoryItem> Items => _items;

        public void AddItem(IInventoryItem item)
        {
            _items.Add(item);
        }

        public void RemoveItem(IInventoryItem item)
        {
            _items.Remove(item);
        }

        public void SelectItem(IInventoryItem item)
        {
            
        }

        public void DeselectItem(IInventoryItem item)
        {
        }

    }
}