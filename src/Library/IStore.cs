using System;
using System.Collections;

namespace Inventory;

public interface IStore
{
    void Buy();
    void Sell();
    void Trade();
}
