//Juan Magrini
using System;
using Characters;
using Inventory;
using System.Collections.Generic;
using System.Collections;

namespace WizardCharacter;
public class Wizards : ICharacter
{
    ICharacter character;
    public string Name {get; set;}

    public MagicItems MagicItem {get; set;} //Lista que contiene los items del character

    public int ArmorDefense {get; set;}
    public int Coins {get; set;}
    public string Description {get;}
    public int Damage {get; set;}
    public int HP {get; set;}

    public Weapons Weapon {get; set;}

    public Armors Armor {get; set;}

    public Wizards(string name, Weapons itemWeapon, Armors itemArmor, MagicItems magicItems)
    {
        if(itemArmor!=null)
        {
            this.ArmorDefense=itemArmor.ArmorProtection;
            this.Armor=itemArmor;
        }
        else
        {
            this.ArmorDefense=0;
        }
        this.Description= "This character has the power of magic";
        if(itemWeapon!=null)
        {
            this.Damage=20+itemWeapon.Damage;
            this.Weapon=itemWeapon;
        }
        else
        {
            this.Weapon= new Weapons("Wizard Melee");
            this.Damage=Weapon.Damage;
            Console.WriteLine("The weapon you entered does not exist");
        }
        this.HP= 100;
        this.Coins=500;
        this.MagicItem= magicItems;
        this.Name=name;
    }
    

    public void Attack(ICharacter enemy)
    {
        if(Weapon.WeaponName!="Wizard Melee")
        {
            if(Weapon.WeaponDurability>10)
            {
                int enemysHP= enemy.HP+enemy.Armor.ArmorProtection;
                enemysHP-=this.Damage;
                Weapon.WeaponDurability-=10;
            }
            else
            {
                Console.WriteLine("Your weapon is about to get broken, you need to fix it in order to use it.");
            }
        }
    }


    public bool IsAlive()
    {
        if(this.HP<=0)
        {
            Console.WriteLine($"¡\"{this.Name}\" could not survive the attack!");
            return false;
        }
        else
        {
            Console.WriteLine($"\"{this.Name}\" is still alive: {this.HP} HP.");
            return true;
        }
    }
}
