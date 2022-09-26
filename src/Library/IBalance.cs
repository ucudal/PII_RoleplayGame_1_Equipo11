using System;
namespace Inventory;

public interface IBalance
{
    bool Transaction(bool operation, int value); //hace una transaccion ,el operation determina si se añade o pierde dinero, el bool determina si fue posible o no
    
    //get de coins
    int GetCoins();  
}
