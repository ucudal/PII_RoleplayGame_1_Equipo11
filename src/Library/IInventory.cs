using System;
using Characters;
using Inventory;

public interface IInventory
{
    void InventoryAdd(IItems item);
    void InventoryRemove(IItems item);
    public void Equip(IItems item); //equipamiento de items --> afecta al inventario
    public void Desequip(IItems item); //desequipamiento de items --> afecta al inventario*/
}

