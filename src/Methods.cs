namespace test;

static public class Methods{

    public static void AddPlayer(ref int playerCount, ScoreCard[] scoreCards){
        bool isNameValid = false;
        while(!isNameValid){    
            try{
                if (playerCount < Constants.MaxPlayers){
                    Console.WriteLine("Enter player name(10characters max): ");
                    string? playerName = Console.ReadLine();
                    if (string.IsNullOrEmpty(playerName)){
                        Console.WriteLine("Player name cannot be null.");
                        return; // Exit the method if playerName is null.
                    }
                    if (playerName.Length > 10){
                        Console.WriteLine("Player name cannot be more than 10 characters.");
                        return; // Exit the method if playerName is more than 10 characters.
                    }
                    scoreCards[playerCount] = new ScoreCard(playerName);
                    playerCount++;
                    Console.WriteLine($"Player: {playerName} added");
                    isNameValid = true;
                }
                else{
                    Console.WriteLine("Max number of players reached");
                    break;
                }
            }
            catch (Exception ex){
                Console.WriteLine("Error adding player: " + ex.Message);
                break;
            }
        }
    }

    public static void StartGame(int playerCount, ScoreCard[] scoreCards){
        if (playerCount <= 0 || scoreCards == null){
            throw new ArgumentException("Invalid input");
        }

        for (int i = 0; i < playerCount; i++){
            scoreCards[i].ResetScore();
        }

        Console.WriteLine("Game Started, scores reset");
    }


    public static void EnterScores(ScoreCard[] scoreCards, int playerCount){
        try{
            for (int i = 0; i < Constants.NumberOfHoles; i++){
                Console.WriteLine($"Enter score for hole {i + 1}: ");
                for (int j = 0; j < playerCount; j++){
                    while (true){
                        Console.Write($"Player {j + 1} (score 1-5): ");
                        string? input = Console.ReadLine();
                        if (int.TryParse(input, out int score)){
                            // Validate score is within the expected range
                            if (score >= 1 && score <= 5){
                                scoreCards[j].EnterScore(i + 1, score);
                                break; // Break the loop on successful input
                            }
                            else{
                                Console.WriteLine("Invalid score. Please enter a score between 1 and 5.");
                            }
                        }
                        else{
                            Console.WriteLine("Invalid input. Please enter a valid integer.");
                        }
                    }
                }
            }
            Console.WriteLine("Scores entered successfully.");
        }
        catch (Exception ex){
            Console.WriteLine($"Error entering scores: {ex.Message}");
        }
    }

    public static void ScoreCardTests(){
        ScoreCardTests();
        Console.WriteLine("Test scores set.");
    }


    // this took me a while to figure out and is overly complicated.
    public static void DisplayScores(ScoreCard[] scoreCards, int playerCount)
    {
        // Constants for formatting
        const int playerNameWidth = 10;
        const int holeWidth = 3; // Adjusted for simplicity
        const int totalWidth = 5; // Adjusted for simplicity
        const int numberOfHoles = 18;

        string sepLine = "+----------+-----------------------------------------------------------------------+-------+";

        // Header
        Console.WriteLine(sepLine);
        Console.Write($"|{"Player",-playerNameWidth}|");
        for (int i = 1; i <= numberOfHoles; i++)
        {
            Console.Write($"{i,holeWidth}|");
        }
        Console.WriteLine($"{" Total ",totalWidth}|");
        Console.WriteLine(sepLine);

        // Manually calculating total scores and finding the winning player
        // This approach, while instructive for understanding array manipulation and data handling,
        // is O(n^2) and not the most efficient. Using .Min() and .Sum() would offer an optimized O(n) solution.
        int lowestTotalScore = Contrants.NumberOfHoles * Constrants.MaxScorePerHole;
        int winningIndex = -1;
        for (int i = 0; i < playerCount; i++)
        {
            int totalScore = 0;
            for (int j = 0; j < Constants.NumberOfHoles; j++)
            {
                totalScore += scoreCards[i].GetScore(j + 1); // Sum scores manually
            }
            if (totalScore < lowestTotalScore)
            {
                lowestTotalScore = totalScore;
                winningIndex = i; // Update winner
            }
        }

        // Displaying scores
        for (int i = 0; i < playerCount; i++)
        {
            string scoreLine = $"|{scoreCards[i].PlayerName,-playerNameWidth}|";
            for (int hole = 1; hole <= numberOfHoles; hole++)
            {
                int holeScore = scoreCards[i].GetScore(hole);
                scoreLine += $"{holeScore,holeWidth}|";
            }
            int totalScore = 0;
            for (int j = 0; j < Constants.NumberOfHoles; j++)
            {
                totalScore += scoreCards[i].GetScore(j + 1);
            }
            scoreLine += $"{totalScore,totalWidth}|";
            Console.WriteLine(winningIndex);
            // Append "*Winner*" tag next to the player with the lowest total score
            if (i == winningIndex)
            {
                scoreLine += " *Winner*";
            }

            Console.WriteLine(scoreLine);
            Console.WriteLine(sepLine);
        }
    }


    public static void DisplayMenu(){
        Console.WriteLine("Menu");
        Console.WriteLine("1. Add Player");
        Console.WriteLine("2. Start Game");
        Console.WriteLine("3. Enter Scores");
        Console.WriteLine("4. Set Test Scores");
        Console.WriteLine("5. Display Scores");
        Console.WriteLine("6. Exit");
        Console.Write("Enter a number: ");
    }
}