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
            ICharacter wizard = new Wizards("Kassadin", new Weapons("Rabadon's Hat"), new Armors("Merlin Cape"), new MagicItems("Book of spells"));
            string expectedName= "Kassadin";
            int expectedArmor= 10;
            int expectedDamage=40;
            string expectedWeaponName = "Rabadon's Hat";
            Assert.AreEqual(wizard.Name,expectedName);
            Assert.AreEqual(wizard.Armor.ArmorProtection,expectedArmor);
            Assert.AreEqual(expectedDamage,wizard.Damage);
            Assert.AreEqual(wizard.Weapon.WeaponName,expectedWeaponName);
        }
        [Test]
        public void incorrectWizardInput()
        {
            ICharacter wizard = new Wizards("Kassadin", new Weapons(""), new Armors(""), new MagicItems("Book of spells"));
            string expectedName= "Kassadin";
            int expectedArmor= 0;
            int expectedDamage=20;
            string expectedWeaponName = "Wizard Melee";
            Assert.AreEqual(wizard.Name,expectedName);
            Assert.AreEqual(wizard.Armor.ArmorProtection,expectedArmor);
            Assert.AreEqual(expectedDamage,wizard.Damage);
            Assert.AreEqual(wizard.Weapon.WeaponName,expectedWeaponName);
        }
    }
    
}
