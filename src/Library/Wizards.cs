//Juan Magrini
using System;
using Inventory;
using System.Collections.Generic;

namespace Characters;
public class Wizards : ICharacter, IBalance, IMagic, IInventory
{
    public Wizards(string name, Weapons itemWeapon, Armors itemArmor, MagicItems magicItems)
    {
        this.ArmorDefense = itemArmor.Power;
        this.Armor = itemArmor;
        this.Description = "This character has the power of magic";
        this.Weapon = itemWeapon;
        this.HP = 100;
        this.Coins = 100;
        this.MagicItem = magicItems;
        this.Name = name;
        this.Strength = 1;
        this.WeaponInventory = new List<Weapons>() {this.Weapon };
        this.ArmorInventory = new List<Armors>() { this.Armor};
        //porcentaje de probabilidad de realizar con exito el Specialty
        this.Magic= 8;
    }
    ICharacter character;
    IMagic magician;
    private string name;
    public int Strength { get; set;}
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

    public MagicItems MagicItem { get; set; } //Lista que contiene los items del character

    public int ArmorDefense { get; set; }
    private int Coins { get; set; }
    public string Description { get; }
    private int HP { get; set; }
    public int Magic { get; set; }

    public Weapons Weapon { get; set; }

    public Armors Armor { get; set; }
    public List<IItems> Inventory { get; set; }

    
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
        this.HP += value;
    }
    public bool IsAlive()
    {
        if (this.HP <= 0)
        {
            this.Armor = null;
            this.Weapon = null;
            Transaction(false, this.Coins / 2);
            return false;
        }
        else
        {
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
            if (value < this.Coins) //determina si la operacion es posible
            {
                this.Coins -= value; return true;
            }
            else
            {
                ConsolePrinter.NotEnoughCoins();
                return false;
            }
        }
    }

    public void Specialty(IItems item)
    {
        var rand = new Random();
        int userNumber = 0;
        //crea un numero random entre 0 y 100
        int gameNumber = rand.Next(101);
        // 5 veces se crea un numero al azar del 0 al 100  
        for (int i = 0; i <= 4; i++) 
        {
            //se compara si el numero del usuario equivale al de "la casa"
            userNumber = rand.Next(101);
            if (userNumber == gameNumber) 
            {
                ConsolePrinter.spellSuccessfullyCast();
                //se crea un numero al azar del 0 al 5
                int spellNumber = rand.Next(6); 
                string spell = BookOfSpells.bookOfSpells[spellNumber];
                if (spell == "Fortune")
                {
                    BookOfSpells.Fortune(this);
                }
                if (spell == "Healing Potion")
                {
                    BookOfSpells.HealingPotion(this);
                }
                if (spell == "Poison Gas")
                {
                    BookOfSpells.PoisonGas(this);
                }
                if (spell == "Item Enchantment")
                {
                    BookOfSpells.ItemEnchantment(item);
                }

                if (spell == "Magic Improvement")
                {
                    BookOfSpells.MagicImprovement(this);
                }
            }
        }
    }


    //-----------WeaponInventory----------
    public List<Weapons> WeaponInventory { get; set; }
    public List<Armors> ArmorInventory { get; set; }
    public void InventoryAdd(Weapons weapon)
    {
        this.WeaponInventory.Add(weapon);
    }
    public void InventoryRemove(Weapons weapon)
    {
        this.WeaponInventory.Remove(weapon);
    }
    public void Equip(Weapons weapon) //metodo para equipar armas obtenidas no desde la tienda (e.g: peleando)
    {
        if (this.WeaponInventory.Contains(weapon))
        {
            this.Weapon=weapon;
        }
    }
    public void WeaponUnequip()
    {
        this.Weapon=null;
    }
    //------------------------ArmorEquipment----------
    public void InventoryAdd(Armors armor)
    {
        this.ArmorInventory.Add(armor);
    }
    public void InventoryRemove(Armors armor)
    {
        this.ArmorInventory.Remove(armor);
    }
    public void Equip(Armors armor) //metodo para equipar armas obtenidas no desde la tienda (e.g: peleando)
    {
        if (this.ArmorInventory.Contains(armor))
        {
            this.Armor=armor;
        }
    }
    public void ArmorUnequip()
    {
        this.Armor=null;
    }
}

