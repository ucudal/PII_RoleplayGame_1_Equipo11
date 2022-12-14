//Felipe Villaronga

using System;
using System.Collections.Generic;
using Inventory;

namespace Characters;

public class Elves : ICharacter, IInventory, IBalance
{
    public Elves(string name, Weapons weapon, Armors armor)
    {
        this.Description = "Son criaturas supernaturales que tambien poseen características mágicas, se destacan por su compañerismo";
        this.Name = name;
        //  arma principal
        this.Weapon = weapon;
        //  pieza de armadura principal
        this.Armor = armor;
        //  dinero 
        this.Coins = 1000;
        //  fuerza predeterminada de los elves
        this.Strength = 5;
        //tiene una vida maxima de 80, otros personajes pueden tener mas o menos
        this.HP = 80;
        //  lista que contiene piezas de armadura 
        this.ArmorInventory = new List<Armors>() { this.Armor };
        //  lista que contiene armas 
        this.WeaponInventory = new List<Weapons>() { this.Weapon };
    }

    //Lista con los objetos de tipo IItems que posee el personaje (pueden ser de tipo Armors/MagicItems/Weapons)
    public List<IItems> Inventory { get; set; }

    //breve descripcion de las caracteristicas de un Elfo
    public string Description { get; }

    private string name;

    //propiedad "Health Points" que mide la cantidad de vida en una escala del 1 al 100 (0 es muerte)
    private int HP { get; set; }

    //metodo para obtener la vida del personaje
    public int GetHP() { return this.HP; }

    //Metodo para modificar la vida del personaje
    public void HPChanger(int value)
    {
        this.HP += value;
    }

    //fuerza de los golpes
    public int Strength { get; set; }

    //daño del arma unido a la fuerza del elfo
    public int Damage { get; set; }

    //arma
    public Weapons Weapon { get; set; }

    //pieza de armadura
    public Armors Armor { get; set; }

    //Aseguro que no se ingrese una string vacia como nombre de personaje
    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {   //comprueba que no se haya ingresado una string vacia
            if (!string.IsNullOrEmpty(value))
            {
                this.name = value;
            }
        }
    }

    //metodo que retorna un valor booleano segun si un personaje sigue vivo (true) o ha muerto (false). Es llamado luego de cada ataque
    public bool IsAlive()
    {
        if (this.HP <= 0)
        {
            //Si fallece, se le vacia el inventario y se le reducen las coins a la mitad.
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

    //sistema monetariodel juego
    private int Coins { get; set; }

    //metodo que retorna la cantidad de monedas que posee el personaje
    public int GetCoins()
    {
        return this.Coins;
    }

    ///bool operation: true --> las coins aumentan (Ventas/Looteos),   false --> las coins disminuyen (Compras/Reparaciones)
    /// int value: entero que indican en que medida las coins aumentaran/disminuiran
    public bool Transaction(bool operation, int value)
    {
        if (operation)
        {
            this.Coins += value;
            return true;
        }
        else
        {
            //se valida que el personaje posea el dinero suficiente para realizar la compra/reparación
            if (value < this.Coins) { this.Coins -= value; return true; }
            ConsolePrinter.NotEnoughCoins(); return false;
        }
    }

    //Ligada a la descripcion del personaje --> se implementa la habilidad de otorgar beneficios varios a un aliado indicado por parametro
    public void Specialty(ICharacter ally)
    {
        ally.Strength = +((5 * ally.Strength) / 100);
        ally.HPChanger((5 * ally.GetHP()) / 100);
        ally.Weapon.Durability = +((5 * ally.Weapon.Durability) / 100);
        ally.Armor.Durability = +((5 * ally.Armor.Durability) / 100);
        //Incremento de 5% en vida/daño/durabilidad al aliado seleccionado.
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
    //metodo para equipar armas como principales a la hora de luchar
    public void Equip(Weapons weapon)
    {
        if (this.WeaponInventory.Contains(weapon))
        {
            this.Weapon = weapon;
        }
    }

    //  "Desactiva" el arma
    public void WeaponUnequip()
    {
        this.Weapon = null;
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

    //  metodo para equipar una pieza de armadura del inventario como armadura principal
    public void Equip(Armors armor)
    {
        if (this.ArmorInventory.Contains(armor))
        {
            this.Armor = armor;
        }
    }
    public void ArmorUnequip()
    {
        this.Armor = null;
    }
}