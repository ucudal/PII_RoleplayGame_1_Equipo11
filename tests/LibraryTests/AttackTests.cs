//Felipe Villaronga

using NUnit.Framework;
using Inventory;
using Characters;
using Combat;

namespace Test.Library
{
    public class AttackTests
    {
        [SetUp]
        public void Setup()
        {
            // Insertá tu código de inicialización aquí

        }

        [Test]
        public void CorrectAttackTest()
        {
            //Creacion
            const int expectedDurability = 95;
            const int expectedDeffenderHP = 65;
            bool expectedIsAlive = true;

            //Ejecucion
            ICharacter elf1 = new Elves("Ragnar", new Weapons("Elf Hammer"), new Armors("Iron Helmet"));
            ICharacter elf2 = new Elves("Messi", new Weapons("Elf Hammer"), new Armors(""));
            AttackInitiator.Attack(elf2, elf1);



            //Comprobacion
            Assert.AreEqual(expectedDurability, elf1.Weapon.Durability);
            Assert.AreEqual(expectedDeffenderHP, elf2.GetHP());
            Assert.AreEqual(expectedIsAlive, elf2.IsAlive());
        }
        [Test]
        public void CorrectArmorProtectionTest()
        {
            //Creacion
            const int expectedWeaponDurability = 95;
            const int expectedArmorDurability = 95;
            int expectedDeffenderHP = 66;
            bool expectedIsAlive = true;

            //Ejecucion
            ICharacter elf1 = new Elves("Ragnar", new Weapons("Elf Hammer"), new Armors("Iron Helmet"));
            ICharacter elf2 = new Elves("Messi", new Weapons("Elf Hammer"), new Armors("Iron Helmet"));
            AttackInitiator.Attack(elf2, elf1);


            //Comprobacion
            Assert.AreEqual(expectedWeaponDurability, elf1.Weapon.Durability);
            Assert.AreEqual(expectedDeffenderHP, elf2.GetHP());
            Assert.AreEqual(expectedArmorDurability, elf2.Armor.Durability);
            Assert.AreEqual(expectedIsAlive, elf2.IsAlive());
        }

        [Test]
        public void CorrectDeathTest()
        {
            //Creacion
            const int expectedWeaponDurability = 100 - 5 * 6;
            Weapons expectedWeapon= null;
            Armors expectedArmor= null;
            const int expectedCoins= 500;
            bool expectedIsAlive = false;

            //Ejecucion
            ICharacter elf1 = new Elves("Ragnar", new Weapons("Elf Hammer"), new Armors("Iron Helmet"));
            ICharacter elf2 = new Elves("Messi", new Weapons("Elf Hammer"), new Armors("Merlin Cape"));
            for (int ctr = 0; ctr <= 5; ctr++)
            {
                AttackInitiator.Attack(elf2, elf1);
            }

            //Comprobacion
            Assert.AreEqual(expectedWeaponDurability, elf1.Weapon.Durability);
            Assert.AreEqual(expectedArmor, elf2.Armor);
            Assert.AreEqual(expectedWeapon, elf2.Weapon);
            Assert.AreEqual(expectedCoins, elf2.GetCoins());
            Assert.AreEqual(expectedIsAlive, elf2.IsAlive());
        }
    }
}