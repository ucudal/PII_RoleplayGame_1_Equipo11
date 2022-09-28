using NUnit.Framework;
using Inventory;
using Characters;
using NPC;
using Combat;

namespace Test.Library
{
    public class BlacksmithTest
    {
        [Test]
        public void weaponRepairTest()
        {
            //Construccion
            Weapons weapon = new Weapons("Rabadons Hat");
            ICharacter wizard = new Wizards("Kassadin", weapon, new Armors("Merlin Cape"), new MagicItems("Book of Spells"));
            ICharacter wizard2 = new Wizards("Zakarias", new Weapons("Rabadons Hat"), new Armors("Merlin Cape"), new MagicItems("Book of Spells"));
            wizard.Equip(weapon);

            //Ejecucion
            AttackInitiator.Attack(wizard,wizard2);
            BlackSmith.WeaponRepair(wizard,weapon);

            //Comprobacion
            Assert.AreEqual(100,wizard.Weapon.Durability);

        }
        
        [Test]
        public void armorRepairTest()
        {
            //Construccion
            Armors armor = new Armors("Merlin Cape");
            ICharacter wizard = new Wizards("Kassadin", new Weapons("Rabadons Hat"), armor, new MagicItems("Book of Spells"));
            ICharacter wizard2 = new Wizards("Zakarias", new Weapons("Rabadons Hat"), new Armors("Merlin Cape"), new MagicItems("Book of Spells"));
            int initialCoins= wizard.GetCoins();

            //Ejecucion
            wizard.Equip(armor);
            AttackInitiator.Attack(wizard2,wizard);
            BlackSmith.ArmorRepair(wizard,armor);

            //Comprobacion
            Assert.AreEqual(100,wizard.Armor.Durability);

        }
        [Test]
        public void weaponEnchanmentTest()
        {
            //Creacion
            const string initialName = "Viking Axe";
            const string expectedName = "Viking Axe";
            int expectedPower= 3*(ItemsStore.Weapons[initialName])/2;

            //Ejecucion
            Weapons weaponTest= new Weapons (initialName);
            ICharacter elf = new Elves ("Ragnar", weaponTest, new Armors("Merlin Cape"));
            BlackSmith.WeaponEnchantment(elf, weaponTest);

            //Comprobacion
            Assert.AreEqual(expectedName, weaponTest.Name);
            Assert.AreEqual(expectedPower, weaponTest.Power);


        }

        [Test]
        public void armorEnchanmentTest()
        {
            //Creacion
            const string initialName = "Merlin Cape";
            const string expectedName = "Merlin Cape";
            int expectedPower= 3*(ItemsStore.Armors[initialName])/2;

            //Ejecucion
            Armors armorTest= new Armors (initialName);
            ICharacter elf = new Elves ("Ragnar", new Weapons ("Elf Hammer"), armorTest);
            BlackSmith.ArmorEnchantment(elf, armorTest);

            //Comprobacion
            Assert.AreEqual(expectedName, armorTest.Name);
            Assert.AreEqual(expectedPower, armorTest.Power);

        }

    }
}