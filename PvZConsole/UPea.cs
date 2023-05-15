using System;
using UNPC;

namespace UPea
{
    public class TPea : TNPC
    {
        public TPea(string name, int health, int attackPower) : base(name, 0, attackPower)
        {
        }

        public override void attack(TNPC npc)
        {
            if (npc != null && npc.getHealth() > 0)
                npc.setHealth(npc.getHealth() - getAttackPower());
        }
    }
}