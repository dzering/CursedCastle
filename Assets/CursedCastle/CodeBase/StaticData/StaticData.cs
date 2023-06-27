using UnityEngine;
using UnityEngine.UI;

namespace CursedCastle.CodeBase.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Loot", fileName = nameof(LootStaticData))]
    public class LootStaticData : ScriptableObject
    {
        public LootTypeID LootID;
        public Image Image;
        public GameObject prefab;
    }
}