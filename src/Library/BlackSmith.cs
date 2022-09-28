using System;
using Characters;
using Inventory;

namespace NPC;

public class BlackSmith
{
    public static void ArmorRepair(ICharacter character, Armors Armor)
    {
        //  Aseguro que el personaje disponga de la armadura
        if (character.ArmorInventory.Contains(Armor))
        {
            int repairCost = ((100 - Armor.Durability) * 2) / 10;
            /// simple regla de tres que establece que cada 10% que se arregla,
            /// se cobran 2 coins; y calcula cuanto cuesta arreglar el item hasta llegar a 100%

            if (character.Transaction(false, repairCost))
            {
                //tiene suficientes coins como para arreglarlo al maximo
                Armor.Durability = 100;
            }
            else
            {
                //regla de tres que establece cuanto porcentaje arreglar de acuerdo a las coins que tiene
                int repairedDurability = (character.GetCoins() * 10) / 2;

                //calculo cuanto costo el arreglo realizado
                repairCost = (repairedDurability * 2) / 10;

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
    public static void ArmorEnchantment(ICharacter character, Armors Armor)
    {
        if (character.ArmorInventory.Contains(Armor))
        {
            //El precio de encanar un item, es igual al de compra en la tienda; es como comprarlo por segunda vez
            int enchantmentCost = ItemsStore.Prices[Armor.Name];
            if (character.Transaction(false, enchantmentCost))
            {
                int powerUpgrade= Armor.Power/2; //Aumento del poder de la armadura en un 50%
                Armor.PowerChange(powerUpgrade);
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
    //-----------------weapons------------------ Repito operaciones solo que para un arma
    public static void WeaponRepair(ICharacter character, Weapons weapon)
    {
        if (character.WeaponInventory.Contains(weapon))
        {
            int repairCost = ((100 - weapon.Durability) * 2) / 10;

            if (character.Transaction(false, repairCost))
            {
                weapon.Durability = 100;
            }
            else
            {
                int repairedDurability = (character.GetCoins() * 10) / 2;
                repairCost = (repairedDurability * 2) / 10;
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
    public static void WeaponEnchantment(ICharacter character, Weapons weapon)
    {
        if (character.WeaponInventory.Contains(weapon))
        {
            int enchantmentCost = ItemsStore.Prices[weapon.Name];
            if (character.Transaction(false, enchantmentCost))
            {
                int powerUpgrade= weapon.Power/2; //Aumento del poder del arma en un 50%
                weapon.PowerChange(powerUpgrade);
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