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
        public void CorrectElfNameTest()
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
        public void IncorrectElfNameTest()
        {
            //Creacion
            string initialElfName = "";
            string expectedElfName = null;

            //Ejecucion
            ICharacter elfTest = new Elves(initialElfName, new Weapons("Elf Hammer"), new Armors("Iron Helmet"));

            //Comprobacion
            Assert.AreEqual(expectedElfName, elfTest.Name);
        }

        [Test]
        public void ExistingWeaponTest()
        {
            //Creacion
            Weapons initialElfWeapon = new Weapons("Elf Hammer");
            Weapons expectedElfWeapon = initialElfWeapon;

            //Ejecucion        
            ICharacter elfTest = new Elves("Ragnar", initialElfWeapon, new Armors("Iron Helmet"));

            //Comprobacion
            Assert.AreEqual(expectedElfWeapon, elfTest.Weapon);
        }

        [Test]
        public void InexistantWeaponTest()
        {
            //CreacionB
            Weapons initialElfWeapon = new Weapons("Not in ItemsStore");
            string expectedElfWeapon = null;

            //Ejecucion
            ICharacter elfTest = new Elves("Ragnar", initialElfWeapon, new Armors("Iron Helmet"));

            //Comprobacion
            Assert.AreEqual(expectedElfWeapon, elfTest.Weapon.name);
        }

        [Test]
        public void CorrectElfArmorTest()
        {
            //Creacion
            Armors initialElfArmor = new Armors("Iron Helmet");
            Armors expectedElfArmor = initialElfArmor;
            

            //Ejecucion
            ICharacter elfTest = new Elves("Ragnar", new Weapons("Elf Hammer"), initialElfArmor);

            //Comprobacion
            Assert.AreEqual(expectedElfArmor, elfTest.Armor);
        }

        [Test]
        public void IncorrectElfArmorTest()
        {
            //Creacion
            Armors initialElfArmor = new Armors("Not in ItemsStore");
            Armors expectedElfArmor = null;
            

            //Ejecucion
            ICharacter elfTest = new Elves("Ragnar", new Weapons("Elf Hammer"), initialElfArmor);

            //Comprobacion
            Assert.AreEqual(expectedElfArmor, elfTest.Armor);
        }
        //faltan los tests de Attack, de IsAlive
    }
}