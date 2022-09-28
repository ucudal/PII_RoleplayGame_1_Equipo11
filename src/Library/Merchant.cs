using System;
using Characters;

namespace Inventory;
public class Merchant
{
    public static void ArmorBuy(ICharacter Buyer, Armors Armor)
    {
        if (Buyer.GetCoins() >= ItemsStore.GetPrice(Armor))
        {
            Buyer.InventoryAdd(Armor);
            Buyer.Transaction(false, ItemsStore.GetPrice(Armor));
            ConsolePrinter.succesfullArmorSale(Armor);
        }
        else { ConsolePrinter.NotEnoughCoins(); }
    }
    public static void ArmorSell(ICharacter Seller, Armors Armor)
    {
        if (Seller.ArmorInventory.Contains(Armor))
        {
            if (Armor.Durability == 100)
            {
                Seller.Transaction(true, ItemsStore.Prices[Armor.Name]);
            }
            else
            {
                //sin importar que este en 1 o 99 que la venda a la mitad de precio de la tienda
                //sino se puede hacer regla de tres de acuerdo a que tan roto esta
                Seller.Transaction(true, (ItemsStore.Prices[Armor.Name] / 2));
                ConsolePrinter.soldItem(Seller, Armor);
            }
            Seller.ArmorInventory.Remove(Armor);
        }
        else
        {
            ConsolePrinter.NotInInventory(Armor);
        }
    }


    
    public static void WeaponBuy(ICharacter Buyer, Weapons weapon)
    {
        if (Buyer.GetCoins() >= ItemsStore.GetPrice(weapon))
        {
            Buyer.InventoryAdd(weapon);
            Buyer.Transaction(false, ItemsStore.GetPrice(weapon));
            ConsolePrinter.succesfullWeaponSale(weapon);
            ConsolePrinter.equippedItem(Buyer, weapon);
        }
        else { ConsolePrinter.NotEnoughCoins(); }
    }
    public static void WeaponSell(ICharacter Seller, Weapons weapon)
    {
        if (Seller.WeaponInventory.Contains(weapon))
        {
            if (weapon.Durability == 100)
            {
                Seller.Transaction(true, ItemsStore.Prices[weapon.Name]);
                ConsolePrinter.soldItem(Seller,weapon);
            }
            else
            {
                //sin importar que este en 1 o 99 que la venda a la mitad de precio de la tienda
                //sino se puede hacer regla de tres de acuerdo a que tan roto esta
                Seller.Transaction(true, (ItemsStore.Prices[weapon.Name] / 2));
                ConsolePrinter.soldItem(Seller,weapon);
            }
            Seller.WeaponInventory.Remove(weapon);
        }
        else
        {
            ConsolePrinter.NotInInventory(weapon);
        }
    }
}
