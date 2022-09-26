using NUnit.Framework;
using Inventory;
using Characters;

namespace Test.Library
{
    public class DwarfTest
    {
        [SetUp]
        public void Setup()
        {
            // Insertá tu código de inicialización aquí

        }

        [Test]
        public void CorrectNameTest()
        {
            //Creacion
            string initialName = "Ragnar";
            string expectedName = "Ragnar";

            //Ejecucion
            ICharacter NTest = new Elves(initialName, new Weapons("Elf Hammer"), new Armors("Iron Helmet"), new MagicItems("Rabbit´s Foot"));

            //Comprobacion
            Assert.AreEqual(expectedName,NTest.Name);
        }
    }
}