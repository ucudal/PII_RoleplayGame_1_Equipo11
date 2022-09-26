using System;
using System.Collections.Generic;
using Inventory;

namespace Characters;

public interface ICharacter
{
    //  Nombre del personaje
    string Name { get; } 

    //  Armor:  armadura activa del personaje
     Armors Armor { get; set; } 

    //  Weapon:  arma activa del personaje
    Weapons Weapon { get; set; } 

    //  Fuerza de cada personaje
    public int Strength { get; set; }

    //  Indica si el character sigue vivo luego de haber recibido un ataque
    bool IsAlive(); 

    // void Steal(); se podria hacer un metodo que luego de un personaje matar a otro, le permita lootear un solo objeto 

    //  Transaction:    el bool determina si se añade(true) o pierde(false) dinero, el int value indica la cantidad dinero añadida/restada
    bool Transaction(bool operation, int value); 

    //  Getter de coins
    int GetCoins();

    //  Modifica la vida de un personaje --> se pasa por parametro un entero que indica si incrementa/disminuye y en que proporcion  
    void HPChanger(int value);

    //  Getter de vida
    int GetHP();

//  WeaponInventory:    lista cuyos elementos son armas (de tipo Weapons)
    public List<Weapons> WeaponInventory { get; set; }
    void InventoryAdd(Weapons weapon);
    void InventoryRemove(Weapons weapon);
    public void Equip(Weapons weapon); //equipamiento de items --> afecta al inventario
    public void WeaponUnequip(); //desequipamiento de items --> afecta al inventario
    //public void Specialty(); no se puede porque los elfos necesitan el parametro (ally), que no aplica a wizards y dwarves


    //ArmorInventory:    lista cuyos elementos son piezas de armadura (de tipo Armors)
    public List<Armors> ArmorInventory { get; set; }
    void InventoryAdd(Armors armor);
    void InventoryRemove(Armors armor);
    public void Equip(Armors armor); 
    public void ArmorUnequip();
}

