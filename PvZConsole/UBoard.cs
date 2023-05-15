using System;
using System.Collections.Generic;
using UPea;
using UPlant;
using UZombie;
using UBoardRow;

namespace UBoard
{
    public class TBoard
    {
        private int FScore;
        private int FMoney;
        private int FZombiesToSpawn;
        private int FTotalZombies;
        private List<TBoardRow> FBoard;

        int BOARD_ROWS = 5;
        int BOARD_COLS = 9;
        public TBoard(int zombiesToSpawn, int score, int money)
        {
            Random rnd = new Random();
            FScore = score;
            FMoney = money;
            FZombiesToSpawn = zombiesToSpawn;
            FTotalZombies = zombiesToSpawn;
            FBoard = new List<TBoardRow>();

            for (int i = 0; i < BOARD_ROWS; i++)
                FBoard.Add(new TBoardRow());
        }

        public int[] GetZombieLocation()
        {
            int[] location = new int[FTotalZombies * 2];

            for (int i = 0; i < location.Length; i++)
                location[i] = -1;

            int y = 0;

            for (int i = 0; i < BOARD_ROWS; i++)
                for (int j = 0; j < BOARD_COLS; j++)
                    if (!FBoard[i].hasPlant(j) && FBoard[i].hasZombie(j))
                    {
                        location[y] = j;
                        location[y + 1] = i;
                        y += 2;
                    }

            return location;
        }

        public bool HasWon()
        {
            int[] arr = GetZombieLocation();
            return (FZombiesToSpawn == 0) && (arr[0] == -1);
        }

        public bool HasLost()
        {
            int[] arr = GetZombieLocation();
            int i = 0;
            while (i < arr.Length)
                if (arr[i] == 0) return true; else i += 2;
            return false;
        }

        public void FightPlantZombie()
        {
            foreach (TBoardRow br in FBoard)
                FScore = br.fightPvsZ(FScore);
        }

        public void HittingZombiePea()
        {
            foreach (TBoardRow br in FBoard)
                FScore = br.HittingZbyP(FScore);
        }

        public void IncrementMoney()
        {
            foreach (TBoardRow br in FBoard)
                FMoney = br.generateMoney(FMoney);
        }

        public void GeneratePeas()
        {
            foreach (TBoardRow br in FBoard)
                br.GeneratePea();
        }

        public void MoveZombies()
        {
            foreach (TBoardRow br in FBoard)
                br.moveZombie();
        }

        public void MovePeas()
        {
            foreach (TBoardRow br in FBoard)
                br.movePea();
        }

        public void RunBoard()
        {
            IncrementMoney();
            FightPlantZombie();
            HittingZombiePea();
            MovePeas();
            GeneratePeas();
            MoveZombies();
            GenerateZombieSpawn();
        }

        public void GenerateZombieSpawn()
        {
            Random rnd = new Random();

            if (FZombiesToSpawn > 0)
                if (rnd.Next(2) == 0)
                {
                    int randRow = rnd.Next(BOARD_ROWS);
                    if (!FBoard[randRow].hasZombie(BOARD_COLS - 1))
                    {
                        if (rnd.Next(2) == 0)
                            AddZombie(randRow, BOARD_COLS - 1, new TZombie("Zombie1", 100, 20, 10));
                        else
                            AddZombie(randRow, BOARD_COLS - 1, new TZombie("Zombie2", 200, 15, 20));
                        FZombiesToSpawn--;
                    }
                }
        }

        public TPlant AddPlant(int x, int y, TPlant plant)
        {
            if ((FMoney >= 50) && (x >= 0) && (x < BOARD_COLS) && (y >= 0) && (y < BOARD_COLS))
                if (plant != null)
                    if (!FBoard[x].hasPlant(y))
                    {
                        FBoard[x].addPlant(y, plant);
                        FMoney -= 50;
                        return plant;
                    }
            return null;
        }

        public TPea AddPea(int x, int y, TPea pea)
        {
            if ((x >= 0) && (x < BOARD_COLS) && (y >= 0) && (y < BOARD_COLS))
                if (pea != null)
                    if (!FBoard[x].hasPea(y))
                    {
                        FBoard[x].addPea(y, pea);
                        return pea;
                    }
            return null;
        }

        public bool AddZombie(int x, int y, TZombie zombie)
        {
            if ((zombie != null) && (x >= 0) && (x < 5) && (y == 8))
            {
                FBoard[x].addZombie(y, zombie);
                return true;
            }
            return false;
        }

        public int GetMoney()
        {
            return FMoney;
        }

        public void SetMoney(int money)
        {
            FMoney = money;
        }

        public List<TBoardRow> GetBoard()
        {
            return FBoard;
        }

        public int GetScore()
        {
            return FScore;
        }
    }
}


