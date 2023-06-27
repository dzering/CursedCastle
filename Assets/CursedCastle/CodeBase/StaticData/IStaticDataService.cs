using CursedCastle.CodeBase.Infrastructure;
using CursedCastle.CodeBase.Loot;

namespace CursedCastle.CodeBase.StaticData
{
    public interface IStaticDataService : IService
    {
        void LoadLoot();
        LootStaticData ForLoot(LootTypeID lootTypeID);
    }
}