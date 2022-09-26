public interface IBalance
{
    bool Transaction(bool operation, int value); //hace una transaccion ,el operation determina si se añade o pierde dinero, el bool determina si fue posible o no
    int GetCoins();  //get de coins
}
