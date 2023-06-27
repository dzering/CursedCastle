using UnityEngine;

namespace CursedCastle.CodeBase.Inventory
{
    public class ItemModel : IItemModel
    {
        public string Name { get; }
        public Sprite Sprite { get; }

        public ItemModel(string name, Sprite sprite)
        {
            Name = name;
            Sprite = sprite;
        }
    }
}