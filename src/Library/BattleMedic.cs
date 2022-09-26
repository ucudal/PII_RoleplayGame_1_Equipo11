using System;
using System.Collections.Generic;
using Inventory;
using Characters;

namespace NPC;

public class BattleMedic
{
    public BattleMedic(string name)
    {
        this.Description= "atencion cliente, verifique tener todos sus organos antes de salir del consultorio!, no reembolsos!!! ";
        this.Name = Name; //nombre
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
            if (!string.IsNullOrEmpty(value))//que el nombre no este vacio
            {
                this.name = value;
            }
        }
    }
    public void BigPotion(ICharacter character)
    {
        if (character.Transaction(false,15))
        {
            character.HPChanger(100);
        }
        else{Console.WriteLine("No enough money sir, Can i take ur kidney instead?");}   
    }
    public void MediumPotion(ICharacter character)
    {
        if (character.Transaction(false,7))
        {
            character.HPChanger(45);
        }
        else{Console.WriteLine("No enough money sir, Can i take ur kidney instead?");}        
    }
}