using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    #region Variables
    public LevelManager levelManager;
    public GameOver gameOver;

    public Text remainingText;
    public Text remainingSubText;
    public Text targetText;
    public Text targetSubText;
    public Text scoreText;
    public Text scoreSubText;
    #endregion

    #region Set HUD
    public void SetScore(int score)
    {
        scoreText.text = score.ToString();
        scoreSubText.text = "Score: ";
    }

    public void SetTarget(int target)
    {
        targetText.text = target.ToString();
    }

    public void SetRemaining(int remaining)
    {
        remainingText.text = remaining.ToString();
    }

    public void SetRemaining(string remaining)
    {
        remainingText.text = remaining;
    }

    public void SetLevelType(LevelManager.LevelType type)
    {
        if (type == LevelManager.LevelType.MOVES)
        {
            remainingSubText.text = "Moves Remaining:";
            targetSubText.text = "Target Score:";
        }
        else if (type == LevelManager.LevelType.TIMER)
        {
            remainingSubText.text = "Time Remaining:";
            targetSubText.text = "Target Score:";
        }
    }
    #endregion

    public void OnGameWin(int score)
    {
        gameOver.StartCoroutine(gameOver.ShowGameWin(score));
    }

    public void OnGameLose(int score)
    {
        gameOver.StartCoroutine(gameOver.ShowGameOver(score));
    }
}
