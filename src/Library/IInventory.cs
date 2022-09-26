using System;
using Characters;
using Inventory;
namespace Inventory;
using System.Collections.Generic;
public interface IInventory
{
    public List<Weapons> WeaponInventory { get; set; }
    void WeaponInventoryAdd(Weapons weapon);
    void WeaponInventoryRemove(Weapons weapon);
    public void WeaponEquip(Weapons weapon); //equipamiento de items --> afecta al inventario
    public void WeaponUnequip(); //desequipamiento de items --> afecta al inventario
    //public void Specialty(); no se puede porque los elfos necesitan el parametro (ally), que no aplica a wizards y dwarves
    //__________________
    public List<Armors> ArmorInventory { get; set; }
    void ArmorInventoryAdd(Armors armor);
    void ArmorInventoryRemove(Armors armor);
    public void ArmorEquip(Armors armor); 
    public void ArmorUnequip();
}

