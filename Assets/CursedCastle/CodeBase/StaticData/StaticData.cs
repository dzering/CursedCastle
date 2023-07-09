using CursedCastle.CodeBase.Loot;
using UnityEngine;

namespace CursedCastle.CodeBase.StaticData
{
    [CreateAssetMenu(menuName = "StaticData/Loot", fileName = nameof(LootStaticData))]
    public class LootStaticData : ScriptableObject
    {
        public LootTypeID LootID;
        public Sprite Sprite;
        public GameObject prefab;
    }
}