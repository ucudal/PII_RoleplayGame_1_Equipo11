using System;
using System.Collections;
using CharacterActions;

namespace Characters;

public class Wizards : ICharacter
{
    ArrayList items = new ArrayList();
    string Description {get;}
    int Damage {get;}

    int Health {get;}

    int Armor {get;}

    
    public Wizards()
    {
        this.Description= "Este personaje tiene el dominio de la magia";
        this.Damage = 20;
        this.Health= 100;
        if(this.items.Contains("Armor"))
        {
            this.Armor=50;
        }
        else
        {
            this.Armor=0;
        }
    }
    
    public void Attack(ICharacter enemy)
    {
        if(this.items.Contains("Baston magico"))
        {
            enemy.Health-=(this.Damage+20);
        }
        else
        {
            enemy.Health-=this.Damage;
        }
    }


}
