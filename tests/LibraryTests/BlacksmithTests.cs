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
            AttackInitiator.Attack(wizard2,wizard);
            BlackSmith.ArmorRepair(wizard,armor);

            //Comprobacion
            Assert.AreEqual(100,wizard.Armor.Durability);
            Assert.IsTrue(wizard.GetCoins()==initialCoins);

        }
        [Test]
        public void weaponEnchanmentTest()
        {
            //Construccion
            Weapons weapon = new Weapons("Rabadons Hat");
            int preEnchantmentPower= weapon.Power;
            ICharacter wizard = new Wizards("Kassadin", weapon, new Armors("Merlin Cape"), new MagicItems("Book of Spells"));
            int initialCoins=wizard.GetCoins();
            wizard.Equip(weapon);
            
            //Ejecucion
            BlackSmith.WeaponEnchantment(wizard,weapon);
            
            //Comprobacion
            Assert.IsTrue(weapon.Power==(preEnchantmentPower+((preEnchantmentPower*30)/100)));
            Assert.IsTrue(wizard.GetCoins()==initialCoins-ItemsStore.Prices[weapon.name]);


        }
    }
}