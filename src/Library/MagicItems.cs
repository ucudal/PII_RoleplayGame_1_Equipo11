using System;
using Characters;

namespace Inventory;

public class MagicItems
{
    ICharacter character;

    private string name;
    private string power;
    public string Power
    {
        get
        {
            return this.power;
        }

        set
        {
            if (ItemsStore.Items.ContainsKey(name)) //comprueba que el nombre del item exista en la "base de datos" (ItemsStore)
            {
                this.power = ItemsStore.Items[name];
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
            if (ItemsStore.Items.ContainsKey(value)) //comprueba que el nombre del item exista en la "base de datos" (ItemsStore)
            {
                this.name = value;
            }
        }
    }
    public MagicItems(string name)
    {
        this.Name = name;
        this.Power = power;
    }




    //seguir haciendo el resto (precio, poder)
    //metodos de comprar, vender, tradear, equipar, desequipar
    //ver la clase weapons que en principio es similar y ya esta bastnate desarrollada

}