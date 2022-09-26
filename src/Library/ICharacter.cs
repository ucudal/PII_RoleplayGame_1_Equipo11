using System;
using System.Collections.Generic;
using Inventory;

namespace Characters;

public interface ICharacter
{
    Armors Armor { get; set; } //Lista que contiene las piezas de armadura del character
    Weapons Weapon { get; set; } //Lista que contiene las armas del character
    //MagicItems MagicItem {get; set;} //Lista que contiene los items del character --> ver como hacer con los dwarves que no tienen habilidades magicas
    int Damage { get; set; }

    //private int HP { get; set;} //Health Points; permite fijar y modificar la vida de un personaje luego de reciber ataques

    string Name { get; } //Nombre; permite el facil acceso al nombre del personaje en cuestion para su facil impresion en la consola (impresiones de interaccion: jugador-juego)
    //void Attack(ICharacter defender); //metodo de ataque de un personaje a otro; permite elegir con que arma atacar en caso que el personaje disponga de varias
    public int Strength { get; }
    bool IsAlive(); //indica si el character sigue vivo luego de haber recibido un ataque

    // void Steal(); se podria hacer un metodo que luego de un personaje matar a otro, le permita lootear un solo objeto 
    bool Transaction(bool operation, int value); //hace una transaccion ,el operation determina si se añade o pierde dinero, el bool determina si fue posible o no
    int GetCoins();  //get de coins
    void HPChanger(int value);
    int GetHP();
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
