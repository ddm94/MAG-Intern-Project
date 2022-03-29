public class LevelMoves : LevelManager
{
    // Variables
    public int numMoves;
    public int targetScore;

    private int movesUsed = 0;

    // Start is called before the first frame update
    void Start()
    {
        levelType = LevelType.MOVES;

        // Set the HUD according to this level type
        HUD.SetLevelType(levelType);
        HUD.SetScore(currentScore);
        HUD.SetTarget(targetScore);
        HUD.SetRemaining(numMoves);

        //Debug.Log("Number of moves: " + numMoves + " TargetScore: " + targetScore); 
    }

    /// <summary>
    /// Called when the player makes a move. In our case, when a tile gets popped.
    /// </summary>
    public override void OnPlayerMove()
    {
        // We increment the number of moves.
        movesUsed++;

        //Debug.Log("Moves remaining: " + (numMoves - movesUsed));

        HUD.SetRemaining(numMoves - movesUsed);

        // If the number of moves available is 0
        if(numMoves - movesUsed == 0)
        {
            // If the current score is higher than the target score
            if (currentScore >= targetScore)
            {
                GameWin();
            }
            else
            {
               GameLose();
            }
        }
    }
}
