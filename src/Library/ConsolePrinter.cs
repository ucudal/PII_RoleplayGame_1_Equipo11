using System;
using Inventory;
using NPC;
using Combat;
using System.Text;

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
        Console.WriteLine($"\"{item.name}´s\" power has now increased up to {item.Power}.");
        Console.WriteLine($"\"{character.Name}\" now has an amount of {character.GetCoins()} coins.");
    }
    public static void ReparationPrinter(ICharacter character, IItems item)
    {
        Console.WriteLine($"\"{item.name}\" has been repaired up to {item.Durability}.");
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
   public static void CharactersDeath(ICharacter character,ICharacter killer)
   {
        string DeathString = String.Join(
        Environment.NewLine,
        "  __________",
        "/   R.I.P.   \\",
        "| Here lies   |",
        $"| {character.Name,11} |",
        "|_____________|",
        $"In hands of {killer.Name}");
        
        Console.WriteLine(DeathString); 
   }


    public static void AttackOnTarget(ICharacter Attacker, ICharacter Deffender)
    {
        Console.WriteLine($"{Attacker.Name} has attacked {Deffender.Name}!");
    }

    public static void unsuccessfullAttack(ICharacter Attacker, ICharacter Deffender)
    {
        Console.WriteLine($"{Attacker.Name} could not perform his attack on {Deffender.Name}");
    }

    public static void brokenItem(IItems item)
    {
        Console.WriteLine($"Oh no, \"{item.name}\" has broken! You should fix it or buy another");
    }

    public static void aboutToGetBrokenItem(IItems item)
    {
        Console.WriteLine($"\"{item.name}\" is about to get broken, you should consider fixing it or buying another");
    }

    public static void equippedItem(ICharacter character, IItems item)
    {
        Console.WriteLine($"{character.Name} now equips \"{item.name}\".");
    }

    public static void unequippedItem(ICharacter character, IItems item)
    {
        Console.WriteLine($"{character.Name} has successfully unequipped \"{item.name}\"");
    }

    public static void notInInventoryItem()
    {
        Console.WriteLine($"You do not have this item in your inventory");
    }

    public static void spellSuccessfullyCast()
    {
        Console.WriteLine("¡Yes! The magic spell was casted succesfully. The spell is...");
    }

    public static void soldItem(ICharacter character,IItems item)
    {
        Console.WriteLine($"\"{item.name}\" has been successfully sold\n{character.Name} now has {character.GetCoins()} coins");
    }
}    
