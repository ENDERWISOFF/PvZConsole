using System;
using UNPC;
using UPlant;

namespace UMoneyPlant
{
    public class TMoneyPlant : TPlant
    {
        private int moneyToRise;

        public TMoneyPlant(string name, int health, int money) : base(name, health)
        {
            this.moneyToRise = money;
        }

        public override void attack(TNPC npc)
        {
            return;
        }

        public int getMoney()
        {
            return moneyToRise;
        }
    }
}
