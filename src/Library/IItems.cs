using System;
using Characters;

namespace Inventory;

public interface IItems
{
    
    void Break(ICharacter character); //item se rompe luego de determinada cantidad de usos
    int Durability { get; set; }
    int Power { get; set; }
    string Name { get; set; }

    void PowerChange(int value);

}