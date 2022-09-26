using System;
using Inventory;
using NPC;
using Combat;

namespace Characters;

public class ConsolePrinter
{
    public static void EnchantmentPrinter(ICharacter character, IItems item)
    {
        Console.WriteLine($"{item.name}´power has now increased up to {item.Power}.");
        Console.WriteLine($"\"{character.Name}\" now has an amount of {character.GetCoins()} coins.");
    }
    public static void ReparationPrinter(ICharacter character, IItems item)
    {
        Console.WriteLine($"{item.name} has been repaired up to {item.Durability}.");
        Console.WriteLine($"\"{character.Name}\" now has an amount of {character.GetCoins()} coins.");
    }
    public static void ItemNotEquipped(IItems item)
    {
        Console.WriteLine($"¡Cheater! You don't equip \"{item.name}\". ¡Get out of my sight! if you appreciate your life.");
    }
    public static void NotEnoughCoins()
    {
        Console.WriteLine($"¡Miserable! You better come back with coins next time.");
    }
}