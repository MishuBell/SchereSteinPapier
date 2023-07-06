
SchereSteinPapier schereSteinPapier = new SchereSteinPapier().PlayGame();

internal class SchereSteinPapier
{
    //TODO: Use a dictionary ... ): 

    private readonly static string[] choices = { "schere", "stein", "papier" };
    private readonly static string welcomePrompt = "Welcome to Schere, Stein, Papier! Enter your choice (: Type exit to quit\n";
    private readonly static string interPrompt = "Make a choice:";

    private static int userScore = 0;
    private static int npcScore = 0;

    private static readonly Random random = new();

    public SchereSteinPapier PlayGame()
    {
        Console.WriteLine(welcomePrompt);
        string? userChoice;

        do
        {
            DetermineWinner(userChoice = TakeUserChoice(interPrompt), GiveNPCchoice());

            Console.WriteLine($"[You: {userScore} NPC: {npcScore}]\n");
        } while (userChoice != "exit");
        return this;
    }

    /// <summary>
    /// Determines the winner of a rock-paper-scissors game between the user and the NPC. 
    /// </summary>
    /// <param name="user">The user's choice.</param>
    /// <param name="npc">The NPC's choice.</param>
    private static void DetermineWinner(string user, string npc)
    {
        var win = "^_^";
        var loss = ">:(";
        var draw = ":O";

        var userCapitalized = FirstToUpper(user);
        var npcCapitalized = FirstToUpper(npc);

        WinOrLoss(user, npc, win, loss, draw, userCapitalized, npcCapitalized);
    }

    /// <summary>
    /// Determines if the user wins or loses against the NPC and updates the scores accordingly.
    /// </summary>
    /// <param name="user">The user's choice.</param>
    /// <param name="npc">The NPC's choice.</param>
    /// <param name="win">The win message to display.</param>
    /// <param name="loss">The loss message to display.</param>
    /// <param name="draw">The draw message to display.</param>
    /// <param name="userCapitalized">The capitalized user's choice.</param>
    /// <param name="npcCapitalized">The capitalized NPC's choice.</param>
    private static void WinOrLoss(string user, string npc, string win, string loss, string draw, string userCapitalized, string npcCapitalized)
    {
        if (user == "schere")
        {
            switch (npc)
            {
                case "papier":
                    Console.WriteLine($"You win! {win!} {userCapitalized} beats {npcCapitalized}");
                    ++userScore;
                    Console.Beep();
                    break;
                case "stein":
                    Console.WriteLine($"You loose {loss!}  {npcCapitalized} beats {userCapitalized}");
                    ++npcScore;
                    break;
                default:
                    Console.WriteLine($"Draw {draw!}\n");
                    break;
            }
        }

        if (user == "stein")
        {
            switch (npc)
            {
                case "schere":
                    Console.WriteLine($"You win! {win!} {userCapitalized} beats {npcCapitalized}");
                    ++userScore;
                    Console.Beep();
                    break;
                case "papier":
                    Console.WriteLine($"You loose {loss!}  {npcCapitalized} beats {userCapitalized}");
                    ++npcScore;
                    break;
                default:
                    Console.WriteLine($"Draw {draw!}\n");
                    break;
            }
        }

        if (user == "papier")
        {
            switch (npc)
            {
                case "stein":
                    Console.WriteLine($"You win! {win!} {userCapitalized} beats {npcCapitalized}");
                    ++userScore;
                    Console.Beep();
                    break;
                case "schere":
                    Console.WriteLine($"You loose {loss!}  {npcCapitalized} beats {userCapitalized}");
                    ++npcScore;
                    break;
                default:
                    Console.WriteLine($"Draw {draw!}\n");
                    break;
            }
        }
    }

    /// <summary>
    /// Prompts the user for input and returns a valid choice from the game choices.
    /// </summary>
    /// <param name="prompt">The prompt displayed to the user before input is requested.</param>
    /// <returns>A string representing the user's valid choice</returns>
    private static string TakeUserChoice(string prompt)
    {
        Console.WriteLine(prompt);

        while (true)
        {
            var input = Console.ReadLine()?.Trim().ToLower();

            if (!string.IsNullOrEmpty(input) && choices.Contains(input))
            {
                return input;
            }
            Console.Clear();
            Console.WriteLine("Invalid input! ): Please enter a valid input UwU");
        }
    }

    private static string GiveNPCchoice()
    {
        return choices[random.Next(0, choices.Length)];
    }

    /// <summary>
    /// Capitalizes the first letter of a given string.
    /// </summary>
    /// <param name="input">The string to capitalize.</param>
    /// <returns>The capitalized string.</returns>
    private static string FirstToUpper(string input)
    {
        var firstChar = char.ToUpper(input[0]);
        var rest = input[1..];

        return firstChar + rest;
    }
}