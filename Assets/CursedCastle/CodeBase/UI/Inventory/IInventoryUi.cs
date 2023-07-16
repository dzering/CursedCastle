namespace CursedCastle.CodeBase.UI.Inventory
{
    public interface IInventoryUi
    {
        void SelectItem(InventoryItemUI itemUI);
        public InventoryItemUI SelectedItem { get; set; }
    }
}