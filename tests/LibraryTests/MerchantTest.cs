using NUnit.Framework;
using Inventory;
using Characters;

namespace Test.Library
{
    public class WizardTest
    {
        [Test]
        public void correctWeaponSale()
        {
            ICharacter wizard = new Wizards("Kassadin", new Weapons("Rabadons Hat"), new Armors("Merlin Cape"), new MagicItems("Book of Spells"));
            Weapons sword = new Weapons("Ultimate Sword");
            Merchant.WeaponBuy(wizard, sword);
            Assert.IsTrue(wizard.WeaponInventory.Contains(sword));
            Assert.AreEqual(31,wizard.GetCoins());

        }
        [Test]
        public void correctArmorSale()
        {
            ICharacter wizard = new Wizards("Kassadin", new Weapons("Rabadons Hat"), new Armors("Merlin Cape"), new MagicItems("Book of Spells"));
            Armors armor = new Armors("Spirit Belt");
            Merchant.ArmorBuy(wizard, armor);
            Assert.IsTrue(wizard.ArmorInventory.Contains(armor));
            Assert.AreEqual(82,wizard.GetCoins());
        }

        [Test]
        public void insufficentCoinsWeapon()
        {
            ICharacter wizard = new Wizards("Kassadin", new Weapons("Rabadons Hat"), new Armors("Merlin Cape"), new MagicItems("Book of Spells"));
            Weapons sword = new Weapons("Ultimate Sword");
            Weapons sword2 = new Weapons("Mythril BattleAxe");
            Merchant.WeaponBuy(wizard, sword);
            Merchant.WeaponBuy(wizard, sword2);
            Assert.AreEqual(wizard.GetCoins(),31);
            Assert.IsTrue(!wizard.WeaponInventory.Contains(sword2));
            
        }

        [Test]
        public void insufficentCoinsArmor()
        {
            ICharacter wizard = new Wizards("Kassadin", new Weapons("Rabadons Hat"), new Armors("Merlin Cape"), new MagicItems("Book of Spells"));
            Weapons sword = new Weapons("Ultimate Sword");
            Armors armor = new Armors("Dwarf heavy Chain Chesplate");
            Merchant.WeaponBuy(wizard, sword);
            Merchant.ArmorBuy(wizard, armor);
            Assert.AreEqual(wizard.GetCoins(),31);
            Assert.IsTrue(!wizard.ArmorInventory.Contains(armor));
            
        }

        [Test]
        public void weaponSell()
        {
            ICharacter wizard = new Wizards("Kassadin", new Weapons("Rabadons Hat"), new Armors("Merlin Cape"), new MagicItems("Book of Spells"));
            Weapons sword = new Weapons("Ultimate Sword");
            Merchant.WeaponBuy(wizard, sword);
            Merchant.WeaponSell(wizard, sword);
            Assert.IsTrue(!wizard.WeaponInventory.Contains(sword));
            Assert.IsTrue(wizard.GetCoins()==100);
        }
        
        [Test]
        public void armorSell()
        {
            ICharacter wizard = new Wizards("Kassadin", new Weapons("Rabadons Hat"), new Armors("Merlin Cape"), new MagicItems("Book of Spells"));
            Armors armor = new Armors("Spirit Belt");
            Merchant.ArmorBuy(wizard, armor);
            Merchant.ArmorSell(wizard, armor);
            Assert.IsTrue(!wizard.ArmorInventory.Contains(armor));
            Assert.IsTrue(wizard.GetCoins()==100);
        }
    }
}
