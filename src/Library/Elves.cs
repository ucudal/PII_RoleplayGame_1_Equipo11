//Felipe Villaronga

using System;

namespace Characters;

public class Elves : ICharacter
{
    public string Description { get; }
    private string name;
    public int HP {get;set;}
    public int Strength {get;} //medido en hp del 1 al 100
    public int Coins { get; set; }
    public string Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (!string.IsNullOrEmpty(value))
            {
                this.name = value;
            }
        }
    }
    public Inventory inventory { get; set; }

    public Elves(string name, Inventory inventory, int coins)
    {
        this.Description = "Son criaturas supernaturales que tambien poseen características mágicas, se destacan por su compañerismo";
        this.Name = Name; //nombre
        this.inventory = inventory; //armas+armaduras+objetos
        this.Coins = coins; //riqueza 
        this.Strength= 8; // cada golpe saca 8 de vida
        this.HP= 80;
    }
    
    public int Attack() //Este seria el modelo de ataque de un elfo, se llama al metodo mediante la interfaz aun no creada "IAttack"
    {
        int damage= this.Strength+ (ItemsStore.Weapons[this.inventory.Weapon]*1/2); //Se multiplica el golpe por la mitad de daño del arma, es a modo de ejemplo y abierto a modificaciones
        return damage;
    }
    public void Equip() //
    {

    }
    public void Remove()
    {

    }

}