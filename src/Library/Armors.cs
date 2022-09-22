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

    private int armorProtection;
    public int ArmorProtection
    {

        get
        {
            return this.ArmorProtection;
        }

        set
        {
            if (ItemsStore.Armors.ContainsKey(armorName)) //comprueba que el nombre del armor exista en la "base de datos" (ItemsStore)
            {
                this.ArmorProtection = armorProtection;
            }
        }

    }
    public int ArmorDurability { get; set; }

    public Armors(string armorName, int armorProtection, int armorDurability)
    {
        this.ArmorName = armorName;
        this.ArmorProtection = armorProtection;
        this.ArmorDurability = 100; //arranca con 100%, en cada ataque recibido va a ir disminuyendo
    }
}
