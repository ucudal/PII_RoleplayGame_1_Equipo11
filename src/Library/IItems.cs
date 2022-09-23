using System;
using Characters;

namespace Inventory;

public interface IItems
{
    public void Equip(ICharacter character);
    public void Remove(ICharacter character);

}