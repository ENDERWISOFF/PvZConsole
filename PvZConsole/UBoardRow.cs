using System;
using System.Collections.Generic;
using UBoardNode;
using UPea;
using UPlant;
using UZombie;

namespace UBoardRow
{
    public class TBoardRow
    {
        private List<TBoardNode> FNodes;

        public int BOARD_COLS = 9;
        public TBoardRow()
        {
            FNodes = new List<TBoardNode>();
            for (int i = 0; i < BOARD_COLS; i++)
                FNodes.Add(new TBoardNode());
        }

        public void moveZombie()
        {
            for (int i = 0; i < BOARD_COLS - 1; i++)
            {
                TBoardNode current = FNodes[i];
                TBoardNode next = FNodes[i + 1];
                if (current.hasZombie() && current.hasPlant())
                    continue;
                if (next.hasZombie() && !current.hasZombie() && !next.hasPlant())
                    current.addZombie(next.destroyZombie());
            }
        }

        public void movePea()
        {
            TBoardNode current = FNodes[BOARD_COLS - 1];
            if (current.hasPea()) current.removePea();
            for (int i = BOARD_COLS - 2; i >= 0; i--)
            {
                current = FNodes[i];
                TBoardNode next = FNodes[i + 1];
                if (current.hasPea() && !next.hasZombie()) next.addPea(current.removePea());
            }
        }

        public void GeneratePea()
        {
            for (int i = 0; i < BOARD_COLS; i++)
            {
                TBoardNode current = FNodes[i];
                if (current.hasPlant() && !current.hasPea())
                    if (current.getPlant().isShoot()) current.addPea(new TPea("Pea", 0, 10));
            }
        }

        public void addZombie(int index, TZombie newZombie)
        {
            if (newZombie != null)
                FNodes[index].addZombie(newZombie);
        }

        public void addPlant(int index, TPlant newPlant)
        {
            if (newPlant != null)
                FNodes[index].addPlant(newPlant);
        }

        public void addPea(int index, TPea newPea)
        {
            if (newPea != null)
                FNodes[index].addPea(newPea);
        }

        public bool hasZombie(int index)
        {
            if (index >= 0)
                return FNodes[index].hasZombie();
            else
                return false;
        }

        public bool hasPlant(int index)
        {
            if (index >= 0)
                return FNodes[index].hasPlant();
            else
                return false;
        }

        public bool hasPea(int index)
        {
            if (index >= 0)
                return FNodes[index].hasPea();
            else
                return false;
        }

        public int fightPvsZ(int score)
        {
            for (int i = 0; i < BOARD_COLS; i++)
            {
                TBoardNode CurrentNode = FNodes[i];
                if (CurrentNode.hasPlant() && CurrentNode.hasZombie())
                    score += CurrentNode.plantFightZombie();
            }
            return score;
        }

        public int HittingZbyP(int score)
        {
            for (int i = 0; i < BOARD_COLS; i++)
            {
                TBoardNode CurrentNode = FNodes[i];
                if (CurrentNode.hasPea() && CurrentNode.hasZombie())
                    score += CurrentNode.hitZombiePea();
            }
            return score;
        }

        public int generateMoney(int money)
        {
            foreach (TBoardNode bn in FNodes)
                if (bn.hasMoneyPlant())
                    if (new Random().Next(2) % 2 == 0)
                    {
                        money += bn.getMoneyPlant().getMoney();
                        return money;
                    }
            return money;
        }

        public List<TBoardNode> getRow()
        {
            if (FNodes != null)
                return FNodes;
            else
                return null;
        }
    }
}

