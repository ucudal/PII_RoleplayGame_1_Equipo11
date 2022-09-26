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
            ICharacter NTest = new Dwarves(initialName,new Weapons("Mythril BattleAxe"),new Armors("Iron Helmet"));

            //Comprobacion
            Assert.AreEqual(expectedName,NTest.Name);
        }
    }
}