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
            Weapons weaponTest = new Weapons("Elf Hammer", 5);
            Armors armorTest = new Armors("Iron Helmet", 9);
            MagicItems magicItemTest = new MagicItems("Rabbit's Foot"); //atento a cambiar esto cuando se desarrolle esta clase
            ICharacter elf1 = new Elves(initialElfName, weaponTest, armorTest, magicItemTest);

            //Comprobacion
            Assert.AreEqual(expectedElfName, elf1.Name);
        }
        public void IncorrectElfNameTest()
        {
            //Creacion
            string initialElfName = "";
            string expectedElfName = null;

            //Ejecucion
            Weapons weaponTest = new Weapons("Elf Hammer", 5);
            Armors armorTest = new Armors("Iron Helmet", 9);
            MagicItems magicItemTest = new MagicItems("Rabbit's Foot"); //atento a cambiar esto cuando se desarrolle esta clase
            ICharacter elfTest = new Elves(initialElfName, weaponTest, armorTest, magicItemTest);

            //Comprobacion
            Assert.AreEqual(expectedElfName, elfTest.Name);
        }
        public void CorrectElfWeaponTest()
        {
            //Creacion
            Weapons initialElfWeapon = new Weapons("Elf Hammer", 5);
            Weapons expectedElfWeapon = initialElfWeapon;

            //Ejecucion
            Armors armorTest = new Armors("Iron Helmet", 9);
            MagicItems magicItemTest = new MagicItems("Rabbit's Foot"); //atento a cambiar esto cuando se desarrolle esta clase
            ICharacter elfTest = new Elves("Ragnar", initialElfWeapon, armorTest, magicItemTest);

            //Comprobacion
            Assert.AreEqual(expectedElfWeapon, elfTest.Weapons[0]);
        }
        public void IncorrectElfWeaponTest()
        {
            //Creacion
            Weapons initialElfWeapon = new Weapons("Not in ItemsStore", 5);
            Weapons expectedElfWeapon = null;

            //Ejecucion
            Armors armorTest = new Armors("Iron Helmet", 9);
            MagicItems magicItemTest = new MagicItems("Rabbit's Foot"); //atento a cambiar esto cuando se desarrolle esta clase
            ICharacter elfTest = new Elves("Ragnar", initialElfWeapon, armorTest, magicItemTest);

            //Comprobacion
            Assert.AreEqual(expectedElfWeapon, elfTest.Weapons[0]);
        }
        public void CorrectElfArmorTest()
        {
            //Creacion
            Armors initialElfArmor = new Armors("Iron Helmet", 9);
            Armors expectedElfArmor = initialElfArmor;
            

            //Ejecucion
            
            Weapons weaponTest = new Weapons("Elf Hammer", 5);
            MagicItems magicItemTest = new MagicItems("Rabbit's Foot"); //atento a cambiar esto cuando se desarrolle esta clase
            ICharacter elfTest = new Elves("Ragnar", weaponTest, initialElfArmor, magicItemTest);

            //Comprobacion
            Assert.AreEqual(expectedElfArmor, elfTest.Armors[0]);
        }
        public void IncorrectElfArmorTest()
        {
            //Creacion
            Armors initialElfArmor = new Armors("Not in ItemsStore", 9);
            Armors expectedElfArmor = null;
            

            //Ejecucion
            
            Weapons weaponTest = new Weapons("Elf Hammer", 5);
            MagicItems magicItemTest = new MagicItems("Rabbit's Foot"); //atento a cambiar esto cuando se desarrolle esta clase
            ICharacter elfTest = new Elves("Ragnar", weaponTest, initialElfArmor, magicItemTest);

            //Comprobacion
            Assert.AreEqual(expectedElfArmor, elfTest.Armors[0]);
        }

        public void CorrectElfMagicItemTest()
        {
            //Creacion
            MagicItems initialElfMagicItem = new MagicItems("Rabbit's Foot"); //atento a cambiar esto cuando se desarrolle esta clase
            MagicItems expectedElfMagicItem = initialElfMagicItem;
            

            //Ejecucion
            
            Weapons weaponTest = new Weapons("Elf Hammer", 5);
            Armors armorTest = new Armors("Iron Helmet", 9);
            ICharacter elfTest = new Elves("Ragnar", weaponTest, armorTest, initialElfMagicItem);

            //Comprobacion
            Assert.AreEqual(expectedElfMagicItem, elfTest.Armors[0]);
        }

        public void IncorrectElfMagicItemTest()
        {
            //Creacion
            MagicItems initialElfMagicItem = new MagicItems("Not in ItemsStore"); //atento a cambiar esto cuando se desarrolle esta clase
            MagicItems expectedElfMagicItem = null;
            

            //Ejecucion
            
            Weapons weaponTest = new Weapons("Elf Hammer", 5);
            Armors armorTest = new Armors("Iron Helmet", 9);
            ICharacter elfTest = new Elves("Ragnar", weaponTest, armorTest, initialElfMagicItem);

            //Comprobacion
            Assert.AreEqual(expectedElfMagicItem, elfTest.Armors[0]);
        }
        //faltan los tests de Attack, de IsAlive
    }
}