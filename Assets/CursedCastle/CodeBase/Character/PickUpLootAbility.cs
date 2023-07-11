using CursedCastle.CodeBase.Character.Selector;
using CursedCastle.CodeBase.Infrastructure;
using CursedCastle.CodeBase.InventorySystem;
using CursedCastle.CodeBase.Loot;
using CursedCastle.InputSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace CursedCastle.CodeBase.Character
{
    public class PickUpLootAbility : MonoBehaviour
    {
        [SerializeField] private InventoryService inventory;
        [SerializeField] private SelectableValue selectableValue;
        private IInputService _input;

        public void Construct(IInputService input)
        {
            _input = input;    //Add to create Character
            _input.StarterAssetsInputs.OnPickUpObject += PickUp;
        }

        private void PickUp()
        {
            ISelectable selectable = selectableValue.CurrentValue;
            if (selectable is ILoot loot)
            {
                inventory.AddItem(new RepositoryItem(loot.LootTypeID));
                selectableValue.SetValue(null);
                loot.PickUp();
            }
        }
    }
}