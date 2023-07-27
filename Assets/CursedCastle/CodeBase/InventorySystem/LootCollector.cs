using CursedCastle.CodeBase.Loot;
using UnityEngine;

namespace CursedCastle.CodeBase.InventorySystem
{
    public class LootCollector : MonoBehaviour
    {
        private Inventory _inventory;

        public void Start() => 
            _inventory = GetComponentInParent<Inventory>();

        private void OnTriggerEnter(Collider other)
        {
            LootPiece lootPiece = other.GetComponentInParent<LootPiece>();
            if (lootPiece!=null)
            { 
                _inventory.AddItem(new RepositoryItem(lootPiece.LootTypeID));
                lootPiece.PickUp();
            }
        }
    }
}
