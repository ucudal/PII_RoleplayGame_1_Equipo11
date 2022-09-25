/*using System;
using Characters;
using Inventory;
using System.Collections.Generic;
using System.Collections;

namespace WizardCharacter;
public class Wizards : ICharacter
{
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
    public List <Weapons> Weapons {get; set;}

    public List<Armors> Armors {get; set;}
    public int Coins {get; set;}
    public string Description {get;}
    public int Damage {get; set;}
    public int HP {get; set;}

    public int Armor {get; set;}

    public Wizards(string name, List<Armors> Armors, List<Weapons> Weapons)
    {
        Weapons.Add(new Weapons("Melee",this.Damage,100));
        this.Weapons= Weapons;
        if(Armors==null)
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
        this.Damage = 20;
        this.HP= 100;
        this.Coins=500;
    }
    

    public void Attack(Weapons weapon, ICharacter enemy)
    {
        int enemysHP= enemy.HP+enemy.Armor;
        if(this.Weapons.Contains(weapon))
        {
            this.Damage+=weapon.Damage;
            enemysHP-=this.Damage;
            if(weapon.WeaponName!="Melee")
            {
                weapon.WeaponDurability-=10;
            }
        }

    }

    public void Equip(IItems itemToBeAdded)
    {
        if(Weapons.Count+Armors.Count==5)
        {
            Console.WriteLine("Your invetory is full, you need to remove at least one item in order to carry another one.");
        }
        else
        {
            //Aca se me armo quilombo 
        }
    }

    public void Remove(string itemToBeDropped)
    {
        foreach(var itemWeapon in Weapons)
        {
            foreach(var itemArmor in Armors)
            {
                if(itemWeapon.WeaponName==itemToBeDropped)
                {
                    Weapons.Remove(itemWeapon);
                    Console.WriteLine("Item succesfully dropped");
                }
                else
                {
                    Armors.Remove(itemArmor);
                    Console.WriteLine("Item succesfully dropped");
                }
            }
        }
    }
}*/
