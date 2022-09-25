using System;
using System.Collections.Generic;
using Inventory;

namespace Characters;

public class Dwarves : ICharacter
{         
    public Dwarves(string name, Weapons weapon, Armors armor)
    {
        this.Description= "Son seres temperamentales que se destacan en el combate, su gran resistencia y lealtad.";
        this.Name = Name; //nombre
        this.Weapon = weapon; //armas
        this.Armor = armor; //armaduras
        //Recordar que los enanos no tienen capacidades magicas
        this.Coins = 30; //riqueza 
        this.Strength = 10 ; // cada golpe saca 10 de vida
        this.HP = 120; //tiene una vida maxima de 120, otros personajes pueden tener mas o menos, son los mas robustos*/
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
            if (!string.IsNullOrEmpty(value))//que el nombre no este vacio
            {
                this.name = value;
            }
        }
    }
    public int HP { get; set; }
    public int Strength { get; } 

    public Weapons Weapon { get; set; } //lista de armas
    public Armors Armor { get; set; } //lista de piezas de armadura
    public int Damage { get; set; }
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
//igual que el del elfo
    public void Attack(ICharacter deffender) //Este seria el modelo de ataque de un pj, se llama al metodo mediante la interfaz aun no creada "IAttack"
    {
        int finalDamage = this.Strength;
        int protection = 0;
        if (this.Weapon != null)
        {
            int weaponDamage = ItemsStore.Weapons[this.Weapon.WeaponName] * 1 / 2; //Se multiplica el golpe por la mitad de daño del arma, es simplemente por jugabilidad, abierto a modificaciones
            this.Weapon.WeaponDurability -= 5; //la "vida" del arma disminuye un 5% con cada golpe
            finalDamage += weaponDamage; //sumo el daño del arma mas el daño predeterminado del personaje
        }
        if (deffender.Armor != null) //aseguro que el personaje tenga una armadura equipada
        {
            protection = (finalDamage * ItemsStore.Armors[this.Armor.ArmorName]) / 100; //regla de tres donde calculo, en base al puntaje de armorProtection cuanta vida salva
            this.Armor.ArmorDurability -= 5; //la "vida" de cada pieza disminuye en un 5% por cada golpe
        }

        finalDamage -= protection; //el daño final termina siendo el daño total del pj - la proteccion de la armadura de quien se defiende
        deffender.HP = deffender.HP - finalDamage; //le resto a la vida de quien se defiende, tantos puntos valga el daño final

    }
}
