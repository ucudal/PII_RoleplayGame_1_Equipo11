//Felipe Villaronga

using System;
using System.Collections.Generic;
using Inventory;

namespace Characters;

public class Elves : ICharacter, IMagic, IInventory, IBalance
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
        this.ArmorInventory= new List<Armors>(){this.Armor};
        this.WeaponInventory= new List<Weapons>(){this.Weapon};
    }

    //Lista con los objetos de tipo IItems que posee el personaje (pueden ser de tipo Armors/MagicItems/Weapons)
    public List<IItems> Inventory {get;set;}

    //breve descripcion de las caracteristicas de un Elfo
    public string Description { get; }

    //nombre del personaje 
    private string name;

    //propiedad "Health Points" que mide la cantidad de vida en una escala del 1 al 100 (0 es muerte)
    private int HP { get; set; } 

    //metodo para obtener la vida del personaje
    public int GetHP(){return this.HP;}

    //Metodo para modificar la vida del personaje
    public void HPChanger(int value)
    {
        this.HP+=value;
    }

    //fuerza de los golpes
    public int Strength { get; } 

    //daño del arma unido a la fuerza del elfo
    public int Damage {get; set;}

    //arma
    public Weapons Weapon { get; set; } 

    //pieza de armadura
    public Armors Armor { get; set; } 

    //item magico
    public MagicItems MagicItem { get; set; } 

    //Aseguro que no se ingrese una string vacia como nombre de personaje
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
    
    //metodo que retorna un valor booleano segun si un personaje sigue vivo (true) o ha muerto (false). Es llamado luego de cada ataque
    public bool IsAlive()
    {
        if (this.HP <= 0)
        {
            //Si fallece, se le vacia el inventario y se le reducen las coins a la mitad.
            ConsolePrinter.DeathPrinter(this);
            this.Armor = null;
            this.Weapon = null;
            this.MagicItem = null;
            Transaction(false,this.Coins/2);
            return false;
        }
        else
        {
            ConsolePrinter.AlivePrinter(this);
            return true;
        }
    }

    //sistema monetariodel juego
    private int Coins { get;set;}

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
            if (value<this.Coins){this.Coins-=value; return true;}
            ConsolePrinter.NotEnoughCoins(); return false;}
        }  
    
    //Ligada a la descripcion del personaje --> se implementa la habilidad de otorgar beneficios varios a un aliado indicado por parametro
    public void Specialty(ICharacter partner)
    {
        partner.Damage =+ ((5*partner.Damage)/100);
        partner.HPChanger((5*partner.GetHP())/100);
        partner.Weapon.Durability =+ ((5*partner.Weapon.Durability)/100);
        partner.Armor.Durability =+ ((5*partner.Armor.Durability)/100);
        //Incremento de 5% en vida/daño/durabilidad al aliado seleccionado.
    }

    //metodo a traves del cual agregar un item de tipo IItems al Inventario del personaje
   
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