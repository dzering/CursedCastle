namespace CursedCastle.CodeBase.InventorySystem
{
    public interface IInventoryUi
    {
        void SelectItem(InventoryItemUI itemUI);
        public InventoryItemUI SelectedItem { get; set; }
    }
}