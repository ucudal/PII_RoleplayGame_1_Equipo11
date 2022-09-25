using System;
using Inventory;
using Characters;
using System.Collections.Generic;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            ICharacter elf1 = new Elves("Ragnar", new Weapons("Elf Hammer"), new Armors("Iron Helmet"), new MagicItems("Rabbit´s Foot"));
            //Primera instancia de un elf
            ICharacter dwarf1 = new Dwarves("Grimli",new Weapons("Mythril BattleAxe"), new Armors("Dwarf heavy Chain Chesplate"));
            Console.WriteLine(elf1.Armor); 
            Console.WriteLine(dwarf1.Armor); 

        }
    }
}
