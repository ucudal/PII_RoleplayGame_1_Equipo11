//Aca se podria escribir la interaccion de personajes

using System;
namespace Characters;

public class Combat
{
    private ICharacter attacker {get; set;}
    private ICharacter defender {get; set;}
    public void Fight(ICharacter attacker, ICharacter defender)
    {
        defender.HP-= attacker.Attack();
    }
    //ya pregunte si iba o no para esta entrega, cuando me respondan aviso
}