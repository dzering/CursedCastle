using CursedCastle.CodeBase.Character.Selector;

namespace CursedCastle.CodeBase.Loot
{
    public interface ILoot : ISelectable
    {
        LootTypeID LootTypeID { get; }
        void PickUp();
    }
}