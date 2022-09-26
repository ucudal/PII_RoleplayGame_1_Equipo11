using System;
using Inventory;
using Characters;
using NPC;
using Combat;
using System.Collections.Generic;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            ICharacter elf1 = new Elves("Ragnar", new Weapons("Elf Hammer"), new Armors("Iron Helmet"));
            //Primera instancia de un elf
            ICharacter dwarf1 = new Dwarves("Grimli",new Weapons("Mythril BattleAxe"), new Armors("Dwarf heavy Chain Chesplate"));
            

            ICharacter wizard = new Wizards("Kassadin", new Weapons("Rabadons Hat"), new Armors("Merlin Cape"), new MagicItems("Book of Spells"));
            Merchant.WeaponBuy(wizard, new Weapons("Ultimate Sword"));
            Console.WriteLine($"{wizard.WeaponInventory.ToString()}");
        }
    }
}
