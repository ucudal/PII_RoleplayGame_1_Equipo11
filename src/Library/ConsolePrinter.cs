using System;
using Inventory;
using NPC;
using Combat;

namespace Characters;

public class ConsolePrinter
{
    public static void DeathPrinter(ICharacter character)
    {
        Console.WriteLine($"¡\"{character.Name}\" could not survive the attack! ¡Finish him!");
    }
    public static void AlivePrinter( ICharacter character)
    {
        Console.WriteLine($"\"{character.Name}\" is still alive: {character.GetHP()} HP.");
    }
    public static void EnchantmentPrinter(ICharacter character, IItems item)
    {
        Console.WriteLine($"{item.name}´s power has now increased up to {item.Power}.");
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