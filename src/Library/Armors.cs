using System;
using Characters;

namespace Inventory;

public class Armors : IItems
{
    public Armors(string name)
    {
        this.ArmorName = name;
        this.Power = power;
        this.Durability = 100; //arranca con 100%, en cada ataque recibido va a ir disminuyendo
    }
    //ICharacter character;
    private int power;
    public int Power
    {

        get
        {
            if (this.Durability <= 0) { return 0; }
            else { return this.power; }
        }

        set
        {
            if (ItemsStore.Armors.ContainsKey(this.name)) //comprueba que el nombre de la weapon exista en la "base de datos" (ItemsStore)
            {
                this.power = ItemsStore.Armors[this.name];
            }
        }

    }
    public string name { get; set; }
    public string ArmorName
    {

        get
        {
            return this.name;
        }

        set
        {
            if (ItemsStore.Armors.ContainsKey(value)) //comprueba que el nombre del armor exista en la "base de datos" (ItemsStore)
            {
                this.name = value;
            }
        }
        //seguir haciendo el resto (durabilidad, precio, proteccion)
        //metodos de comprar, vender, tradear, reparar, mejorar(¿?), equipar, y quitar del inventario
    }

    public int Durability { get; set; }

    public void Break(ICharacter character)
    {
        if (this.Durability <= 0)
        {
            ConsolePrinter.brokenItem(this); //aviso
            character.Armor = null; //se elimina el arma del personaje
        }
        if (this.Durability <= 15) //aviso de cuando este por romperse
        {
            ConsolePrinter.aboutToGetBrokenItem(this); //aviso
        }
    }
    public void Equip(ICharacter character) //metodo para equipar armas obtenidas no desde la tienda (e.g: peleando)

    {
        character.Armor = this;
        ConsolePrinter.equippedItem(character, this);
    }

    public void Unequip(ICharacter character)
    {
        if (character.Armor == this)
        {
            ConsolePrinter.unequippedItem(character, this);
            character.Armor = null;
        }
        else
        {
            ConsolePrinter.NotInInventory(this);
        }
        //Es necesario agregar un metodo Break, que quite el arma del inventario cuando se rompa
        //Tambien se podria dar un aviso cuando este al borde de romperse
    }


}
