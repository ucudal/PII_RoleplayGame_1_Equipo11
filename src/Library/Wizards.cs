//Juan Magrini
using System;
using Characters;
using Inventory;
using System.Collections.Generic;

namespace WizardCharacter;
public class Wizards : ICharacter, IBalance, IMagic, IInventory
{
    ICharacter character;
    private string name;

    public int Strength { get; }
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
    public int Damage { get; set; }
    private int HP { get; set; }
    public int Magic { get; set; }

    public Weapons Weapon { get; set; }

    public Armors Armor { get; set; }
    public List<IItems> Inventory { get; set; }

    public Wizards(string name, Weapons itemWeapon, Armors itemArmor, MagicItems magicItems)
    {
        this.ArmorDefense = itemArmor.Power;
        this.Armor = itemArmor;
        this.Description = "This character has the power of magic";
        this.Damage = 20 + itemWeapon.Power;
        this.Weapon = itemWeapon;
        this.HP = 100;
        this.Coins = 500;
        this.MagicItem = magicItems;
        this.Name = name;
        this.Strength = 1;
        this.WeaponInventory = new List<Weapons>() {this.Weapon };
        this.ArmorInventory = new List<Armors>() { this.Armor};

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
        this.HP += value;
    }
    public bool IsAlive()
    {
        if (this.HP <= 0)
        {
            ConsolePrinter.DeathPrinter(character);
            this.Armor = null;
            this.Weapon = null;
            Transaction(false, this.Coins / 2);// divide su oro a la mitad
            return false;
        }
        else
        {
            ConsolePrinter.AlivePrinter(character);
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
    private List<string> BookOfSpells = new List<string>()
    {
        "Fortune",
        "Healing Potion",
        "Poison Gas",
        "Weapon Enchantment",
        "Armor Enchantment",
        "Magic Improvement",
    };
    public void MagicSpell(ICharacter deffender)
    {
        var rand = new Random();
        int userNumber = 0;
        int gameNumber = rand.Next(101); //crea un numero random entre 0 y 100
        for (int i = 0; i <= 4; i++) // 5 veces se crea un numero al azar del 0 al 100 
        {
            userNumber = rand.Next(101);
            if (userNumber == gameNumber) //se compara si el numero del usuario equivale al de "la casa"
            {
                ConsolePrinter.spellSuccessfullyCast();
                int spellNumber = rand.Next(7); //se crea un numero al azar del 0 al 6
                this.Spells(BookOfSpells[spellNumber]);
            }
        }
    }

    //Poderes del Book Of Spells:

    public void Spells(string spell)
    {
        if (spell == "Fortune") { this.Transaction(true, this.GetCoins() * 2); Console.WriteLine($"¡Fortune! {this.Name}'s coins have been doubled; you now have {this.GetCoins}"); }
        if (spell == "Healing Potion") { this.HPChanger(10); Console.WriteLine($"¡Healing Poiton! {this.Name} gained 10 Health Points."); }
        if (spell == "Poison Gas") { this.HPChanger(-10); Console.WriteLine($"¡Oh no! The spell was Poison gas. {this.Name} lost 10 Health Points."); }
        if (spell == "Weapon Enchantment") { this.Weapon.Power = this.Weapon.Power * (5 / 4); Console.WriteLine($"Weapon Enchantment! {this.Weapon}´s damage has increased by 25%."); } //mejora el daño en un 25%
        if (spell == "Armor Enchantment") { this.ArmorDefense = this.ArmorDefense * (5 / 4); Console.WriteLine($"¡Armor Enchantment! {this.Armor}´s protection has increased by 25%."); }
        if (spell == "Magic Improvement") { this.Magic += 2; Console.WriteLine($"¡Magic Improvement! {this.Name} has learnt a new spell. Your chances of successfully casting a Magic Spell has increased"); } //mejora probabilidades de MagicSpell un 2%
    }
    //-----------WeaponInventory----------
    public List<Weapons> WeaponInventory { get; set; }
    public List<Armors> ArmorInventory { get; set; }
    public void WeaponInventoryAdd(Weapons weapon)
    {
        this.WeaponInventory.Add(Weapon);
    }
    public void WeaponInventoryRemove(Weapons weapon)
    {
        this.WeaponInventory.Remove(weapon);
    }
    public void WeaponEquip(Weapons weapon) //metodo para equipar armas obtenidas no desde la tienda (e.g: peleando)
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
    public void ArmorInventoryAdd(Armors armor)
    {
        this.ArmorInventory.Add(armor);
    }
    public void ArmorInventoryRemove(Armors armor)
    {
        this.ArmorInventory.Remove(armor);
    }
    public void ArmorEquip(Armors armor) //metodo para equipar armas obtenidas no desde la tienda (e.g: peleando)
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

