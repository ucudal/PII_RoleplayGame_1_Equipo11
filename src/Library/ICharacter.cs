using System;
using CharacterWizard;
namespace CharacterActions;

public interface ICharacter
{
    int Health {get;} 
    void Attack(ICharacter enemy)
    { 
    }
    

}
