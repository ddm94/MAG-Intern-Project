using UnityEngine;

public class LevelManager : MonoBehaviour
{
    #region Variables
    public UIManager HUD;

    public enum LevelType
    {
        TIMER,
        MOVES,
    };

    // Protected - It can be used within this class or a derived class
    protected LevelType levelType;

    protected int currentScore;

    private bool gameOver = false;
    #endregion

    #region Getters & Setters
    public static LevelManager Instance { get; set; }

    public LevelType GetLevelType { get { return levelType; } }

    public bool GetGameOver { get { return gameOver; } }
    #endregion

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        HUD.SetScore(currentScore);
    }

    public void GameWin()
    {
        //Debug.Log("You Win!");
        HUD.OnGameWin(currentScore);
        gameOver = true;
    }

    public void GameLose()
    {
        //Debug.Log("You Lose!");
        HUD.OnGameLose(currentScore);
        gameOver = true;
    }

    public virtual void OnPlayerMove()
    {
        // EMPTY 
    }

    public virtual void OnPieceCleared(Tile tile)
    {
        currentScore += tile.score;

        HUD.SetScore(currentScore);
    }
}
