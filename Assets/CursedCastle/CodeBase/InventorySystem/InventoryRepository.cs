using System.Collections.Generic;

namespace CursedCastle.CodeBase.InventorySystem
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly List<IItem> _items = new List<IItem>();
        public IReadOnlyList<IItem> Items => _items;

        public void AddItem(IItem item)
        {
            _items.Add(item);
        }

        public void RemoveItem(IItem item)
        {
            _items.Remove(item);
        }

        public void SelectItem(IItem itemBase)
        {
            
        }

        public void DeselectItem(IItem itemBase)
        {
        }

    }
}