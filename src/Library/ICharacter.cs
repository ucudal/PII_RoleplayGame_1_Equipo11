using System;

namespace Characters;

public interface ICharacter
{
    int HP { get; set; }
    int Attack();
    void Equip(); //Para equipar nuevas armaduras o armas
    void Remove(); //Para deshacerse de armaduras o armas; 
                   //se podria hacer una funcionalidad de inventario que solo permita una limitada cantidad de items


}
