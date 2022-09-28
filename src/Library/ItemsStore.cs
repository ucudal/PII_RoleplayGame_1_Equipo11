using System;
using System.Collections.Generic;

namespace Inventory;

public class ItemsStore //Esto serian todas los items disponibles a conseguir, puse 3 como ejemplo nomas
{
    public static Dictionary <string, int> Weapons= new Dictionary<string, int> 
    {
        {"Elf Hammer", 6}, 
        {"Ultimate Sword", 32},
        {"Viking Axe", 15},
        {"Wizard Melee",20},
        {"Spear", 8},
        {"Mythril BattleAxe",26},
        {"Rabadons Hat", 20},
    }; //asocia nombres de armas con el daño que infligen
    //se incluyen tanto armas predeterminadas (iniciales) de cada personaje como aquellas adquiribles desde la tienda

    public static Dictionary <string, int> Armors= new Dictionary<string, int> 
    {
        {"Iron Helmet", 10}, //armadura predeterminada de los elfos
        {"Merlin Cape", 10},
        {"Spirit Belt", 5},
        {"Guardian Chest", 4},
        {"Dwarf heavy Chain Chesplate",12}
    }; //asocia nombres de armaduras con la proteccion que otorgan
    
    public static Dictionary <string, string> Items= new Dictionary<string, string> 
    {
        {"Rabbit's Foot", "Fortune"}, //item predeterminado de los elfos
        {"Book of Spells", "Magic"}, 
        {"Wizard Cloak", "Camouflage"},
        {"Golden Crown", "Fortune"},
    }; //asocia items con el poder que ofrecen
    public static Dictionary <string, int> Prices= new Dictionary<string, int>
    {
        {"Ultimate Sword", 69},
        {"Viking Axe", 13},
        {"Rabadons Hat",40},
        {"Wizard Melee",0},
        {"Spear", 7},
        {"Merlin Cape", 32},
        {"Spirit Belt", 18},
        {"Guardian Chest", 12},
        {"Book of Spells", 35}, 
        {"Wizard Cloak", 22},
        {"Golden Crown", 63},
        {"Dwarf heavy Chain Chesplate",40},
        {"Mythril BattleAxe",50}
    }; //asocia armas/armaduras/items a su precio de venta; aquellas predeterminadas de cada personaje no se pueden comprar, razon por la cual no se incluyen aqui

    public static int GetPrice(Armors armor)
    {
        return Prices.GetValueOrDefault(armor.Name,99999999);
    }
        public static int GetPrice(Weapons weapon)
    {
        return Prices.GetValueOrDefault(weapon.Name,99999999);
    }
}
/*NOTAS:
Hay que crear muchos mas elementos
Se podria hacer una funcionabilidad de "caja sorpresa" que genere un numero random y de ahi acceda al item que haya tocado (buscando indice)
Como los diccionarios no funcionan cpn indices enteros, se deberia crear una lista
Se podria hacer que la lista contenga elementos "legendarios" que solo se pueden obtener a traves de las cajas
*/