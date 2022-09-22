using System;
using System.Collections;
using Characters;

namespace Inventory;

public interface IStore
{
    
    void Buy(ICharacter character);
    void Sell(ICharacter character);
    void Trade(ICharacter character, ICharacter character2, IItems item2);
}
