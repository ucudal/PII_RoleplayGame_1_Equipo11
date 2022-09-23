using System;
using System.Collections.Generic;
using Characters;

namespace Inventory;
public class Weapons
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

    public Weapons(string weaponName, int damage, int weaponDurability)
    {
        this.WeaponName = weaponName;
        this.Damage = damage;
        this.WeaponDurability = 100; //arranca con 100%, en cada ataque va a ir disminuyendo
    }

    public void Repair(ICharacter character)
    {
        if (this.WeaponName.Equals(character))
        {
            int repairCost = ((100 - this.WeaponDurability) * 2) / 10; //simple regla de tres que establece que cada 10% que se arregla, 
                                                                       //se cobran 2 coins; y calcula cuanto cuesta arreglar la weapon hasta llegar a 100%
            if (character.Coins >= repairCost) //tiene suficientes coins
            {
                this.WeaponDurability = 100;
                Console.WriteLine($"{this.WeaponName} has been fully repaired.");
            }
            else
            {
                this.WeaponDurability = +(character.Coins * 10) / 2; //regla de tres que establece cuanto porcentaje arreglar de acuerdo a las coins que tiene
                Console.WriteLine($"{this.WeaponName} has been repaired up to {this.WeaponDurability}");
            }
        }
        else
        {

        }

    }
    public void Sell(ICharacter character)
    {
        if (this.WeaponDurability == 100)
        {
            character.Coins += ItemsStore.Prices[this.WeaponName];
        }
        else
        {
            //sin importar que este en 1 o 99 que la venda a la mitad de precio de la tienda
            //sino se puede hacer regla de tres de acuerdo a que tan roto esta
            character.Coins += (ItemsStore.Prices[this.WeaponName]/2);
        }
        //quitar el arma del inventario (desde Program llamar a character.Remove())
    }
    public void Buy(ICharacter character)
    {
        //Busque en la tienda el arma por su nombre (weapon.WeaponName) y busque su precio
        //hacer calculos (ver si puede o no comprar)
        //agregue el arma al inventario (desde Program llamar a charcater.Equip())
    }
    public void Trade(ICharacter character1, ICharacter character2, IItems item2)
    {
        //llamar al character.Remove() --> character2.Equip()
        //llamar al character2.Remove() --> character.Equip()
    }

    public void Equip(ICharacter character)

    {
        if (character.Armors.Count + character.Weapons.Count + character.MagicItems.Count <= 5)
        {
            character.Weapons.Add(this);
        }
        else
        {
            Console.WriteLine("You are only allowed to carry a maximum of 5 items.");
        }
    }
    public void Remove(ICharacter character)
    {
        character.Weapons.Remove(this);
        Console.WriteLine($"Item removed successfully. You now carry {character.Armors.Count + character.Weapons.Count + character.MagicItems.Count} items.");
    }
}

