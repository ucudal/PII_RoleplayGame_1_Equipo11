using System;
using Characters;

namespace Inventory;

public class MagicItems : IStore, IItems
{
    ICharacter character;

    private string itemName;
    public string ItemName
    {

        get
        {
            return this.ItemName;
        }

        set
        {
            if (ItemsStore.Items.ContainsKey(itemName)) //comprueba que el nombre del item exista en la "base de datos" (ItemsStore)
            {
                this.ItemName= itemName;
            }
        }
    }
    //seguir haciendo el resto (precio, poder)
    //metodos de comprar, vender, tradear, equipar, desequipar

}