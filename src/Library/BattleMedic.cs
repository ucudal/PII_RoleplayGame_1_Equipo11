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
        character.HPChanger(100);
        character.Transaction(false,15);
    }
    public void MediumPotion(ICharacter character)
    {
        character.HPChanger(45);
        character.Transaction(false,7);
    }
}