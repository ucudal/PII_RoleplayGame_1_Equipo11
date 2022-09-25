using NUnit.Framework;
using Inventory;
using WizardCharacter;
using Characters;

namespace Test.Library
{
    public class WizardTest
    {
        [Test]
        public void correctWizardInput()
        {
            ICharacter wizard = new Wizards("Kassadin", new Weapons("Rabadons Hat"), new Armors("Merlin Cape"), new MagicItems("Book of spells"));
            string expectedName= "Kassadin";
            int expectedArmor= 10;
            int expectedDamage=40;
            string expectedWeaponName = "Rabadons Hat";
            Assert.AreEqual(wizard.Name,expectedName);
            Assert.AreEqual(wizard.Armor.ArmorProtection,expectedArmor);
            Assert.AreEqual(expectedDamage,wizard.Damage);
            Assert.AreEqual(wizard.Weapon.WeaponName,expectedWeaponName);
        }
        [Test]
        public void incorrectWizardArmorInput()
        {
            Armors wrongArmor = new Armors("Not in ItemsStore");
            Armors expectedArmor = null;
            ICharacter wizard = new Wizards("Kassadin", new Weapons("Rabadon's Hat"), wrongArmor, new MagicItems("Book of spells"));
            Assert.AreEqual(wizard.Armor,expectedArmor);
        }
        [Test]
        public void incorrectWizardNameInput()
        {
            string expectedName = null;
            ICharacter wizard = new Wizards("", new Weapons("Rabadon's Hat"), new Armors("Merlin Cape"), new MagicItems("Book of spells"));
            Assert.AreEqual(wizard.Name,null);
        }
    }
}
