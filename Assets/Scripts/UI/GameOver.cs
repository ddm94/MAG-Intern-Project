using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    #region Variables
    public GameObject screenParent;
    public GameObject replayButton;
    public GameObject nextLevelButton;

    public AnimationClip gameOverAnimation;

    public Text gameOverText;
    public Text scoreText;

    public float waitToSpawn = 1;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        screenParent.SetActive(false);
    }

    #region Win/Lose Screen
    public IEnumerator ShowGameOver(int score)
    {
        yield return new WaitForSeconds(waitToSpawn);

        screenParent.SetActive(true);

        scoreText.text = score.ToString();

        replayButton.SetActive(true);
        nextLevelButton.SetActive(false);

        Animator animator = GetComponent<Animator>();

        if (animator)
        {
            animator.Play(gameOverAnimation.name);
        }
    }

    public IEnumerator ShowGameWin(int score)
    {
        yield return new WaitForSeconds(waitToSpawn);

        screenParent.SetActive(true);

        scoreText.text = score.ToString();

        nextLevelButton.SetActive(true);
        replayButton.SetActive(false);

        string win = "YOU WIN!";
        gameOverText.text = win.ToUpper();

        Animator animator = GetComponent<Animator>();

        if (animator)
        {
            animator.Play(gameOverAnimation.name);
        }
    }
    #endregion

    #region UI Button Events
    public void OnReplayClicked()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void OnNextLevelClicked()
    {
        // A quick and dirty way to check that the current scene is the last scene available in the buildIndex.
        // If it is, we replay the current scene.
        // Please forgive me ):
        if (SceneManager.GetActiveScene().buildIndex == 2)
            OnReplayClicked();
        else
            // Get the next scene 
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Main Menu");
    }
    #endregion
}
