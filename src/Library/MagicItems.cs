using System;
using Characters;

namespace Inventory;

public class MagicItems //: IItems
{
    ICharacter character;

    private string name;
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
                this.name= value;
            }
        }
    }
    public MagicItems(string name)
    {
        this.Name= name;
    }
    //seguir haciendo el resto (precio, poder)
    //metodos de comprar, vender, tradear, equipar, desequipar
    //ver la clase weapons que en principio es similar y ya esta bastnate desarrollada

}