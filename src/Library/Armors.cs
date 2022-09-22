using System;
using Characters;

namespace Inventory;

public class Armors
{
    ICharacter character;

    private string armorName;
    public string ArmorName
    {

        get
        {
            return this.ArmorName;
        }

        set
        {
            if (ItemsStore.Armors.ContainsKey(armorName)) //comprueba que el nombre del armor exista en la "base de datos" (ItemsStore)
            {
                this.ArmorName = armorName;
            }
        }
        //seguir haciendo el resto (durabilidad, precio, proteccion)
        //metodos de comprar, vender, tradear, reparar, mejorar(¿?), equipar, y quitar del inventario
    }
}