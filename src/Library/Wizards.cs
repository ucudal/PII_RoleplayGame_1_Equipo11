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
    private string name;

    public int Strength {get;}
    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (!string.IsNullOrEmpty(value)) //comprueba que no se haya ingresado una string vacia
            {
                this.name = value;
            }
        }
    }

    public MagicItems MagicItem {get; set;} //Lista que contiene los items del character

    public int ArmorDefense {get; set;}
    private int Coins {get; set;}
    public string Description {get;}
    public int Damage {get; set;}
    private int HP {get; set;}

    public Weapons Weapon {get; set;}

    public Armors Armor {get; set;}
    public List<IItems> Inventory;

    public Wizards(string name, Weapons itemWeapon, Armors itemArmor, MagicItems magicItems)
    {
        this.ArmorDefense=itemArmor.ArmorProtection;
        this.Armor=itemArmor;
        this.Description= "This character has the power of magic";
        this.Damage=20+itemWeapon.Damage;
        this.Weapon=itemWeapon;
        this.HP= 100;
        this.Coins=500;
        this.MagicItem= magicItems;
        this.Name=name;
        this.Strength=1;
        this.Inventory= new List<IItems>(){this.Armor,this.Weapon};
    }

    public int GetCoins()
    {
        return this.Coins;
    }
    
    public int GetHP()
    {
        return this.HP;
    }
    public void HPChanger(int value)
    {
        this.HP+=value;
    }

    public void Attack(ICharacter enemy)
    {
            if(Weapon.WeaponDurability>10)
            {
                int enemysHP= enemy.GetHP()+enemy.Armor.ArmorProtection;
                enemysHP-=this.Damage;
                Weapon.WeaponDurability-=10;
                enemy.Armor.ArmorDurability-=5;
            }
            else
            {
                Console.WriteLine("Your weapon is about to get broken, you need to fix it in order to use it.");
            }
    }
    public bool IsAlive()
    {
        if (this.HP <= 0)
        {
            Console.WriteLine($"¡\"{this.Name}\" could not survive the attack!");
            this.Armor = null;
            this.Weapon = null;
            Transaction(false,this.Coins/2);// divide su oro a la mitad
            return false;
        }
        else
        {
            Console.WriteLine($"\"{this.Name}\" is still alive: {this.HP} HP.");
            return true;
        }
    }
    public bool Transaction(bool operation, int value)
    {
        if (operation)
        {
            this.Coins += value; 
            return true;
        }
        else 
        {
            if (value<this.Coins){this.Coins-=value; return true;}           //determina si la operacion es posible
            else{Console.WriteLine($"{this.name} no tiene oro suficiente!"); return false;}
        }  
    }
    public void Magic()
    {
        int chanceSuperAttack= 5; //arranca en 10 xq la magia es innata a ellos
    }
    public void InventoryAdd(IItems item)
    {
        this.Inventory.Add(item);
    }
    public void InventoryRemove(IItems item)
    {
        this.Inventory.Remove(item);
    }
}

