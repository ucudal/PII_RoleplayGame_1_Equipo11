using System;
using Characters;

namespace Inventory;

public class Armors : IItems
{
    public Armors(string armorName)
    {
        this.ArmorName = armorName;
        this.ArmorProtection = ItemsStore.Armors[armorName];
        this.ArmorDurability = 100; //arranca con 100%, en cada ataque recibido va a ir disminuyendo
    }
    //ICharacter character;
    private string armorName;
    public string ArmorName
    {

        get
        {
            return this.armorName;
        }

        set
        {
            if (ItemsStore.Armors.ContainsKey(value)) //comprueba que el nombre del armor exista en la "base de datos" (ItemsStore)
            {
                this.armorName = value;
            }
        }
        //seguir haciendo el resto (durabilidad, precio, proteccion)
        //metodos de comprar, vender, tradear, reparar, mejorar(¿?), equipar, y quitar del inventario
    }

    public int ArmorProtection {get;}
    public int ArmorDurability { get; set; }

    public void Break(ICharacter character)
    {
        if (this.ArmorDurability <= 0)
        {
            Console.WriteLine($"¡\"{this.ArmorName}\" has broken! You should buy a new one."); //aviso
            character.Armor = null; //se elimina el arma del personaje
        }
        if (this.ArmorDurability <= 15) //aviso de cuando este por romperse
        {
            Console.WriteLine($"¡\"{this.ArmorName}\" is about to break! You should repair it."); //aviso
        }
    }
     public void Equip(ICharacter character) //metodo para equipar armas obtenidas no desde la tienda (e.g: peleando)

    {
        character.Armor = this;
        Console.WriteLine($"\"{character.Name}\" now equips \"{this.ArmorName}\".");
    }

    public void Desequip(ICharacter character)
    {
        if (character.Armor == this)
        {
            Console.WriteLine($"{character.Armor.ArmorName} removed successfully.");
            character.Weapon = null;
        }
        else
        {
            Console.WriteLine($"Error: \"{character.Name}\" does not equip \"{this.ArmorName}\".");
        }
        //Es necesario agregar un metodo Break, que quite el arma del inventario cuando se rompa
        //Tambien se podria dar un aviso cuando este al borde de romperse
    }


}
