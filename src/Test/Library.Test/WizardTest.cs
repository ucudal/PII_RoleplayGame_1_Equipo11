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
            ICharacter wizard = new Wizards("Kassadin", new Weapons("Rabadon's hat"), new Armors("Merlin Cape"), new MagicItems("Book of spells"));
            string expectedName= "Kassadin";
            int expectedArmor= 10;
            int expectedDamage=40;
            Assert.AreEqual(wizard.Name,expectedName);
            Assert.AreEqual(wizard.Armor,expectedArmor);
            Assert.AreEqual(expectedDamage,wizard.Damage);
            Assert.IsTrue(wizard.Weapon.WeaponName ==" Rabadon's hat");
        }
    }
}
