using CursedCastle.CodeBase.Loot;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CursedCastle.CodeBase.InventorySystem
{
    public class InventoryItem : MonoBehaviour
    {
        [HideInInspector] public LootTypeID LootTypeID; 
        [SerializeField] private Image _image;

        public void Construct(LootTypeID lootTypeID, Sprite sprite)
        {
            LootTypeID = lootTypeID;
            _image.sprite = sprite;
        }
    }
}
