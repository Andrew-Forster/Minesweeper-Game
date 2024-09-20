using MinesweeperLibrary;

int choice = -1;
Board board;

while (choice != 0)
{
    Console.WriteLine("Choose Your difficulty: ");
    Console.WriteLine("1. Easy");
    Console.WriteLine("2. Medium");
    Console.WriteLine("3. HARD");
    Console.WriteLine("0. To Exit");
    Console.Write("Enter choice: ");
    try
    {
        choice = int.Parse(Console.ReadLine());
    }
    catch (Exception e)
    {
        Console.WriteLine("Invalid Input, Try again.");
        continue;
    }
    if (choice == 1 || choice == 2 || choice == 3)
    {
        board = new Board(choice);
        Console.WriteLine(board.DisplayBoard());
    } else if (choice == 0)
    {
        Console.WriteLine("Goodbye!");
    }
    else
    {
        Console.WriteLine("Not a choice ");
    }
}