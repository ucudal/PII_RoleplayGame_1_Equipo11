using System;
using Inventory;
using Characters;
using WizardCharacter;
using System.Collections.Generic;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            ICharacter elf1 = new Elves("Ragnar", new Weapons("Elf Hammer"), new Armors("Iron Helmet"), new MagicItems("Rabbit´s Foot"));
            //Primera instancia de un elf
<<<<<<< HEAD
            ICharacter dwarf1 = new Dwarves("Grimli",new Weapons("Mythril BattleAxe"), new Armors("Dwarf heavy Chain Chesplate"));
            Console.WriteLine(elf1.Armor); 
            Console.WriteLine(dwarf1.Armor); 

=======
>>>>>>> d0646abb912fc79967af2d43309a71ea21ce0033

            ICharacter wizard = new Wizards("Kassadin", new Weapons("Rabadons Hat"), new Armors("Merlin Cape"), new MagicItems("Book of spells"));
            //Primer instancia de un Wizard
            Console.WriteLine(wizard.Weapon.WeaponName);
        }
    }
}
