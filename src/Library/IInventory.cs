using System;
using Characters;
using Inventory;
namespace Inventory;
using System.Collections.Generic;
public interface IInventory
{
    public List<Weapons> WeaponInventory { get; set; }
    void InventoryAdd(Weapons weapon);
    void InventoryRemove(Weapons weapon);
    public void Equip(Weapons weapon); //equipamiento de items --> afecta al inventario
    public void WeaponUnequip(); //desequipamiento de items --> afecta al inventario
    //public void Specialty(); no se puede porque los elfos necesitan el parametro (ally), que no aplica a wizards y dwarves
    //__________________
    public List<Armors> ArmorInventory { get; set; }
    void InventoryAdd(Armors armor);
    void InventoryRemove(Armors armor);
    public void Equip(Armors armor); 
    public void ArmorUnequip();
}

