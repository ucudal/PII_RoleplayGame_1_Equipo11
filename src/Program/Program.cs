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
            Weapons elfHammer= new Weapons("Elf Hammer");
            List<Weapons> elF1Weapons= new List<Weapons> (elfHammer);
            ICharacter elf1= new Elves("Ragnar", elF1Weapons );
            //Primera instancia de un elf
        }
    }
}
