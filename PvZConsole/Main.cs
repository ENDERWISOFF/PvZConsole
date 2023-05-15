using System;
using System.Threading;
using UBoard;
using UBoardRow;
using UBoardNode;
using UPlant;

namespace MainProgram
{
    public static class Program
    {
        
        public static void Main()
        {
            int BOARD_ROWS = 5;
            int BOARD_COLS = 9;

            // Create a model with 10 zombies, a score of 0 and 250 coins
            TBoard Board = new TBoard(10, 0, 300);

            // Create plants
            for (int RowIndex = 0; RowIndex < BOARD_ROWS; RowIndex++)
                Board.AddPlant(RowIndex, 0, new TPlant("Plant1", 200, 20));

            while (true)
            {
                // Main procedure for updating the model
                Board.RunBoard();
                Console.Clear();

                if (Board.HasWon() || Board.HasLost())
                {
                    if (Board.HasWon()) Console.WriteLine("You won!"); else Console.WriteLine("You lost!");
                    break;
                }

                // Get rows from the model
                var ABoard = Board.GetBoard();

                for (int RowIndex = 0; RowIndex < BOARD_ROWS; RowIndex++)
                {
                    // Get cells from the row
                    var ARow = ABoard[RowIndex].getRow();
                    string CellContent = "";
                    string PlantZombieHealth = "";

                    for (int ColIndex = 0; ColIndex < BOARD_COLS; ColIndex++)
                    {
                        // Check cell content
                        if (!(ARow[ColIndex].hasPlant() || ARow[ColIndex].hasZombie() || ARow[ColIndex].hasPea()))
                        {
                            CellContent += "_";
                            continue;
                        }
                        if (ARow[ColIndex].hasPea() && !ARow[ColIndex].hasPlant())
                        {
                            if (ARow[ColIndex].hasZombie()) CellContent += "*"; else CellContent += "-";
                            if (ARow[ColIndex].hasZombie()) PlantZombieHealth += " Z " + ARow[ColIndex].getZombie().getHealth();
                            continue;
                        }

                        if (ARow[ColIndex].hasPlant())
                        {
                            if (ARow[ColIndex].hasZombie()) CellContent += "F"; else CellContent += "P";
                            PlantZombieHealth += " P " + ARow[ColIndex].getPlant().getHealth();
                        }

                        if (ARow[ColIndex].hasZombie())
                        {
                            if (!ARow[ColIndex].hasPlant()) CellContent += "Z";
                            PlantZombieHealth += " Z " + ARow[ColIndex].getZombie().getHealth();
                        }
                    }

                    Console.WriteLine(CellContent + PlantZombieHealth);
                }

                Console.WriteLine("Money: " + Board.GetMoney() + " Score: " + Board.GetScore());
                Thread.Sleep(3000);
            }

            Console.ReadLine();
        }
    }
}
