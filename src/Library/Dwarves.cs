using System;

namespace Characters;

public class Dwarves : ICharacter
{
    string Description { get; }
    public string Name { get ; set; } //hacer la comprobacion de que el string no este vacio
         
    public Dwarves()
    {
        this.Description= "Son seres temperamentales que se destacan en el combate, su gran resistencia y lealtad.";
        /*this.Name = Name; //nombre
        this.Weapons = weapons; //armas
        this.Armors = armors; //armaduras
        this.MagicItems = magicItems; //objetos magicos
        this.Coins = coins; //riqueza 
        this.Strength = ; // cada golpe saca (¿?) de vida
        this.HP = ; //tiene una vida maxima de (¿?), otros personajes pueden tener mas o menos*/
    }
    //el que escriba esta, si quiere vea la clase elves que es muy similar y esta bastante desarrollada
}
