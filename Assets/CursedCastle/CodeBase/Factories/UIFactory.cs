using UnityEngine;

namespace CursedCastle.CodeBase.Factories
{
    public class UIFactory : IUIFactory
    {
        private Transform _uiRoot;
        private const string INVENTORY_PATH = "UI/Inventory";
        private const string UI_ROOT_PATH = "UI/UiRoot";

        public void CreateUiRoot()
        {
            GameObject uiRootPref = Resources.Load<GameObject>(UI_ROOT_PATH);
            _uiRoot = Object.Instantiate(uiRootPref).transform;
        }

        public GameObject CreateInventory()
        {
            GameObject inventory = Resources.Load<GameObject>(INVENTORY_PATH);
            return Object.Instantiate(inventory, _uiRoot);
        }
    }
}