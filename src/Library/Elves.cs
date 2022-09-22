//Felipe Villaronga

using System;
using System.Collections.Generic;
using Inventory;

namespace Characters;

public class Elves : ICharacter
{
    public string Description { get; }
    private string name;
    public int HP { get; set; }
    public int Strength { get; } //medido en hp del 1 al 100
    public List<Weapons> Weapons { get; set; }
    public List<Armors> Armors { get; set; }
    public List<MagicItems> MagicItems { get; set; }
    public int Coins { get; set; }
    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                this.name = value;
            }
        }
    }

    public Elves(string name, List<Weapons> weapons, List<Armors> armors, List<MagicItems> magicItems, int coins)
    {
        this.Description = "Son criaturas supernaturales que tambien poseen características mágicas, se destacan por su compañerismo";
        this.Name = Name; //nombre
        this.Weapons = weapons; //armas
        this.Armors = armors; //armaduras
        this.MagicItems = magicItems; //objetos magicos
        this.Coins = coins; //riqueza 
        this.Strength = 8; // cada golpe saca 8 de vida
        this.HP = 80; //tiene una vida maxima de 80, otros personajes pueden tener mas o menos
    }



    public void Attack(Weapons weapon, ICharacter deffender) //Este seria el modelo de ataque de un elfo, se llama al metodo mediante la interfaz aun no creada "IAttack"
    {
        if (this.Weapons.Contains(weapon))
        {
            int weaponDamage = ItemsStore.Weapons[weapon.WeaponName] * 1 / 2; //Se multiplica el golpe por la mitad de daño del arma, es simplemente por jugabilidad, abierto a modificaciones
            int finalDamage = this.Strength + weaponDamage;
            if (deffender.Armor==null)
            {
                deffender.HP = deffender.HP - finalDamage;
            }
            else
            {
                foreach (Armors garment in deffender.Armors)
                int deffender.Armors.= finalDamage
                finalDamage= finalDamage - 
            }
            
            
        }


    }

    public void Equip(IItems newObject)

    {
        if (this.Inventory["Weapons"].Count + this.Inventory["Armors"].Count + this.Inventory["Items"].Count <= 5)
        {

            this.Inventory.Add(newObject);
        }
        else
        {
            Console.WriteLine("You are only allowed to carry a maximum of 5 items.");
        }
    }
    public void Remove(IItems eliminatedObject)
    {
        this.Inventory.Remove(eliminatedObject);
        Console.WriteLine($"Item removed successfully. You now carry {this.Inventory.Count} items.");
    }




}