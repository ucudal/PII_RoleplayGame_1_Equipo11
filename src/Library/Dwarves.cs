using System;
using System.Collections.Generic;
using Inventory;

namespace Characters;

public class Dwarves : ICharacter
{
    public Dwarves(string name, Weapons weapon, Armors armor)
    {
        this.Description = "Son seres temperamentales que se destacan en el combate, su gran resistencia y lealtad.";
        this.Name = Name; //nombre
        this.Weapon = weapon; //armas
        this.Armor = armor; //armaduras
        //Recordar que los enanos no tienen capacidades magicas
        this.Coins = 30; //riqueza 
        this.Strength = 10; // cada golpe saca 10 de vida
        this.HP = 120; //tiene una vida maxima de 120, otros personajes pueden tener mas o menos, son los mas robustos*/

        this.Inventory = new List<IItems>() { this.Armor, this.Weapon };

    }
    public List<IItems> Inventory { get; set; }
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
            if (!string.IsNullOrEmpty(value))//que el nombre no este vacio
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
            Console.WriteLine($"\"{item.name}\" removed successfully.");
            this.Inventory.Remove(item);
        }
        else
        {
            Console.WriteLine($"Error: \"{this.Name}\" does not equip \"{item.name}\".");
        }
        //Es necesario agregar un metodo Break, que quite el arma del inventario cuando se rompa
        //Tambien se podria dar un aviso cuando este al borde de romperse
    }
    public void Equip(IItems item) //metodo para equipar armas obtenidas no desde la tienda (e.g: peleando)

    {
        this.Inventory.Add(item);
        Console.WriteLine($"\"{this.Name}\" now equips \"{item.name}\".");
    }
}
