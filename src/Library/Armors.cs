using System;
using Characters;

namespace Inventory;

public class Armors : IItems
{
    public Armors(string name)
    {
        this.Name = name;
        this.Power = ItemsStore.Armors[name];
        this.Durability = 100; //arranca con 100%, en cada ataque recibido va a ir disminuyendo
    }
    //ICharacter character;
    private string name;
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
            if (name != null)
            {
                if (ItemsStore.Armors.ContainsKey(name)) //comprueba que el nombre de la weapon exista en la "base de datos" (ItemsStore)
                {
                    this.power = value;
                }
            }

        }

    }
    public string Name
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
    public void PowerChange(int value)
    {
        this.Power += value;
    }


}
