using System;
using System.Collections.Generic;

namespace Inventory;

public class ItemsStore //Esto serian todas los items disponibles a conseguir, puse 3 como ejemplo nomas
{
    public static Dictionary <string, int> Weapons= new Dictionary<string, int> 
    {
        {"Ultimate Sword", 32},
        {"Viking Axe", 15},
        {"Spear", 8},
    };

    public static Dictionary <string, int> Armors= new Dictionary<string, int> 
    {
        {"Merlin Cape", 10},
        {"Spirit Belt", 5},
        {"Guardian Chest", 4},
    };
    
    public static Dictionary <string, string> Items= new Dictionary<string, string> 
    {
        {"Book of Spells", "Magic"}, 
        {"Wizard Cloak", "Camouflage"},
        {"Golden Crown", "Fortune"},
    };
//Estaria bueno de alguna forma poder asociar los strings "magic", "camouflage", "fortune" a habilidades 
}