using NUnit.Framework;
using Inventory;
using Characters;

namespace Test.Library
{
    public class WizardTest
    {
        [Test]
        public void correctWizardInput()
        {
            //Construccion
            Weapons weapon = new Weapons("Rabadons Hat");
            Armors armor = new Armors("Merlin Cape");
            MagicItems magicItem = new MagicItems("Book of Spells");

            //Ejecucion
            ICharacter wizard = new Wizards("Kassadin", weapon, armor, magicItem);

            //Comprobacion
            string expectedName="Kassadin";
            Assert.AreEqual(wizard.Name,expectedName);
            Assert.AreEqual(wizard.Weapon,weapon);
            Assert.AreEqual(wizard.Armor,armor);


        }
        [Test]
        public void incorrectWizardInput()
        {
            //Construccion
            Weapons weapon = new Weapons("Rabadons Hat");
            Armors armor = new Armors("Merlin Cape");
            MagicItems magicItem = new MagicItems("Book of Spells");

            //Ejecucion
            ICharacter wizard = new Wizards("", weapon, armor, magicItem);

            //Comprobacion
            string expectedName=null;
            Assert.AreEqual(wizard.Name,expectedName);
            Assert.AreEqual(wizard.Weapon,weapon);
            Assert.AreEqual(wizard.Armor,armor);
        }
    }
}
