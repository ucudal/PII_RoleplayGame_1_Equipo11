using System;
using Characters;
using Inventory;

namespace Combat;
public class AttackInitiator
{
    public static void Attack(ICharacter deffender, ICharacter Attacker) //Este seria el modelo de ataque de un pj, se llama al metodo mediante la interfaz aun no creada "IAttack"
    {
        if (Attacker.IsAlive() & deffender.IsAlive())
        {
            int finalDamage = Attacker.Strength;
            int protection = 0;
            if (Attacker.Weapon != null)
            {
                int weaponDamage = Attacker.Weapon.Power * 1 / 2; //Se multiplica el golpe por la mitad de daño del arma, es simplemente por jugabilidad, abierto a modificaciones
                Attacker.Weapon.Durability -= 5; //la "vida" del arma disminuye un 5% con cada golpe
                finalDamage += weaponDamage; //sumo el daño del arma mas el daño predeterminado del personaje
            }
            if (deffender.Armor != null) //aseguro que el personaje tenga una armadura equipada
            {
                protection = (finalDamage * deffender.Armor.Power) / 100; //regla de tres donde calculo, en base al puntaje de armorProtection cuanta vida salva
                Attacker.Armor.Durability -= 5; //la "vida" de cada pieza disminuye en un 5% por cada golpe
            }

            finalDamage -= protection; //el daño final termina siendo el daño total del pj - la proteccion de la armadura de quien se defiende
            deffender.HPChanger(-finalDamage); //le resto a la vida de quien se defiende, tantos puntos valga el daño final
        }
        else { Console.WriteLine($"{Attacker.Name} no pudo atacar a {deffender.Name}"); }
        if (deffender.GetHP()<=0)
        {
           Kill(deffender,Attacker);
        }
    }
    private static void Kill(ICharacter deffender,ICharacter killer)
    {
        ConsolePrinter.CharactersDeath(deffender,killer);
    }

}
