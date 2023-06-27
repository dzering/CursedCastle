using CursedCastle.CodeBase.StaticData;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace CursedCastle.CodeBase.Inventory
{
    public class InventoryItem : MonoBehaviour
    {
        public LootTypeID LootTypeID; 
        [SerializeField] private TextMeshProUGUI _name;
        [SerializeField] private Image _image;

        public void Construct(IItemModel item)
        {
            _name.text = item.Name;
            _image.sprite = item.Sprite;
        }
    }
}
