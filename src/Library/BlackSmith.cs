using System;
using Characters;
using Inventory;

namespace NPC;

public class BlackSmith  //:IInventory, IBalance
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
                Console.WriteLine($"{item.name} has been fully repaired.");
                Console.WriteLine($"\"{character.Name}\" now has an amount of {character.GetCoins()} coins.");
            }
            else
            {

                int repairedDurability = (character.GetCoins() * 10) / 2; //regla de tres que establece cuanto porcentaje arreglar de acuerdo a las coins que tiene
                repairCost = (repairedDurability * 2) / 10; //calculo cuanto costo el arreglo realizado
                item.Durability = +repairedDurability;
                character.Transaction(false, repairCost);
                Console.WriteLine($"{item.name} has been repaired up to {item.Durability}");
                Console.WriteLine($"\"{character.Name}\" now has an amount of {character.GetCoins()} coins.");
            }
        }
        else
        {
            Console.WriteLine($"¡Cheater! You don't equip \"{item.name}\". ¡Get out of my sight! if you appreciate your life.");
        }
    }
    public void Enchantment(ICharacter character, IItems item)
    {
        if (character.Inventory.Contains(item))
        {
            
        }
        else
        {
            Console.WriteLine($"¡Cheater! You don't equip \"{item.name}\". ¡Get out of my sight! if you appreciate your life.");
        }
    }
}