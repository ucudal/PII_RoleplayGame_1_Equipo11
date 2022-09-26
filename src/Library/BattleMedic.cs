using System;
using System.Collections.Generic;
using Inventory;
using Characters;

namespace NPC;

public class BattleMedic
{
    public BattleMedic(string name)
    {
        this.Description = "¡Be aware! It is probable you lose some of your organs during the consult; no refunds!!! ";
        this.Name = name;
    }
    public string Description { get; }
    private string name;
    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                this.name = value;
            }
        }
    }
    public void BigPotion(ICharacter character)
    {
        if (character.Transaction(false, 15))
        {
            character.HPChanger(100);
        }
        else { ConsolePrinter.NotEnoughCoins(); }
    }
    public void MediumPotion(ICharacter character)
    {
        if (character.Transaction(false, 7))
        {
            character.HPChanger(45);
        }
        else { ConsolePrinter.NotEnoughCoins(); }
    }
}