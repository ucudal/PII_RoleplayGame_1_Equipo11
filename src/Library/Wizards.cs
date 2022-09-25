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
    public string Name
    {
        get
        {
            return this.Name;
        }
        set
        {
            if(!string.IsNullOrEmpty(value))
            {
                this.Name=value;
            }
        }
    }
    public List<MagicItems> MagicItems {get; set;} //Lista que contiene los items del character

    public List <Weapons> Weapons {get; set;}

    public List<Armors> Armors {get; set;}
    public int Coins {get; set;}
    public string Description {get;}
    public int Damage {get; set;}
    public int HP {get; set;}

    public int Armor {get; set;}

    public Wizards(string name, Armors itemArmor, Weapons itemWeapon, MagicItems magicItems)
    {
        Weapons.Add(new Weapons("Melee",this.Damage));
        this.Weapons.Add(itemWeapon);
        if(itemArmor==null)
        {
            this.Armor= 0;
        }
        else
        {
            foreach(var Defense in Armors)
            {
                this.Armor+=Defense.ArmorProtection;
            }
        }
        
        this.Description= "This character has the power of magic";
        this.Damage = 20+itemWeapon.Damage;
        this.HP= 100;
        this.Coins=500;
        this.MagicItems.Add(magicItems);
    }
    

    public void Attack(Weapons itemWeapon, ICharacter enemy)
    {
        int enemysHP= enemy.HP+enemy.Armor;
        if(this.Weapons.Contains(itemWeapon))
        {
            if(itemWeapon.WeaponDurability<10)
            {
                Console.WriteLine("This weapon is about to get broken, you are not able to use it");
            }
            else
            {
                enemysHP-=this.Damage;
                if(itemWeapon.WeaponName!="Melee")
                {
                    itemWeapon.WeaponDurability-=10;
                }
            }
        }
        else
        {
            Console.WriteLine("You do not have this weapon in your posession");
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
