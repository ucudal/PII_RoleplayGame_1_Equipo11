using System;
using Characters;

namespace Inventory;

public interface IItems
{
    public void Equip(ICharacter character); //equipamiento de items --> afecta al inventario
    public void Desequip(ICharacter character); //desequipamiento de items --> afecta al inventario
    public void Break(ICharacter character); //item se rompe luego de determinada cantidad de usos

}