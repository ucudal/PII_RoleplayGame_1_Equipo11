//Felipe Villaronga

using System;
using System.Collections.Generic;
using Characters;

namespace Inventory;
public class Weapons : IItems
{
    public Weapons(string name)
    {
        this.Name = name;
        this.Power = ItemsStore.Weapons[name];
        this.Durability = 100;
    }
    ICharacter character;
    private int power;
    private string name;

    //nombre del arma --> se asegura que exista un arma con dicho nombre en el ItemsStore 
    public string Name
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

    //propiedad que mide la durabilidad de un arma en enteros del 1 al 100
    public int Durability { get; set; }

    /// propiedad relativa al daño que ejerce un arma, de acuerdo al entero asociado a la clave "name" en el ItemsStore
    /// tiene un set ya que puede incrementar mediante encantamientos y otras acciones
    public int Power
    {

        get
        {
            if (this.Durability <= 0) { return 0; }
            else { return this.power; }
        }

        set
        {
            if (name != null)
            {
                if (ItemsStore.Weapons.ContainsKey(name)) //comprueba que el nombre de la weapon exista en la "base de datos" (ItemsStore)
                {
                    this.power = value;
                }
            }

        }

    }

    //metodo mediante el cual se elimina el arma del inventario de un personaje si su durabilidad es igual o menor a 0
    public void Break(ICharacter character)
    {
        //se elimina el arma del personaje
        if (this.Durability <= 0)
        {
            ConsolePrinter.brokenItem(this);
            character.Weapon = null;
        }
        //aviso de cuando este por romperse
        if (this.Durability <= 15)
        {
            ConsolePrinter.aboutToGetBrokenItem(this);
        }
    }
    public void PowerChange(int value)
    {
        this.Power += value;
    }


}

