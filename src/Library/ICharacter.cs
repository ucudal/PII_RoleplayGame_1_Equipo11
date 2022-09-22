using System;
using System.Collections.Generic;
using Inventory;

namespace Characters;

public interface ICharacter
{
    List<Armors> Armors {get; set;}
    int HP { get; set;}
    int Coins { get; set;}
    void Attack(Weapons weapon, ICharacter defender);
    void Equip(IItems item); //Para equipar nuevas armaduras/armas/objetos
    void Remove(IItems item); //Para deshacerse de armaduras/armas/objetos

}
