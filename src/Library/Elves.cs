//Felipe Villaronga

using System;
using System.Collections.Generic;

namespace Characters;

public class Elves : ICharacter
{
    public string Description { get; }
    private string name;
    public int HP { get; set; }
    public int Strength { get; } //medido en hp del 1 al 100
    public Dictionary<string, List<string>> Inventory { get; set; }
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

    public Elves(string name, Dictionary<string, List<string>> inventory, int coins)
    {
        this.Description = "Son criaturas supernaturales que tambien poseen características mágicas, se destacan por su compañerismo";
        this.Name = Name; //nombre
        this.Inventory = inventory; //armas+armaduras+objetos
        this.Coins = coins; //riqueza 
        this.Strength = 8; // cada golpe saca 8 de vida
        this.HP = 80;
    }

    public int weaponDamage = 0;

    public int Attack() //Este seria el modelo de ataque de un elfo, se llama al metodo mediante la interfaz aun no creada "IAttack"
    {
        foreach (string element in this.Inventory["Weapons"])
        {
            int weaponDamage = +ItemsStore.Weapons[element] * 1 / 2;
        }
        //Se multiplica el golpe por la mitad de daño del arma, es a modo de ejemplo y abierto a modificaciones
        int elfDamage = this.Strength + weaponDamage;
        return elfDamage;
    }

    public void Equip(ICharacter character, string newObject)

    {
        if (this.Inventory["Weapons"].Count + this.Inventory["Armors"].Count + this.Inventory["Items"].Count <= 5)
        {
            inventory.Add(newObject);
        }
        else
        {
            Console.WriteLine("You are only allowed to carry a maximum of 5 items.");
        }
    }
    public void Remove(string eliminatedObject)
    {
        inventory.Remove(eliminatedObject);
        Console.WriteLine($"Item removed successfully. You now carry {inventory.Count} items.");
    }

}