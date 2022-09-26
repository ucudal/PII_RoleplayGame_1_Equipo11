using System.Collections.Generic;
using Characters;

namespace Inventory;

public class BookOfSpells
{
    public static List<string> bookOfSpells = new List<string>()
    {
        "Fortune",
        "Healing Potion",
        "Poison Gas",
        "Item Enchantment",
        "Magic Improvement",
    };

    public static void Fortune(ICharacter magician)
    {
        magician.Transaction(true, magician.GetCoins() * 2); 
        ConsolePrinter.FortuneSpell(magician);
    }
    public static void HealingPotion(ICharacter magician)
    {
        magician.HPChanger(10);  
        ConsolePrinter.CurativeSpell(magician);  
    }
    public static void PoisonGas(ICharacter magician)
    {
        magician.HPChanger(-10); 
        ConsolePrinter.PoisonSpell(magician);
    }
    
    public static void ItemEnchantment(IItems item)
    {

        item.Power = item.Power * (5 / 4);
        ConsolePrinter.ItemEnchantmentSpell(item);
    }
    public static void MagicImprovement(IMagic magician)
    {
        magician.Magic += 2;
        ConsolePrinter.MagicImprovementSpell(magician);
    }
}