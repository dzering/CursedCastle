using UnityEngine;

namespace CursedCastle.CodeBase.Loot
{
    public class LootPiece : MonoBehaviour
    {
        public LootTypeID LootTypeID;
        public GameObject Model;

        public void PickUp()
        {
            Destroy(gameObject);
        }
    }
}