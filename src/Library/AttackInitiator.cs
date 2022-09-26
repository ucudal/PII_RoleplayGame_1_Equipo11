using System;
using Characters;
using Inventory;

namespace Combat;
public class AttackInitiator
{
    //  Este es el modelo de ataque de un pj a otro
    public static void Attack(ICharacter deffender, ICharacter Attacker) 
    {
        if (Attacker.IsAlive() & deffender.IsAlive())
        {
            //  Ambos pj siguen vivos

            int finalDamage = Attacker.Strength;
            int protection = 0;

            //  Evaluo que el atacante tenga un arma activa como principal
            if (Attacker.Weapon != null)
            {
                //  Se multiplica el golpe por la mitad de daño del arma, es simplemente por jugabilidad, abierto a modificaciones
                int weaponDamage = Attacker.Weapon.Power * 1 / 2; 

                 // la "vida" del arma disminuye un 5% con cada golpe
                Attacker.Weapon.Durability -= 5;

                //  sumo el daño del arma mas el daño predeterminado del personaje
                finalDamage *= weaponDamage; 
            }
            //  aseguro que el personaje tenga una armadura equipada
            if (deffender.Armor != null) 
            {
                //  regla de tres donde calculo, en base a la proteccion de la armadura (Armor.Power) cuanto daño "evita"
                protection = (finalDamage * deffender.Armor.Power) / 100; 

                //  la "vida" de cada pieza disminuye en un 5% por cada golpe
                deffender.Armor.Durability -= 5; 
            }
            //  el daño final termina siendo el daño total del pj - la proteccion de la armadura de quien se defiende
            finalDamage -= protection; 

            //  le resto a la vida de quien se defiende, tantos puntos valga el daño final
            deffender.HPChanger(-finalDamage); 

            ConsolePrinter.AttackOnTarget(Attacker, deffender);
            if (!deffender.IsAlive())
            {
                ConsolePrinter.DeathPrinter(deffender,Attacker);
            }
            
        }
        else 
        {
            ConsolePrinter.unsuccessfullAttack(Attacker,deffender); 
        }
    }

}
