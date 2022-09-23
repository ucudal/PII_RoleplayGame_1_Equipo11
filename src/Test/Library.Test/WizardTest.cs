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
            ICharacter wizard = new Wizards("Snoopy", new Armors("Merlin Cape",10), new Weapons("Master Wand",12), new MagicItems("Book of spells"));
            string expectedName= "Snoopy";
            int expectedArmor= 10;
            int expectedDamage=32;
            bool expectedMagicItem= true;
            Assert.AreEqual(wizard.Name,expectedName);
            Assert.AreEqual(wizard.Armor,expectedArmor);
            Assert.AreEqual(expectedDamage,wizard.Damage);
            Assert.AreEqual(expectedMagicItem,wizard.MagicItems.ToString().Contains("Book of spells"));

            
        }
    }
}