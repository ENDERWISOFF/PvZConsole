using System;
using UPea;
using UPlant;
using UZombie;
using UMoneyPlant;

namespace UBoardNode
{
    public class TBoardNode
    {
        private TPlant FPlant;
        private TZombie FZombie;
        private TPea FPea;

        public TBoardNode()
        {
            FPlant = null;
            FZombie = null;
            FPea = null;
        }

        public TZombie destroyZombie()
        {
            if (FZombie != null)
            {
                TZombie z = FZombie;
                FZombie = null;
                return z;
            }
            else
                return null;
        }

        public TPlant addPlant(TPlant plant)
        {
            if (FPlant == null)
            {
                FPlant = plant;
                return FPlant;
            }
            else
                return null;
        }

        public TPea addPea(TPea pea)
        {
            if (FPea == null)
            {
                FPea = pea;
                return FPea;
            }
            else
                return null;
        }

        public int plantFightZombie()
        {
            FPlant.attack(FZombie);

            if (FZombie.getHealth() <= 0)
            {
                int result = FZombie.getPointsOnDeath();
                FZombie = null;
                return result;
            }
            else
            {
                FZombie.attack(FPlant);
                if (FPlant.getHealth() <= 0)
                    FPlant = null;
                return 0;
            }
        }

        public TZombie plantFightZombie(TZombie zombie)
        {
            FPlant.attack(zombie);
            return zombie;
        }

        public int hitZombiePea()
        {
            FPea.attack(FZombie);
            if (FZombie.getHealth() <= 0)
            {
                int result = FZombie.getPointsOnDeath();
                FZombie = null;
                FPea = null;
                return result;
            }
            else
            {
                FPea = null;
                return 0;
            }
        }

        public void addZombie(TZombie zombie)
        {
            FZombie = zombie;
        }

        public bool hasZombie()
        {
            return FZombie != null;
        }

        public bool hasPlant()
        {
            return FPlant != null;
        }

        public bool hasPea()
        {
            return FPea != null;
        }

        public TPlant getPlant()
        {
            return FPlant;
        }

        public TMoneyPlant getMoneyPlant()
        {
            if (FPlant is TMoneyPlant)
                return (TMoneyPlant)FPlant;
            else
                return null;
        }

        public TPea getPea()
        {
            return FPea;
        }

        public TZombie getZombie()
        {
            return FZombie;
        }

        public bool hasMoneyPlant()
        {
            return FPlant is TMoneyPlant;
        }

        public TPlant removePlant()
        {
            TPlant p = FPlant;
            FPlant = null;
            return p;
        }

        public TPea removePea()
        {
            if (FPea != null)
            {
                TPea p = FPea;
                FPea = null;
                return p;
            }
            else
                return null;
        }
    }
}
