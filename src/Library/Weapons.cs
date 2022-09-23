using System;
using System.Collections.Generic;
using Characters;

namespace Inventory;
public class Weapons : IItems
{
    ICharacter character;
    private string weaponName;
    public string WeaponName
    {

        get
        {
            return this.WeaponName;
        }

        set
        {
            if (!ItemsStore.Weapons.ContainsKey(weaponName)) //comprueba que el nombre de la weapon exista en la "base de datos" (ItemsStore)
            {
                this.WeaponName = weaponName;
            }
        }

    }
    public int WeaponDurability { get; set; }
    public int Damage { get; set; }

    public Weapons(string weaponName, int damage)
    {
        this.WeaponName = weaponName;
        this.Damage = damage;
        this.WeaponDurability = 100; //arranca con 100%, en cada ataque va a ir disminuyendo
    }

    public void Repair(ICharacter character)
    {

        if (character.Weapons.Contains(this))
        {
            int repairCost = ((100 - this.WeaponDurability) * 2) / 10; //simple regla de tres que establece que cada 10% que se arregla, 
                                                                       //se cobran 2 coins; y calcula cuanto cuesta arreglar la weapon hasta llegar a 100%
            if (character.Coins >= repairCost) //tiene suficientes coins
            {
                this.WeaponDurability = 100;
                Console.WriteLine($"{this.WeaponName} has been fully repaired.");
                Console.WriteLine($"\"{character.Name}\" now has an amount of {character.Coins} coins.");
            }
            else
            {
                this.WeaponDurability = +(character.Coins * 10) / 2; //regla de tres que establece cuanto porcentaje arreglar de acuerdo a las coins que tiene
                Console.WriteLine($"{this.WeaponName} has been repaired up to {this.WeaponDurability}");
                Console.WriteLine($"\"{character.Name}\" now has an amount of {character.Coins} coins.");
            }
        }
        else
        {
            Console.WriteLine($"Error: \"{character.Name}\" does not equip \"{this.WeaponName}\".");
        }

    }
    public void Sell(ICharacter character)
    {
        if (character.Weapons.Contains(this))
        {
            if (this.WeaponDurability == 100)
            {
                character.Coins += ItemsStore.Prices[this.WeaponName];
                character.Weapons.Remove(this);
            }
            else
            {
                //sin importar que este en 1 o 99 que la venda a la mitad de precio de la tienda
                //sino se puede hacer regla de tres de acuerdo a que tan roto esta
                character.Coins += (ItemsStore.Prices[this.WeaponName] / 2);
                Console.WriteLine($"\"{this.weaponName}\" has been sold, and removed succesfully.");
                 Console.WriteLine($"\"{character.Name}\" now has an amount of {character.Coins} coins.");

            }
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
            if (character.Armors.Count + character.Weapons.Count + character.MagicItems.Count <= 5)
            {
                if (character.Coins >= ItemsStore.Prices[this.WeaponName])
                {
                    character.Coins = -ItemsStore.Prices[this.WeaponName];
                    Console.WriteLine($"\"{this.weaponName}\" has been bought, and equiped succesfully.");
                    Console.WriteLine($"\"{character.Name}\" now has an amount of {character.Coins} coins.");
                }
            }
            else
            {
                Console.WriteLine("Error: You are only allowed to carry a maximum of 5 items.");
            }
        }
        else
        {
            Console.WriteLine($"Error: the store does not include the weapon \"{this.weaponName}\".");
        }
    }
    public void Trade(ICharacter character1, ICharacter character2, IItems item2)
    {
        //llamar al character.Remove() --> character2.Equip()
        //llamar al character2.Remove() --> character.Equip()
    }

    public void Equip(ICharacter character) //metodo para equipar armas obtenidas no desde la tienda (e.g: peleando)

    {
        if (character.Armors.Count + character.Weapons.Count + character.MagicItems.Count <= 5)
        {
            character.Weapons.Add(this);
            Console.WriteLine($"\"{character.Name}\" now equips \"{this.WeaponName}\".");
        }
        else
        {
            Console.WriteLine("Error: You are only allowed to carry a maximum of 5 items.");
        }
    }
    public void Remove(ICharacter character)
    {
        if (character.Weapons.Contains(this))
        {
            character.Weapons.Remove(this);
            Console.WriteLine($"Item removed successfully. You now carry {character.Armors.Count + character.Weapons.Count + character.MagicItems.Count} items.");
        }
        else
        {
            Console.WriteLine($"Error: \"{character.Name}\" does not equip \"{this.WeaponName}\".");
        }
        //Es necesario agregar un metodo Break, que quite el arma del inventario cuando se rompa
        //Tambien se podria dar un aviso cuando este al borde de romperse
    }
    public void Break()
    {
        if (this.WeaponDurability<=0) 
        {
            this.Remove(character); //se elimina el arma del personaje
            Console.WriteLine($"¡\"{this.weaponName}\" has broken! You should buy a new one."); //aviso
        }
        if (this.WeaponDurability<=15) //aviso de cuando este por romperse
        {
            Console.WriteLine($"¡\"{this.weaponName}\" is about to break! You should repair it."); //aviso
        }
    }
}

