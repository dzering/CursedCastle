using UnityEngine;

namespace CursedCastle.CodeBase.Inventory
{
    public interface IItemModel
    {
        string Name { get; }
        Sprite Sprite { get; }
    }
}