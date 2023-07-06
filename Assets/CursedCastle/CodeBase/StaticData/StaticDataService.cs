using System.Collections.Generic;
using System.Linq;
using CursedCastle.CodeBase.Loot;
using UnityEngine;

namespace CursedCastle.CodeBase.StaticData
{
    public class StaticDataService : IStaticDataService
    {
        const string PATH_LOOT = "StaticData/Loot/";
        private Dictionary<LootTypeID, LootStaticData> _loots = new Dictionary<LootTypeID, LootStaticData>();
        
        public void LoadLoot() =>
            _loots = Resources
                .LoadAll<LootStaticData>(PATH_LOOT)
                .ToDictionary(x => x.LootID, x => x);

        public LootStaticData ForLoot(LootTypeID lootTypeID) => 
            _loots.TryGetValue(lootTypeID, out LootStaticData staticData) 
                ? staticData 
                : null;
    }
}