//Juan Magrini
using System;
using Inventory;
using System.Collections.Generic;

namespace Characters;
public class Wizards : ICharacter, IBalance, IMagic, IInventory
{
    ICharacter character;
    IMagic magician;
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
        this.Inventory = new List<IItems>() { this.Armor, this.Weapon };
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
            //ConsolePrinter.DeathPrinter(character);
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
    public void Unequip(IItems item)
    {
        if (this.Inventory.Contains(item))
        {
            this.Inventory.Remove(item);
            ConsolePrinter.unequippedItem(this, item);
        }
        else
        {
            ConsolePrinter.NotInInventory(item);
        }
    }

    public void MagicSpell(IItems item)
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

    
    public void InventoryAdd(IItems item)
    {
        this.Inventory.Add(item);
    }
    public void InventoryRemove(IItems item)
    {
        this.Inventory.Remove(item);
    }
    public void Desequip(IItems item)
    {
        if (this.Inventory.Contains(item))
        {
            ConsolePrinter.unequippedItem(character, item);
            this.Inventory.Remove(item);
        }
        else
        {
            ConsolePrinter.NotInInventory(item);
        }
        //Es necesario agregar un metodo Break, que quite el arma del inventario cuando se rompa
        //Tambien se podria dar un aviso cuando este al borde de romperse
    }
    public void Equip(IItems item) //metodo para equipar armas obtenidas no desde la tienda (e.g: peleando)

    {
        this.Inventory.Add(item);
        ConsolePrinter.equippedItem(character, item);
    }
}

