using System;
using System.Collections.Generic;

namespace Inventory;
public class Weapons
{
    private string weaponName;
    public string WeaponName
    {

        get
        {
            return this.WeaponName;
        }

        set
        {
            if (!ItemsStore.Weapons.ContainsKey(weaponName)) //comprueba que el nombre de la weapon exista en la "base de datos" (ItemsStore)
            {
                this.WeaponName= weaponName;
            }
        }

    }
    public int WeaponDurability {get, set;}
    public int Damage {get; set;}

    public Weapons(string weaponName, int damage, int weaponDurability)
    {
        this.WeaponName= weaponName
        this.Damage= damage;
        this.WeaponDurability= weaponDurability;
    }

    public void Repair()
    {

    }
    public void Sell()
    {

    }
    public void Buy()
    {

    }
}