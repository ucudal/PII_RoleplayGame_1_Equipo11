using System;
using System.Collections.Generic;
using Inventory;

namespace Characters;

public interface ICharacter
{
    Armors Armor {get; set;} //Lista que contiene las piezas de armadura del character
    Weapons Weapon {get; set;} //Lista que contiene las armas del character
    MagicItems MagicItem {get; set;} //Lista que contiene los items del character --> ver como hacer con los dwarves que no tienen habilidades magicas
    int HP { get; set;} //Health Points; permite fijar y modificar la vida de un personaje luego de reciber ataques
    int Coins { get; set;} //Dinero; permite fijar y modificar el dinero de un personaje luego de realizar compra/venta de objetos
    string Name {get;} //Nombre; permite el facil acceso al nombre del personaje en cuestion para su facil impresion en la consola (impresiones de interaccion: jugador-juego)
    void Attack(ICharacter defender); //metodo de ataque de un personaje a otro; permite elegir con que arma atacar en caso que el personaje disponga de varias

    bool IsAlive(); //indica si el character sigue vivo luego de haber recibido un ataque

   // void Steal(); se podria hacer un metodo que luego de un personaje matar a otro, le permita llotear un solo objeto 
}
