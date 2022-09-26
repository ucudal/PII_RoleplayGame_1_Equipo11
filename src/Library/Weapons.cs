//Felipe Villaronga
using System;
using System.Collections.Generic;
using Characters;

namespace Inventory;
public class Weapons : IItems
{
    public Weapons(string weaponName)
    {
        this.WeaponName = weaponName;
        this.Damage = damage;
        this.WeaponDurability = 100; //arranca con 100%, en cada ataque va a ir disminuyendo
    }
    ICharacter character;
    private string weaponName;
    private int damage;
    public string WeaponName
    {

        get
        {
            return this.weaponName;
        }

        set
        {
            if (ItemsStore.Weapons.ContainsKey(value)) //comprueba que el nombre de la weapon exista en la "base de datos" (ItemsStore)
            {
                this.weaponName = value;
            }
        }

    }
    public int WeaponDurability { get; set; }
    public int Damage
    {

        get
        {
            return this.damage;
        }

        set
        {
            if (ItemsStore.Weapons.ContainsKey(this.WeaponName)) //comprueba que el nombre de la weapon exista en la "base de datos" (ItemsStore)
            {
                this.damage = ItemsStore.Weapons[weaponName];
            }
        }

    }

    public void Repair(ICharacter character)
    {

        if (character.Weapon == this)
        {
            int repairCost = ((100 - this.WeaponDurability) * 2) / 10; //simple regla de tres que establece que cada 10% que se arregla, 
                                                                       //se cobran 2 coins; y calcula cuanto cuesta arreglar la weapon hasta llegar a 100%
            if (character.Transaction(false, repairCost)) //tiene suficientes coins
            {
                this.WeaponDurability = 100;
                Console.WriteLine($"{this.WeaponName} has been fully repaired.");
                Console.WriteLine($"\"{character.Name}\" now has an amount of {character.GetCoins()} coins.");
            }
            else
            {
                
                int repairedDurability= (character.GetCoins() * 10) / 2; //regla de tres que establece cuanto porcentaje arreglar de acuerdo a las coins que tiene
                repairCost= (repairedDurability * 2) / 10; //calculo cuanto costo el arreglo realizado
                this.WeaponDurability = + repairedDurability; 
                character.Transaction(false, repairCost);
                Console.WriteLine($"{this.WeaponName} has been repaired up to {this.WeaponDurability}");
                Console.WriteLine($"\"{character.Name}\" now has an amount of {character.GetCoins()} coins.");
            }
        }
        else
        {
            Console.WriteLine($"Error: \"{character.Name}\" does not equip \"{this.WeaponName}\".");
        }

    }
    /*public void Sell(ICharacter character)
    {
        if (character.Weapon == this)
        {
            if (this.WeaponDurability == 100)
            {
                character.Transaction(true, ItemsStore.Prices[this.WeaponName]);
            }
            else
            {
                //sin importar que este en 1 o 99 que la venda a la mitad de precio de la tienda
                //sino se puede hacer regla de tres de acuerdo a que tan roto esta
                character.Transaction(true, (ItemsStore.Prices[this.WeaponName] / 2) );
                Console.WriteLine($"\"{this.WeaponName}\" has been sold, and removed succesfully.");
                Console.WriteLine($"\"{character.Name}\" now has an amount of {character.GetCoins()} coins.");

            }
            character.Weapon = null;
        }
        else
        {
            Console.WriteLine($"Error: \"{character.Name}\" does not equip \"{this.WeaponName}\".");
        }

    }
    public void Buy(ICharacter character)
    {
        if (ItemsStore.Weapons.ContainsKey(this.WeaponName))
        {
            character.Transaction(false, ItemsStore.Prices[this.WeaponName]);
            character.Weapon = this;
        }
        else
        {
            Console.WriteLine($"Error: the store does not include the weapon \"{this.WeaponName}\".");
        }
    }*/

    public void Equip(ICharacter character) //metodo para equipar armas obtenidas no desde la tienda (e.g: peleando)

    {

        character.Weapon = this;
        Console.WriteLine($"\"{character.Name}\" now equips \"{this.WeaponName}\".");
    }

    public void Desequip(ICharacter character)
    {
        if (character.Weapon == this)
        {
            Console.WriteLine($"{character.Weapon.WeaponName} removed successfully.");
            character.Weapon = null;
        }
        else
        {
            Console.WriteLine($"Error: \"{character.Name}\" does not equip \"{this.WeaponName}\".");
        }
        //Es necesario agregar un metodo Break, que quite el arma del inventario cuando se rompa
        //Tambien se podria dar un aviso cuando este al borde de romperse
    }

    public void Break(ICharacter character)
    {
        if (this.WeaponDurability <= 0)
        {
            Console.WriteLine($"¡\"{this.WeaponName}\" has broken! You should buy a new one."); //aviso
            character.Weapon = null; //se elimina el arma del personaje
        }
        if (this.WeaponDurability <= 15) //aviso de cuando este por romperse
        {
            Console.WriteLine($"¡\"{this.WeaponName}\" is about to break! You should repair it."); //aviso
        }
    }
}

