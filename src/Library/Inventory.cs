using System;
using System.Collections.Generic;

namespace Characters;

public class Inventory
{
    public ICharacter character;
    public List<string> inventory = new List<string>();
    private string weapon;
    private string armor;
    private string items;
    public string Weapon
    {

        get
        {
            return this.weapon;
        }

        set
        {
            if (!ItemsStore.Weapons.ContainsKey(weapon))
            {
                this.weapon = value;
                inventory.Add(this.weapon);
            }
        }

    }
    public string Armor
    {

        get
        {
            return this.armor;
        }

        set
        {
            if (!ItemsStore.Armors.ContainsKey(armor))
            {
                this.armor = value;
                inventory.Add(this.armor);
            }
        }

    }
    public string Items
    {

        get
        {
            return this.items;
        }

        set
        {
            if (!ItemsStore.Items.ContainsKey(items))
            {
                this.items = value;
                inventory.Add(this.items);
            }
        }

    }

    public void Equip(ICharacter character, string newObject)

    {
        if (inventory.Count <= 5)
        {
            inventory.Add(newObject);
        }
        else
        {
            Console.WriteLine("You are only allowed to carry a maximum of 5 items.");
        }
    }
    public void Remove(string eliminatedObject)
    {
        inventory.Remove(eliminatedObject);
        Console.WriteLine($"Item removed successfully. You now carry {inventory.Count} items.");
    }
}