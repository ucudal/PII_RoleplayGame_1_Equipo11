using System;
using System.Collections.Generic;
using Inventory;

namespace Characters;

public interface ICharacter
{
    List<Armors> Armors {get; set;}
    List<Weapons> Weapons {get; set;}
    List<MagicItems> MagicItems {get; set;}
    int HP { get; set;}
    int Coins { get; set;}
    string Name {get;}
    void Attack(Weapons weapon, ICharacter defender);

}
