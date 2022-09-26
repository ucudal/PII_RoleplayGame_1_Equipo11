using System;
using Characters;

namespace Inventory;

public interface IItems
{
    
    public void Break(ICharacter character); //item se rompe luego de determinada cantidad de usos
    public int Durability { get; set; }
    public int Power { get; set; }
    public string name { get; set; }

}