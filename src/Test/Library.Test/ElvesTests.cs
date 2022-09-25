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
            ICharacter elf1 = new Elves(initialElfName);

            //Comprobacion
            Assert.AreEqual(expectedElfName, elf1.Name);
        }

        [Test]
        public void IncorrectElfNameTest()
        {
            //Creacion
            string initialElfName = "";
            string expectedElfName = null;

            //Ejecucion
            Weapons weaponTest = new Weapons("Elf Hammer");
            Armors armorTest = new Armors("Iron Helmet");
            MagicItems magicItemTest = new MagicItems("Rabbit's Foot"); //atento a cambiar esto cuando se desarrolle esta clase
            ICharacter elfTest = new Elves(initialElfName, weaponTest, armorTest, magicItemTest);

            //Comprobacion
            Assert.AreEqual(expectedElfName, elfTest.Name);
        }

        [Test]
        public void CorrectElfWeaponTest()
        {
            //Creacion
            Weapons initialElfWeapon = new Weapons("Elf Hammer");
            Weapons expectedElfWeapon = initialElfWeapon;

            //Ejecucion
            Armors armorTest = new Armors("Iron Helmet");
            MagicItems magicItemTest = new MagicItems("Rabbit's Foot"); //atento a cambiar esto cuando se desarrolle esta clase
            ICharacter elfTest = new Elves("Ragnar", initialElfWeapon, armorTest, magicItemTest);

            //Comprobacion
            Assert.AreEqual(expectedElfWeapon, elfTest.Weapons[0]);
        }

        [Test]
        public void IncorrectElfWeaponTest()
        {
            //Creacion
            Weapons initialElfWeapon = new Weapons("Not in ItemsStore");
            Weapons expectedElfWeapon = null;

            //Ejecucion
            Armors armorTest = new Armors("Iron Helmet");
            MagicItems magicItemTest = new MagicItems("Rabbit's Foot"); //atento a cambiar esto cuando se desarrolle esta clase
            ICharacter elfTest = new Elves("Ragnar", initialElfWeapon, armorTest, magicItemTest);

            //Comprobacion
            Assert.AreEqual(expectedElfWeapon, elfTest.Weapons[0]);
        }

        [Test]
        public void CorrectElfArmorTest()
        {
            //Creacion
            Armors initialElfArmor = new Armors("Iron Helmet");
            Armors expectedElfArmor = initialElfArmor;
            

            //Ejecucion
            
            Weapons weaponTest = new Weapons("Elf Hammer");
            MagicItems magicItemTest = new MagicItems("Rabbit's Foot"); //atento a cambiar esto cuando se desarrolle esta clase
            ICharacter elfTest = new Elves("Ragnar", weaponTest, initialElfArmor, magicItemTest);

            //Comprobacion
            Assert.AreEqual(expectedElfArmor, elfTest.Armors[0]);
        }

        [Test]
        public void IncorrectElfArmorTest()
        {
            //Creacion
            Armors initialElfArmor = new Armors("Not in ItemsStore");
            Armors expectedElfArmor = null;
            

            //Ejecucion
            
            Weapons weaponTest = new Weapons("Elf Hammer");
            MagicItems magicItemTest = new MagicItems("Rabbit's Foot"); //atento a cambiar esto cuando se desarrolle esta clase
            ICharacter elfTest = new Elves("Ragnar", weaponTest, initialElfArmor, magicItemTest);

            //Comprobacion
            Assert.AreEqual(expectedElfArmor, elfTest.Armors[0]);
        }

        [Test]
        public void CorrectElfMagicItemTest()
        {
            //Creacion
            MagicItems initialElfMagicItem = new MagicItems("Rabbit's Foot"); //atento a cambiar esto cuando se desarrolle esta clase
            MagicItems expectedElfMagicItem = initialElfMagicItem;
            

            //Ejecucion
            
            Weapons weaponTest = new Weapons("Elf Hammer");
            Armors armorTest = new Armors("Iron Helmet");
            ICharacter elfTest = new Elves("Ragnar", weaponTest, armorTest, initialElfMagicItem);

            //Comprobacion
            Assert.AreEqual(expectedElfMagicItem, elfTest.Armors[0]);
        }

        [Test]
        public void IncorrectElfMagicItemTest()
        {
            //Creacion
            MagicItems initialElfMagicItem = new MagicItems("Not in ItemsStore"); //atento a cambiar esto cuando se desarrolle esta clase
            MagicItems expectedElfMagicItem = null;
            

            //Ejecucion
            
            Weapons weaponTest = new Weapons("Elf Hammer");
            Armors armorTest = new Armors("Iron Helmet");
            ICharacter elfTest = new Elves("Ragnar", weaponTest, armorTest, initialElfMagicItem);

            //Comprobacion
            Assert.AreEqual(expectedElfMagicItem, elfTest.Armors[0]);
        }
        //faltan los tests de Attack, de IsAlive
    }
}