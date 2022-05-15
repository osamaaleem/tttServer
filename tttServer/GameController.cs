using System;
using System.Collections.Generic;
using System.Text;

namespace tttServer
{
    class GameController
    {
        public GameController()
        {
            for(int i = 0; i < gameProgress.GetLength(0); i++)
            {
                for(int k = 0; k < gameProgress.GetLength(1);k++)
                {
                    gameProgress[i,k] = -1;
                    
                }
            }
        }
        //Use 2D Arrays to track player progress;
        private int[,] gameProgress = new int[3,3];
        public static string winner = "Nil";
        public void GameProgressKeep(string grid,string player)
        {
            string[] gridInd = grid.Split(",");
            int i = int.Parse(gridInd[0]);
            int j = int.Parse(gridInd[1]);
            gameProgress[i, j] = int.Parse(player);
            CheckWinner();
        }
        private void CheckWinner()
        {
            //Row 1
            if (gameProgress[0,0] == gameProgress[0,1] && gameProgress[0,2] == gameProgress[0,1] && gameProgress[0, 2] != -1)
            {
                int player = gameProgress[0, 0] + 1;
                winner = $"Player {player} WINS!";
            }
            //Row 2
            else if (gameProgress[1, 0] == gameProgress[1, 1] && gameProgress[1, 2] == gameProgress[1, 1] && gameProgress[1, 2] != -1)
            {
                int player = gameProgress[1, 0] + 1;
                winner = $"Player {player} WINS!";
            }
            //Row 3
            else if (gameProgress[2, 0] == gameProgress[2, 1] && gameProgress[2, 2] == gameProgress[2, 1] && gameProgress[2, 2] != -1)
            {
                int player = gameProgress[2, 0] + 1;
                winner = $"Player {player} WINS!";
            }
            //Col 1
            else if (gameProgress[0, 0] == gameProgress[1, 0] && gameProgress[2, 0] == gameProgress[1, 0] && gameProgress[2, 0] != -1)
            {
                int player = gameProgress[0, 0] + 1;
                winner = $"Player {player} WINS!";
            }
            //Col 2
            else if (gameProgress[0, 1] == gameProgress[1, 1] && gameProgress[2, 1] == gameProgress[1, 1] && gameProgress[2, 1] != -1)
            {
                int player = gameProgress[0, 1] + 1;
                winner = $"Player {player} WINS!";
            }
            //Col 3
            else if (gameProgress[0, 2] == gameProgress[1, 2] && gameProgress[2, 2] == gameProgress[1, 2] && gameProgress[2, 2] != -1)
            {
                int player = gameProgress[0, 2] + 1;
                winner = $"Player {player} WINS!";
            }
            //Dig 1
            else if (gameProgress[0, 0] == gameProgress[1, 1] && gameProgress[2, 2] == gameProgress[1, 1] && gameProgress[2, 2] != -1)
            {
                int player = gameProgress[0, 0] + 1;
                winner = $"Player {player} WINS!";
            }
            //Dig 2
            else if (gameProgress[0, 2] == gameProgress[1, 1] && gameProgress[2, 1] == gameProgress[1, 1] && gameProgress[2, 1] != -1)
            {
                int player = gameProgress[0, 2] + 1;
                winner = $"Player {player} WINS!";
            }
        }
    }
}
