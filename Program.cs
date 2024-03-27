namespace TicTacToe
{
  internal class Program
  {
    private static readonly char[,] playField =
    {
      { ' ', ' ', ' ' },
      { ' ', ' ', ' ' },
      { ' ', ' ', ' ' }
    };
    private static int totalMoves = 9;
    private static int playerTurn = 1;
    private static bool gameOver = false;

    public static void PlayerMove()
    {
      string selection;
      int row;
      int col;

      while (!Checker())
      {
        GameBoard();
        Console.WriteLine(
          $"Player {playerTurn}:Please Choose a field and enter a number from 1 to 9"
        );
        selection = Console.ReadLine();
        if (int.TryParse(selection, out int number) && (number >= 1) && (number <= 9))
        {
          row = (number - 1) / 3;
          col = (number - 1) % 3;
          if (playField[row, col] == ' ' && playerTurn == 1)
          {
            playField[row, col] = 'X';
            playerTurn++;
            totalMoves--;
          }
          else if (playField[row, col] == ' ' && playerTurn == 2)
          {
            playField[row, col] = 'O';
            playerTurn--;
            totalMoves--;
          }
          else
          {
            Console.WriteLine($"\nField {number} is already set. Please choose another field!");
          }
        }
        else
        {
          Console.WriteLine("Incorrect Input!");
        }
      }
    }

    public static void GameBoard()
    {
      Console.Clear();
      Console.WriteLine("   |   |   ");
      Console.WriteLine(" {0} | {1} | {2} ", playField[0, 0], playField[0, 1], playField[0, 2]);
      Console.WriteLine("   |   |   ");
      Console.WriteLine("---|---|---");
      Console.WriteLine("   |   |   ");
      Console.WriteLine(" {0} | {1} | {2} ", playField[1, 0], playField[1, 1], playField[1, 2]);
      Console.WriteLine("   |   |   ");
      Console.WriteLine("---|---|---");
      Console.WriteLine("   |   |   ");
      Console.WriteLine(" {0} | {1} | {2} ", playField[2, 0], playField[2, 1], playField[2, 2]);
      Console.WriteLine("   |   |   ");
    }

    public static bool Checker()
    {
      for (int i = 0; i < 3; i++)
      {
        if (
          playField[i, 0] != ' '
          && playField[i, 0] == playField[i, 1]
          && playField[i, 1] == playField[i, 2]
        )
        {
          gameOver = true;
          return true;
        }

        if (
          playField[0, i] != ' '
          && playField[0, i] == playField[1, i]
          && playField[1, i] == playField[2, i]
        )
        {
          gameOver = true;
          return true;
        }
      }

      if (
        playField[0, 0] != ' '
        && playField[0, 0] == playField[1, 1]
        && playField[1, 1] == playField[2, 2]
      )
      {
        gameOver = true;
        return true;
      }
      if (
        playField[0, 2] != ' '
        && playField[0, 2] == playField[1, 1]
        && playField[1, 1] == playField[2, 0]
      )
      {
        gameOver = true;
        return true;
      }

      if (totalMoves == 0)
      {
        gameOver = true;
        return true;
      }
      return false;
    }

    public static void Main(string[] args)
    {
      while (!gameOver)
      {
        PlayerMove();
      }
      GameBoard();
      Console.WriteLine("Game Over!");
      if (playerTurn % 2 == 0)
      {
        Console.WriteLine("Player 1 wins!");
      }
      else
        Console.WriteLine("Player 2 wins");
    }
  }
}
