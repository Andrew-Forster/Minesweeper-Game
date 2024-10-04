using MinesweeperLibrary;

int choice = -1;  // Variable to store the user's choice for difficulty level
int action = -1;  // Variable to store the user's choice for action
Board board;      // Declare a 'Board' object that will be initialized later based on the user's choice

// Game Difficulty Selection Loop - Allows the user to choose the difficulty level or exit the game
while (choice != 0)
{
    // Display the difficulty selection options to the user
    Console.WriteLine("Choose Your Difficulty: ");
    Console.WriteLine("1. Easy");
    Console.WriteLine("2. Medium");
    Console.WriteLine("3. Hard");
    Console.WriteLine("4. To Exit");

    choice = Utils.GetUserInput("Enter your choice: ");

    if (choice == 4)
    {
        // Exit the game if the user chooses 0
        Console.WriteLine("Exiting the game...");
        break;
    }

    if (choice < 0 || choice > 3)
    {
        // If the choice is not within the valid range, print an error message
        Console.WriteLine("Invalid choice. Please select a valid option.");
        continue;
    }

    // Initialize the game board based on the chosen difficulty level (1, 2, or 3)
    board = new Board(choice);

    // Display the board to the user (assuming the 'GetBoard' method returns a string representation of the board)
    Console.WriteLine(board.GetBoard());

    // Initialize variables for row and column selections
    int row = -1;
    int col = -1;

    // Main Game Loop - Allows the user to interact with the game board
    while (board.CheckGameState() == "Continue")
    {
        string reward = "";
        action = Utils.GetUserInput("You may:    \n" +
            "1. Reveal a cell [ ]\n" +
            "2. Flag a cell X\n" +
            "3. Use a powerup ^ \n" +
            "4. Return ->\n" +
            "Enter your choice: ");

        if (action == 4)
        {
            break;
        }

        if (action == 3)
        {
            if (board.RewardsInventory.Count == 0)
            {
                Console.WriteLine("You have no rewards to use");
                continue;
            }
            reward = Utils.PickReward(board.RewardsInventory);
        }




        // Ask the user for the column they would like to select
        col = Utils.GetUserInput("Enter the column you would like to select: ");

        // Ask the user for the row they would like to select
        row = Utils.GetUserInput("Enter the row you would like to select: ");

        // Check if the row and column are within the valid range
        if (col > 0 && col <= board.BoardSize && row > 0 && row <= board.BoardSize)
        {
            // Valid row and column have been selected, break out of the input loop
            Console.WriteLine($"You selected row {col} and column {row}.");
            //This is if the user useses the reward that is named "Detector"
            if (reward == "Detector")
            {
                Console.WriteLine(board.UseDetector(row, col) ? "BOMB DETECTED!!!" : "No bomb detected");
            }

            if (action == 2)
            {
                board.Flag(row, col);
            }
            else if (action == 1)
            {
                board.Reveal(row, col);
            }
        }
        else
        {
            // If the row or column is outside the valid range, print an error message
            Console.WriteLine("Invalid row or column, please select values within the board range of: " + board.BoardSize);
        }

        // Display the updated board to the user
        Console.WriteLine(board.GetBoard());
        // If bomb is hit it will display this message
        switch (board.CheckGameState())
        {
            case "Won":
                Console.WriteLine("Congratulations! You have won the game! ");
                break;
            case "Lost":
                Console.WriteLine("Game Over! You hit a bomb! ):");
                break;
            default:
                break;
        }

    }


}