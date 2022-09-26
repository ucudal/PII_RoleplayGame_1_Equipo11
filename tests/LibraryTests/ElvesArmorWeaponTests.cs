//Felipe Villaronga

using NUnit.Framework;
using Inventory;
using Characters;

namespace Test.Library
{
    public class ElvesTest
    {
        [SetUp]
        public void Setup()
        {
            // Insertá tu código de inicialización aquí

        }

        [Test]
        public void CorrectElfTest()
        {
            //Creacion
            string initialElfName = "Ragnar";
            string expectedElfName = "Ragnar";

            //Ejecucion
            ICharacter elfTest = new Elves(initialElfName, new Weapons("Elf Hammer"), new Armors("Iron Helmet"));

            //Comprobacion
            Assert.AreEqual(expectedElfName,elfTest.Name);
        }
    


        [Test]
        public void IncorrectNameElfTest()
        {
            //Creacion
            const string initialElfName = "";
            const string expectedElfName = null;

            //Ejecucion
            ICharacter elfTest = new Elves(initialElfName, new Weapons("Elf Hammer"), new Armors("Iron Helmet"));

            //Comprobacion
            Assert.AreEqual(expectedElfName, elfTest.Name);
        }

        [Test]
        public void CorrectWeaponTest()
        {
            //Creacion
            const string initialName = "Elf Hammer";
            const string expectedName = "Elf Hammer";
            int expectedPower = ItemsStore.Weapons[initialName];

            //Ejecucion        
            IItems weaponTest = new Weapons("Elf Hammer");

            //Comprobacion
            Assert.AreEqual(expectedName, weaponTest.name);
            Assert.AreEqual(expectedPower, weaponTest.Power);
        }

        [Test]
        public void IncorrectNameWeaponTest()
        {
            //CreacionB
            const string initialName = "Not in ItemsStore";
            string expectedName = null;
            int expectedPower = 0;

            //Ejecucion
            IItems weaponTest = new Weapons(initialName);

            //Comprobacion
            Assert.AreEqual(expectedName, weaponTest.name);
            Assert.AreEqual(expectedPower, weaponTest.Power);
        }

        [Test]
        public void CorrectArmorTest()
        {
            //Creacion
            const string initialName = "Iron Helmet";
            const string expectedName = "Iron Helmet";
            int expectedPower= ItemsStore.Armors[initialName];

            //Ejecucion
            IItems armorTest= new Armors (initialName);

            //Comprobacion
            Assert.AreEqual(expectedName, armorTest.name);
            Assert.AreEqual(expectedPower, armorTest.Power);
        }

        [Test]
        public void IncorrectNameArmorTest()
        {
            //Creacion
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