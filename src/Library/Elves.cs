//Felipe Villaronga

using System;
using System.Collections.Generic;
using Inventory;

namespace Characters;

public class Elves : ICharacter
{
    public string Description { get; } //breve descripcion de las caracteristicas de un Elfo
    private string name;
    public int HP { get; set; } //medido en porcentaje del 1 al 100
    public int Strength { get; } //medido en porcentaje del 1 al 100
    public List<Weapons> Weapons { get; set; } //lista de armas
    public List<Armors> Armors { get; set; } //lista de piezas de armadura
    public List<MagicItems> MagicItems { get; set; } //lista de items magicos

    public int Damage {get; set;}
    public int Armor {get; set;}
    public int Coins { get; set; } //dinero del personaje
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

    public Elves(string name, Weapons initialWeapon, Armors initialArmor, MagicItems initialMagicItem)
    {
        this.Description = "Son criaturas supernaturales que tambien poseen características mágicas, se destacan por su compañerismo";
        this.Name = Name; //nombre
        this.Weapons.Add(initialWeapon); //armas
        this.Armors.Add(initialArmor); //armaduras
        this.MagicItems.Add(initialMagicItem); //objetos magicos
        this.Coins = 20; //riqueza 
        this.Strength = 8; // cada golpe saca 8 de vida
        this.HP = 80; //tiene una vida maxima de 80, otros personajes pueden tener mas o menos
        if(initialArmor==null)
        {
            this.Armor= 0;
        }
        else
        {
            foreach(var Defense in Armors)
            {
                this.Armor+=Defense.ArmorProtection;
            }
        }
    }



    public void Attack(Weapons weapon, ICharacter deffender) //Este seria el modelo de ataque de un elfo, se llama al metodo mediante la interfaz aun no creada "IAttack"
    {
        if (this.Weapons.Contains(weapon)) //compruebo que el elfo disponga de dicha arma
        {
            int weaponDamage = ItemsStore.Weapons[weapon.WeaponName] * 1 / 2; //Se multiplica el golpe por la mitad de daño del arma, es simplemente por jugabilidad, abierto a modificaciones
            weapon.WeaponDurability-= 5; //la "vida" del arma disminuye un 5% con cada golpe
            int finalDamage = this.Strength + weaponDamage; //sumo el daño del arma mas el daño predeterminado del personaje
            if (deffender.Armors == null) //aseguro que el personaje tenga una armadura equipada
            {
                deffender.HP = deffender.HP - finalDamage;
            }
            else
            {
                int protection = 0;
                foreach (Armors garment in deffender.Armors) //recorro cada pieza de armadura que contenga la lista
                {
                    protection += (finalDamage * garment.ArmorProtection) / 100; //regla de tres donde calculo, en base al puntaje de armorProtection cuanta vida salva
                    garment.ArmorDurability -= 5; //la "vida" de cada pieza disminuye en un 5% por cada golpe
                }
                finalDamage -= protection; //el daño final termina siendo el daño total del elfo - la proteccion de la armadura de quien se defiende
                deffender.HP = deffender.HP - finalDamage; //le resto a la vida de quien se defiende, tantos puntos valga el daño final
            }
        }
    }
    public bool IsAlive()
    {
        if(this.HP<=0)
        {
            Console.WriteLine($"¡\"{this.Name}\" could not survive the attack!");
            return false;
        }
        else
        {
            Console.WriteLine($"\"{this.Name}\" is still alive: {this.HP} HP.");
            return true;
        }
    }
}