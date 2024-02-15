namespace game;
public class ScoreCard{
    //properties
    private string _playerName;
    private int[] _scores = new int[Constants.NumberOfHoles];

    //constructor
    public ScoreCard(string playerName){
        this._playerName = playerName;
        ResetScore(); //reset score card to 0
    }

    //constructor for recovering score card
    public ScoreCard(string playerName, int[] existingScores){
        this._playerName = playerName;
        this._scores = existingScores;
    }

    public void EnterScore(int holeNum, int score){
        // Adjust holeN to be 0-based
        int holeIndex = holeNum - 1;

        // Validate hole number and score together correctly
        if(holeIndex >= 0 && holeIndex <= 17 && score >= 1 && score <= 5){
            _scores[holeIndex] = score; 
        }
        else{
            Console.WriteLine("Invalid score or hole number.");
        }
    }

    public void SetTestScore(){
        this._SetTestScore = SetTestScore();
    } 


    public int TotalScore(){
        return _scores.Sum();
    }
    public void ResetScore(){
        // Method to reset scores for a new game
        for (int i = 0; i < _scores.Length; i++){
            _scores[i] = 0;
        }
    }

    public int GetScore(int holeNum){
        // Adjust holeN to be 0-based
        int holeIndex = holeNum - 1;
        if(holeIndex >= 0 && holeIndex <= 17){
            return _scores[holeIndex];
        }
        else{
            Console.WriteLine("Invalid hole number.");
            return -1;
        }
    }
    
    public string PlayerName{
        get {return _playerName;}
        set {_playerName = value;}
    }
}
