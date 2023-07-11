using CursedCastle.CodeBase.Character.Selector;
using UnityEngine;

namespace CursedCastle.CodeBase.Loot
{
    public class LootPiece : MonoBehaviour, ILoot
    {
        [SerializeField] private LootTypeID lootTypeID;
        public LootTypeID LootTypeID => lootTypeID;

        public void PickUp()
        {
            Destroy(gameObject);
        }
    }

    public interface ILoot : ISelectable
    {
        LootTypeID LootTypeID { get; }
        void PickUp();
    }
}