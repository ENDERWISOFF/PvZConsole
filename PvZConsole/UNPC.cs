using System;

namespace UNPC
{
    public abstract class TNPC
    {
        private int FHealth;
        private string FName;
        private int FAttackPower;

        public TNPC(string name, int health)
        {
            FName = name;
            FHealth = health;
        }

        public TNPC(string name, int health, int attackPower)
        {
            FName = name;
            FHealth = health;
            FAttackPower = attackPower;
        }

        public bool isAlive()
        {
            return getHealth() > 0;
        }

        public int getHealth()
        {
            return FHealth;
        }

        public void setHealth(int health)
        {
            FHealth = health;
        }

        public int getAttackPower()
        {
            return FAttackPower;
        }

        public abstract void attack(TNPC npc);

        public string getName()
        {
            return FName;
        }
    }
}
