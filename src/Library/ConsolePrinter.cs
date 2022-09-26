using System;
using Inventory;
using NPC;
using Combat;
using System.Text;

namespace Characters;

public class ConsolePrinter
{

    //  Life State - Printers
    public static void DeathPrinter(ICharacter character,ICharacter killer)
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
    public static void AlivePrinter( ICharacter character)
    {
        Console.WriteLine($"\"{character.Name}\" is still alive: {character.GetHP()} HP.");
    }

    // Store - Printers
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
    public static void soldItem(ICharacter character,IItems item)
    {
        Console.WriteLine($"\"{item.name}\" has been successfully sold\n{character.Name} now has {character.GetCoins()} coins");
    }

    //  Action denied - Printers
    public static void NotInInventory(IItems item)
    {
        Console.WriteLine($"¡Cheater! You don't equip \"{item.name}\". ¡Get out of my sight! if you appreciate your life.");
    }
    public static void NotEnoughCoins()
    {
        Console.WriteLine($"¡Miserable! You better come back with coins next time.");
    }
   
    //Combat - Printers
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

    //  Inventory - Printers
    public static void equippedItem(ICharacter character, IItems item)
    {
        Console.WriteLine($"{character.Name} now equips \"{item.name}\".");
    }

    public static void unequippedItem(ICharacter character, IItems item)
    {
        Console.WriteLine($"{character.Name} has successfully unequipped \"{item.name}\"");
    }


    //Spell Printers
    public static void spellSuccessfullyCast()
    {
        Console.WriteLine("¡Yes! The magic spell was casted succesfully. The spell is...");
    }
    public static void FortuneSpell(ICharacter magician)
    {
        Console.WriteLine($"¡Fortune! {magician.Name}'s coins have been doubled; you now have {magician.GetCoins()}"); 
    }
    public static void CurativeSpell(ICharacter magician)
    {
        Console.WriteLine($"¡Healing Poiton! {magician.Name} gained 10 Health Points."); 
    }
    public static void PoisonSpell(ICharacter magician)
    {
        Console.WriteLine($"¡Oh no! The spell was Poison gas. {magician.Name} lost 10 Health Points."); 
    }
    public static void ItemEnchantmentSpell(IItems item)
    {
        Console.WriteLine($"Item Enchantment! \"{item.name}´s\" power has increased by 25%.");
    }
    public static void MagicImprovementSpell(IMagic magician)
    {
        Console.WriteLine($"¡Magic Improvement! {magician.Name} has learnt a new spell. Your chances of successfully casting a Magic Spell has increased");
    }
}    
