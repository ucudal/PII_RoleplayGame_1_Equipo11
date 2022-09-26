//Felipe Villaronga

using System;
using System.Collections.Generic;
using Inventory;

namespace Characters;

public class Elves : ICharacter
{
    public Elves(string name, Weapons weapon, Armors armor, MagicItems magicItem)
    {
        this.Description = "Son criaturas supernaturales que tambien poseen características mágicas, se destacan por su compañerismo";
        this.Name = name; //nombre
        this.Weapon = weapon; //armas
        this.Armor = armor; //armaduras
        this.MagicItem = magicItem; //objetos magicos
        this.Coins = 20; //riqueza 
        this.Strength = 5; 
        this.HP = 80; //tiene una vida maxima de 80, otros personajes pueden tener mas o menos
        this.Inventory= new List<IItems>(){this.Armor,this.Weapon};
    }
    public List<IItems> Inventory {get;set;}
    public string Description { get; } //breve descripcion de las caracteristicas de un Elfo
    private string name;
    private int HP { get; set; } //medido en porcentaje del 1 al 100
    public int GetHP(){return this.HP;}
    public void HPChanger(int value)
    {
        this.HP+=value;
    }
    public int Strength { get; } //medido en porcentaje del 1 al 100
    public int Damage {get; set;}

    public Weapons Weapon { get; set; } //lista de armas
    public Armors Armor { get; set; } //lista de piezas de armadura
    public MagicItems MagicItem { get; set; } //lista de items magicos

    
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
    
    public bool IsAlive()
    {
        if (this.HP <= 0)
        {
            Console.WriteLine($"¡\"{this.Name}\" could not survive the attack!");
            this.Armor = null;
            this.Weapon = null;
            this.MagicItem = null;
            Transaction(false,this.Coins/2);// divide su oro a la mitad
            return false;
        }
        else
        {
            Console.WriteLine($"\"{this.Name}\" is still alive: {this.HP} HP.");
            return true;
        }
    }
    private int Coins { get;set;}
    public int GetCoins()
    {
        return this.Coins;
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
    public void Specialty(ICharacter partner)
    {
        partner.Damage =+ ((5*partner.Damage)/100);
        partner.HPChanger((5*partner.GetHP())/100);
        partner.Weapon.Durability =+ ((5*partner.Weapon.Durability)/100);
        partner.Armor.Durability =+ ((5*partner.Armor.Durability)/100);
        //Incremento de 5% en vida/daño/durabilidad al aliado seleccionado.
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