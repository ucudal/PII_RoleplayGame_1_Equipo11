//Felipe Villaronga

using NUnit.Framework;
using Inventory;
using Characters;
using Combat;

namespace Test.Library
{
    public class ElvesTests
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
            Assert.AreEqual(expectedElfName, elfTest.Name);
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
    }
}