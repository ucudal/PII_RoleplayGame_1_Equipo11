using System;
using Characters;
using Inventory;

namespace NPC;

public class BlackSmith //:IInventory, IBalance
{
    public void Repair(ICharacter character, IItems item)
    {
        if (character.Inventory.Contains(item))
        {
            int repairCost = ((100 - item.Durability) * 2) / 10; //simple regla de tres que establece que cada 10% que se arregla, 
                                                                 //se cobran 2 coins; y calcula cuanto cuesta arreglar el item hasta llegar a 100%
            if (character.Transaction(false, repairCost)) //tiene suficientes coins
            {
                item.Durability = 100;
            }
            else
            {

                int repairedDurability = (character.GetCoins() * 10) / 2; //regla de tres que establece cuanto porcentaje arreglar de acuerdo a las coins que tiene
                repairCost = (repairedDurability * 2) / 10; //calculo cuanto costo el arreglo realizado
                item.Durability = +repairedDurability;
                character.Transaction(false, repairCost);
            }
            ConsolePrinter.ReparationPrinter(character, item);
        }
        else
        {
            ConsolePrinter.ItemNotEquipped(item);
        }
    }
    public void Enchantment(ICharacter character, IItems item)
    {
        if (character.Inventory.Contains(item))
        {
            //El precio de encanar un item, es igual al de compra en la tienda; es como comprarlo por segunda vez
            int enchantmentCost= ItemsStore.Prices[item.name];
            if (character.Transaction(false, enchantmentCost))
            {
                ConsolePrinter.EnchantmentPrinter(character, item);
            }
            else
            {
                ConsolePrinter.NotEnoughCoins();
            }
        }
        else
        {
            ConsolePrinter.ItemNotEquipped(item);
        }
    }
}