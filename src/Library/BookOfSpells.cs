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

    //  Monedas Duplicadas
    public static void Fortune(IMagic magician)
    {
        magician.Transaction(true, magician.GetCoins() * 2);
        ConsolePrinter.FortuneSpell(magician);
    }

    //  Pocion curativa que incrementa la vida del personaje en 30 puntos
    public static void HealingPotion(IMagic magician)
    {
        magician.HPChanger(30);
        ConsolePrinter.CurativeSpell(magician);
    }

    //  Hechizo perjudicial al propio personaje, le quita 15 de vida
    public static void PoisonGas(IMagic magician)
    {
        magician.HPChanger(-15);
        ConsolePrinter.PoisonSpell(magician);
    }

    //  Mejora el poder del item (seleccionado por el usuario), en un 50%
    public static void ItemEnchantment(IItems item)
    {
        item.Power = item.Power * (3 / 2);
        ConsolePrinter.ItemEnchantmentSpell(item);
    }

    //  Incrementa los puntos de magia del personaje --> 2% más de chances de obtener un "spell success"
    public static void MagicImprovement(IMagic magician)
    {
        magician.Magic += 2;
        ConsolePrinter.MagicImprovementSpell(magician);
    }
}