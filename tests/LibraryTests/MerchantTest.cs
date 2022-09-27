using NUnit.Framework;
using Inventory;
using Characters;

namespace Test.Library
{
    public class MerchantTest
    {
        [Test]
        public void correctWeaponSale()
        {
            //Construccion
            ICharacter wizard = new Wizards("Kassadin", new Weapons("Rabadons Hat"), new Armors("Merlin Cape"), new MagicItems("Book of Spells"));
            Weapons sword = new Weapons("Ultimate Sword");
            
            //Ejecucion
            Merchant.WeaponBuy(wizard, sword);
            //Comprobacion´
            
            Assert.IsTrue(wizard.WeaponInventory.Contains(sword));
            Assert.AreEqual(31,wizard.GetCoins());

        }
        [Test]
        public void correctArmorSale()
        {
            //Construccion
            ICharacter wizard = new Wizards("Kassadin", new Weapons("Rabadons Hat"), new Armors("Merlin Cape"), new MagicItems("Book of Spells"));
            Armors armor = new Armors("Spirit Belt");
            
            //Ejecucion
            Merchant.ArmorBuy(wizard, armor);
            
            //Comprobacion
            Assert.IsTrue(wizard.ArmorInventory.Contains(armor));
            Assert.AreEqual(82,wizard.GetCoins());
        }

        [Test]
        public void insufficentCoinsWeapon()
        {
            //Construccion
            ICharacter wizard = new Wizards("Kassadin", new Weapons("Rabadons Hat"), new Armors("Merlin Cape"), new MagicItems("Book of Spells"));
            Weapons sword = new Weapons("Ultimate Sword");
            Weapons sword2 = new Weapons("Mythril BattleAxe");

            //Ejecucion
            Merchant.WeaponBuy(wizard, sword);
            Merchant.WeaponBuy(wizard, sword2);

            //Comprobacion
            Assert.AreEqual(wizard.GetCoins(),31);
            Assert.IsTrue(!wizard.WeaponInventory.Contains(sword2));
            
        }

        [Test]
        public void insufficentCoinsArmor()
        {
            //Construccion
            ICharacter wizard = new Wizards("Kassadin", new Weapons("Rabadons Hat"), new Armors("Merlin Cape"), new MagicItems("Book of Spells"));
            Weapons sword = new Weapons("Ultimate Sword");
            Armors armor = new Armors("Dwarf heavy Chain Chesplate");

            //Ejecucion
            Merchant.WeaponBuy(wizard, sword);
            Merchant.ArmorBuy(wizard, armor);
            
            //Comprobacion
            Assert.AreEqual(wizard.GetCoins(),31);
            Assert.IsTrue(!wizard.ArmorInventory.Contains(armor));
            
        }

        [Test]
        public void weaponSell()
        {
            //Construccion
            ICharacter wizard = new Wizards("Kassadin", new Weapons("Rabadons Hat"), new Armors("Merlin Cape"), new MagicItems("Book of Spells"));
            Weapons sword = new Weapons("Ultimate Sword");

            //Ejecucion
            Merchant.WeaponBuy(wizard, sword);
            Merchant.WeaponSell(wizard, sword);

            //Comprobacion
            Assert.IsTrue(!wizard.WeaponInventory.Contains(sword));
            Assert.IsTrue(wizard.GetCoins()==100);
        }
        
        [Test]
        public void armorSell()
        {
            //Construccion
            ICharacter wizard = new Wizards("Kassadin", new Weapons("Rabadons Hat"), new Armors("Merlin Cape"), new MagicItems("Book of Spells"));
            Armors armor = new Armors("Spirit Belt");
            

            //Ejecucion
            Merchant.ArmorBuy(wizard, armor);
            Merchant.ArmorSell(wizard, armor);

            //Comprobacion
            Assert.IsTrue(!wizard.ArmorInventory.Contains(armor));
            Assert.IsTrue(wizard.GetCoins()==100);
        }
    }
}
