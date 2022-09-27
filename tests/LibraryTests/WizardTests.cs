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

        
        [Test]
        public void IncorrectWeaponName()
        {
            //Consturccion
            const string initialName = "Not in ItemsStore";
            string expectedName = null;
            int expectedPower = 0;

            //Ejecucion
            IItems weaponTest = new Weapons(initialName);

            //Comprobacion
            Assert.AreEqual(expectedName, weaponTest.name);
            Assert.AreEqual(expectedPower, weaponTest.Power);
        }

        public void IncorrectArmorName()
        {
            //Construccion
            const string initialName = "Not in ItemsStore";
            const string expectedName = null;
            int expectedPower= 0;
            

            //Ejecucion
            IItems armorTest= new Armors (initialName);

            //Comprobacion
            Assert.AreEqual(expectedName, armorTest.name);
            Assert.AreEqual(expectedPower, armorTest.Power);
        }  
    }
}
