    using System;
using UnityEngine;

namespace CursedCastle.CodeBase.Character.Selector
{
    [CreateAssetMenu(fileName = nameof(SelectableValue), menuName = "Containers/" + nameof(SelectableValue))]
    public class SelectableValue : ScriptableObject
    {
        public ISelectable CurrentValue { get; private set; }
        public Action<ISelectable> OnSelected;

        public void SetValue(ISelectable selectable)
        {
            CurrentValue = selectable;
            OnSelected?.Invoke(CurrentValue);
        }


    }
}