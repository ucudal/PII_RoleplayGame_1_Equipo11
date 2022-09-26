using System;
using Characters;

namespace Inventory;

public interface IItems
{
    public void Equip(ICharacter character); //equipamiento de items --> afecta al inventario
    public void Desequip(ICharacter character); //desequipamiento de items --> afecta al inventario
    public void Break(ICharacter character); //item se rompe luego de determinada cantidad de usos
    public void Repair(ICharacter character); //reparacion de items --> afecta a la property "Coins" y a la durabilidad del item
    //public void Buy(ICharacter character); //compra de items --> afecta a la property "Coins" y al inventario
    //public void Sell(ICharacter character); //venta de items --> afecta a la property "Coins" y al inventario
   
    public string name{get;set;}

}