using CursedCastle.CodeBase.Character.Selector;
using UnityEngine;

namespace CursedCastle.CodeBase.Loot
{
    public class LootPiece : MonoBehaviour, ISelectable
    {
        public LootTypeID LootTypeID;
        public GameObject Model;

        public void PickUp()
        {
            Destroy(gameObject);
        }
    }
}