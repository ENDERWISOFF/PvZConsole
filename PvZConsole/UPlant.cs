using System;
using UNPC;

namespace UPlant
{
    public class TPlant : TNPC
    {
        private bool FShoot;

        public TPlant(string name, int health) : base(name, health)
        {
            FShoot = false;
        }

        public TPlant(string name, int health, int attackPower) : base(name, health, attackPower)
        {
        }

        public override void attack(TNPC npc)
        {
            if (npc != null && npc.getHealth() > 0)
                npc.setHealth(npc.getHealth() - getAttackPower());
        }

        public bool isShoot()
        {
            FShoot = !FShoot;
            return FShoot;
        }
    }
}
