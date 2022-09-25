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

            ICharacter wizard = new Wizards("Kassadin", new Weapons("Rabadon's hat"), new Armors("Merlin Cape"), new MagicItems("Book of spells"));
            //Primer instancia de un Wizard
        }
    }
}
