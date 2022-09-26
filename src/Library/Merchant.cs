using System;
using Characters;

namespace Inventory;
public class Merchant
{
    public static void startSale(ICharacter Buyer, IItems item)
    {
        if (Buyer.GetCoins() >= ItemsStore.GetPrice(item))
        {
            Buyer.InventoryAdd(item);
            Buyer.Transaction(false, ItemsStore.GetPrice(item));
        }
        else { ConsolePrinter.NotEnoughCoins(); }
    }
    public static void Purchase(ICharacter Seller, IItems item)
    {
        if (Seller.Inventory.Contains(item))
        {
            if (item.Durability == 100)
            {
                Seller.Transaction(true, ItemsStore.Prices[item.name]);
            }
            else
            {
                //sin importar que este en 1 o 99 que la venda a la mitad de precio de la tienda
                //sino se puede hacer regla de tres de acuerdo a que tan roto esta
                Seller.Transaction(true, (ItemsStore.Prices[item.name] / 2));
                ConsolePrinter.soldItem(Seller,item);
            }
            Seller.Inventory.Remove(item);
        }
        else
        {
            ConsolePrinter.NotInInventory(item);
        }
    }
}
