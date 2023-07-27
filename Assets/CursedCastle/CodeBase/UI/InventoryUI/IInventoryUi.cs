namespace CursedCastle.CodeBase.UI.InventoryUI
{
    public interface IInventoryUi
    {
        void SelectItem(InventoryItemUI itemUI);
        public InventoryItemUI SelectedItem { get; set; }
    }
}