using System;
using System.Collections.Generic;
using Inventory;

namespace Characters;

public class Dwarves : ICharacter, IBalance, IInventory
{
    public Dwarves(string name, Weapons weapon, Armors armor)
    {
        this.Description = "Son seres temperamentales que se destacan en el combate, su gran resistencia y lealtad.";
        this.Name = name; //nombre
        //arma
        this.Weapon = weapon;
        //armaduras
        this.Armor = armor;
        //riqueza  
        this.Coins = 30;
        // cada golpe saca 10 de vida 
        this.Strength = 10; 
        this.HP = 120; //tiene una vida maxima de 120, otros personajes pueden tener mas o menos, son los mas robustos

        this.WeaponInventory = new List<Weapons>() {this.Weapon };
        this.ArmorInventory = new List<Armors>() {this.Armor };

    }

    public string Description { get; }
    private string name;
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
    private int HP { get; set; }
    public int GetHP() { return this.HP; }
    public void HPChanger(int value)
    {
        this.HP += value;
    }
    public int Strength { get; }

    public Weapons Weapon { get; set; } //lista de armas
    public Armors Armor { get; set; } //lista de piezas de armadura
    public int Damage { get; set; }
    private int Coins { get; set; }
    public int GetCoins()
    {
        return this.Coins;
    }

    public bool Transaction(bool operation, int value)  //true significa q recibe dinero, y false q se le resta
    {
        if (operation)
        {
            this.Coins += value;
            return true;
        }
        else
        {
            if (value < this.Coins) { this.Coins -= value; return true; }           //determina si la operacion es posible
            else { Console.WriteLine($"{this.name} no tiene oro suficiente!"); return false; }
        }
    }

    public bool IsAlive()
    {
        if (this.HP <= 0)
        {
            Console.WriteLine($"¡\"{this.Name}\" could not survive the attack!");
            this.Armor = null;
            this.Weapon = null;
            Transaction(false, this.Coins / 2);// divide su oro a la mitad
            return false;
        }
        else
        {
            Console.WriteLine($"\"{this.Name}\" is still alive: {this.HP} HP.");
            return true;
        }
    }
    public List<Weapons> WeaponInventory { get; set; }
    public List<Armors> ArmorInventory { get; set; }
    public void InventoryAdd(Weapons weapon)
    {
        this.WeaponInventory.Add(Weapon);
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
