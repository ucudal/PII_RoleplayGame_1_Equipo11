using System;
using Characters;

namespace Inventory;

public class Armors
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

}
