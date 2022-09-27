using NUnit.Framework;
using Inventory;
using Characters;
using NPC;
using Combat;

namespace Test.Library
{
    public class BlacksmithTest
    {
        [Test]
        public void weaponRepairTest()
        {
            //Construccion
            Weapons weapon = new Weapons("Rabadons Hat");
            ICharacter wizard = new Wizards("Kassadin", weapon, new Armors("Merlin Cape"), new MagicItems("Book of Spells"));
            ICharacter wizard2 = new Wizards("Zakarias", new Weapons("Rabadons Hat"), new Armors("Merlin Cape"), new MagicItems("Book of Spells"));
            wizard.Equip(weapon);

            //Ejecucion
            AttackInitiator.Attack(wizard,wizard2);
            BlackSmith.WeaponRepair(wizard,weapon);

            //Comprobacion
            Assert.AreEqual(100,wizard.Weapon.Durability);

        }
        
        [Test]
        public void armorRepairTest()
        {
            //Construccion
            Armors armor = new Armors("Merlin Cape");
            ICharacter wizard = new Wizards("Kassadin", new Weapons("Rabadons Hat"), armor, new MagicItems("Book of Spells"));
            ICharacter wizard2 = new Wizards("Zakarias", new Weapons("Rabadons Hat"), new Armors("Merlin Cape"), new MagicItems("Book of Spells"));
            int initialCoins= wizard.GetCoins();

            //Ejecucion
            wizard.Equip(armor);
            AttackInitiator.Attack(wizard2,wizard);
            BlackSmith.ArmorRepair(wizard,armor);

            //Comprobacion
            Assert.AreEqual(100,wizard.Armor.Durability);

        }
        [Test]
        public void weaponEnchanmentTest()
        {
            //Construccion
            Weapons weapon = new Weapons("Rabadons Hat");
            int preEnchantmentPower= weapon.Power;
            ICharacter wizard = new Wizards("Kassadin", weapon, new Armors("Merlin Cape"), new MagicItems("Book of Spells"));
            int initialCoins=wizard.GetCoins();
            int itemPrice = ItemsStore.Prices[weapon.name];
            wizard.Equip(weapon);
            wizard.InventoryAdd(weapon);
            
            //Ejecucion
            BlackSmith.WeaponEnchantment(wizard,weapon);
            
            //Comprobacion
            Assert.IsTrue(wizard.Weapon.Power==(preEnchantmentPower+((preEnchantmentPower*30)/100)));
            Assert.IsTrue(wizard.GetCoins()==initialCoins-itemPrice);


        }

        [Test]
        public void armorEnchanmentTest()
        {
            //Construccion
            Armors armor= new Armors("Merlin Cape");
            int preEnchantmentPower= armor.Power;
            ICharacter wizard = new Wizards("Kassadin", new Weapons("Rabadons Hat"), armor, new MagicItems("Book of Spells"));
            int initialCoins=wizard.GetCoins();
            int itemPrice = ItemsStore.Prices[armor.name];
            wizard.InventoryAdd(armor);
            wizard.Equip(armor);
            
            //Ejecucion
            BlackSmith.ArmorEnchantment(wizard,armor);
            
            //Comprobacion
            Assert.AreEqual(wizard.Armor.Power,(preEnchantmentPower+((preEnchantmentPower*50)/100)));
            Assert.IsTrue(wizard.GetCoins()==initialCoins-itemPrice);


        }

        public void notInInventoryTest()
        {


        }
    }
}