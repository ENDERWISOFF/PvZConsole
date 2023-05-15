using System;
using UNPC;

namespace UZombie
{
    public class TZombie : TNPC
    {
        private int FScoreOnDeath;

        public TZombie(string name, int health) : base(name, health)
        {
        }

        public TZombie(string name, int health, int attackPower) : base(name, health, attackPower)
        {
        }

        public TZombie(string name, int health, int attackPower, int scoreOnDeath) : base(name, health, attackPower)
        {
            FScoreOnDeath = scoreOnDeath;
        }

        public int getPointsOnDeath()
        {
            return FScoreOnDeath;
        }

        public override void attack(TNPC npc)
        {
            if (npc != null && npc.getHealth() > 0)
                npc.setHealth(npc.getHealth() - getAttackPower());
        }
    }
}
