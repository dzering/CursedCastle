using UnityEngine;

namespace CursedCastle.CodeBase.Character.Selector
{
    public class OutlineSelectorPresenter : MonoBehaviour
    {
        [SerializeField] private SelectableValue _selectable;

        private OutlineSelector[] _outlineSelectors;
        private ISelectable _currentSelectable;

        private void Start()
        {
            _selectable.OnSelected += onSelected;
            onSelected(_selectable.CurrentValue);
        }

        private void onSelected(ISelectable selectable)
        {
            if(_currentSelectable == selectable)
                return;
            
            _currentSelectable = selectable;
            SetSelected(_outlineSelectors, false);
            _outlineSelectors = null;

            if (selectable != null)
            {
                _outlineSelectors = (selectable as Component)?.GetComponentsInChildren<OutlineSelector>();
                    SetSelected(_outlineSelectors, true);
            }
        }

        static void SetSelected(OutlineSelector[] selectors, bool value)
        {
            if (selectors != null)
                foreach (OutlineSelector selector in selectors)
                    selector.SetSelected(value);
        }
    }
}