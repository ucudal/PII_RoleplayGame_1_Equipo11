//Felipe Villaronga
using System;
using System.Collections.Generic;
using Characters;

namespace Inventory;
public class Weapons : IItems
{
    public Weapons(string weaponName)
    {
        this.name = weaponName;
        this.Power = power;
        this.Durability = 100; //arranca con 100%, en cada ataque va a ir disminuyendo
    }
    ICharacter character;
    public string name { get; set; }
    private int power;
    public string WeaponName
    {

        get
        {
            return this.name;
        }

        set
        {
            if (ItemsStore.Weapons.ContainsKey(value)) //comprueba que el nombre de la weapon exista en la "base de datos" (ItemsStore)
            {
                this.name = value;
            }
        }

    }
    public int Durability { get; set; }
    public int Power
    {

        get
        {
            if (this.Durability <= 0) { return 0; }
            else { return this.power; }
        }

        set
        {
            if (ItemsStore.Weapons.ContainsKey(this.name)) //comprueba que el nombre de la weapon exista en la "base de datos" (ItemsStore)
            {
                this.power = ItemsStore.Weapons[this.name];
            }
        }

    } 

    public void Break(ICharacter character)
    {
        if (this.Durability <= 0)
        {
            ConsolePrinter.brokenItem(this);
            character.Weapon = null; //se elimina el arma del personaje
        }
        if (this.Durability <= 15) //aviso de cuando este por romperse
        {
            ConsolePrinter.aboutToGetBrokenItem(this); //aviso
        }
    }


}

