using System;
using Characters;

namespace Inventory;
public class Merchant
{
 public static void startSale(ICharacter Buyer,IItems item)
 {
    if (Buyer.GetCoins()>=ItemsStore.GetPrice(item))
    {
        Buyer.InventoryAdd(item);
        Buyer.Transaction(false,ItemsStore.GetPrice(item));
    }
    else{Console.WriteLine("Not Enough Gold,Get out of my sight!Fool");}
 }

}
