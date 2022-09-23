using System;
using Inventory;
using Characters;

namespace Program
{
    class Program
    {
        static void Main(string[] args)
        {
            Weapons elfInitialWeapon= new Weapons("Elf Hammer", 5);
            //instancia del arma con la que comienza todo personaje Elf (arma predeterminada)
            Armors elfInitialArmor= new Armors("Iron Helmet", 9);
            //instancia de armadura con la que comienza todo personaje Elf (armadura predeterminada)
            MagicItems elfInitialMagicItem= new MagicItems("Rabbit's Foot"); //queda pendiente desarrollar magicItems(despues hay que hacer los cambios necesarios aca)
            //instancia de item magico con el que comienza todo personaje Elf (item predeterminada)
            ICharacter elf1= new Elves("Ragnar", elfInitialWeapon, elfInitialArmor,elfInitialMagicItem);
            //Primera instancia de un elf
        }
    }
}
