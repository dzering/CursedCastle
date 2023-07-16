using CursedCastle.CodeBase.Character.Interaction;
using UnityEngine;
using UnityEngine.Serialization;

namespace CursedCastle.CodeBase.Loot
{
    public class LootPiece : MonoBehaviour, ILoot
    {
        [SerializeField] private LootTypeID lootTypeID;
        public LootTypeID LootTypeID => lootTypeID;
        public void PickUp() => 
            Destroy(gameObject);
    }
}