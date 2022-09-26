using System;
using Characters;
using Inventory;

namespace NPC;

public class BlackSmith
{
    public void ArmorRepair(ICharacter character, Armors Armor)
    {
        if (character.ArmorInventory.Contains(Armor))
        {
            int repairCost = ((100 - Armor.Durability) * 2) / 10; //simple regla de tres que establece que cada 10% que se arregla, 
                                                                 //se cobran 2 coins; y calcula cuanto cuesta arreglar el item hasta llegar a 100%
            if (character.Transaction(false, repairCost)) //tiene suficientes coins
            {
                Armor.Durability = 100;
            }
            else
            {

                int repairedDurability = (character.GetCoins() * 10) / 2; //regla de tres que establece cuanto porcentaje arreglar de acuerdo a las coins que tiene
                repairCost = (repairedDurability * 2) / 10; //calculo cuanto costo el arreglo realizado
                Armor.Durability = +repairedDurability;
                character.Transaction(false, repairCost);
            }
            ConsolePrinter.ReparationPrinter(character, Armor);
        }
        else
        {
            ConsolePrinter.NotInInventory(Armor);
        }
    }
    public void ArmorEnchantment(ICharacter character, Armors Armor)
    {
        if (character.ArmorInventory.Contains(Armor))
        {
            //El precio de encanar un item, es igual al de compra en la tienda; es como comprarlo por segunda vez
            int enchantmentCost= ItemsStore.Prices[Armor.name];
            if (character.Transaction(false, enchantmentCost))
            {
                ConsolePrinter.EnchantmentPrinter(character, Armor);
            }
            else
            {
                ConsolePrinter.NotEnoughCoins();
            }
        }
        else
        {
            ConsolePrinter.NotInInventory(Armor);
        }
    }
//-----------------weapons------------------
    public void WeaponRepair(ICharacter character, Weapons weapon)
    {
        if (character.WeaponInventory.Contains(weapon))
        {
            int repairCost = ((100 - weapon.Durability) * 2) / 10; //simple regla de tres que establece que cada 10% que se arregla, 
                                                                 //se cobran 2 coins; y calcula cuanto cuesta arreglar el item hasta llegar a 100%
            if (character.Transaction(false, repairCost)) //tiene suficientes coins
            {
                weapon.Durability = 100;
            }
            else
            {

                int repairedDurability = (character.GetCoins() * 10) / 2; //regla de tres que establece cuanto porcentaje arreglar de acuerdo a las coins que tiene
                repairCost = (repairedDurability * 2) / 10; //calculo cuanto costo el arreglo realizado
                weapon.Durability = +repairedDurability;
                character.Transaction(false, repairCost);
            }
            ConsolePrinter.ReparationPrinter(character, weapon);
        }
        else
        {
            ConsolePrinter.NotInInventory(weapon);
        }
    }
    public void WeaponEnchantment(ICharacter character, Weapons weapon)
    {
        if (character.WeaponInventory.Contains(weapon))
        {
            //El precio de encanar un item, es igual al de compra en la tienda; es como comprarlo por segunda vez
            int enchantmentCost= ItemsStore.Prices[weapon.name];
            if (character.Transaction(false, enchantmentCost))
            {
                ConsolePrinter.EnchantmentPrinter(character, weapon);
            }
            else
            {
                ConsolePrinter.NotEnoughCoins();
            }
        }
        else
        {
            ConsolePrinter.NotInInventory(weapon);
        }
    }

}