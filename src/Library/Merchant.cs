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
        else { Console.WriteLine("Not Enough Gold. Get out of my sight! Fool."); }
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
                Console.WriteLine($"\"{item.name}\" has been sold, and removed succesfully.");
                Console.WriteLine($"\"{Seller.Name}\" now has an amount of {Seller.GetCoins()} coins.");
            }
            Seller.Inventory.Remove(item);
        }
        else
        {
            Console.WriteLine($"¡Cheater! You don't equip \"{item.name}\". ¡Get out of my sight! if you appreciate your life.");
        }
    }
}
