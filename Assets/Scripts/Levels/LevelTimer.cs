using UnityEngine;

public class LevelTimer : LevelManager
{
    // Variables
    public int timeInSeconds;
    public int targetScore;

    private float timer = 0;

    private bool timeOut = false;

    // Start is called before the first frame update
    void Start()
    {
        levelType = LevelType.TIMER;

        // Set the HUD according to this level type
        HUD.SetLevelType(levelType);
        HUD.SetScore(currentScore);
        HUD.SetTarget(targetScore);
        // Time is displayed in minutes and seconds
        // Minutes = timeInSeconds / 60
        // Seconds = timeInSeconds % 60
        HUD.SetRemaining(string.Format("{0}:{1:00}", timeInSeconds/ 60, timeInSeconds % 60));

        //Debug.Log("Time: " + timeInSeconds + " second. Target Score: " + targetScore);
    }

    // Update is called once per frame
    void Update()
    {
        // Only decrease the timer if the game has not ended yet.
        if (!timeOut)
        {
            timer += Time.deltaTime;

            // Time remaining on display
            // Mathf.Max to get the larget value between time remaning and 0. If the time remainng is negative it will display 0.
            // Finally, since the function returns a float, we cast it to an integer.
            HUD.SetRemaining(string.Format("{0}:{1:00}", (int)Mathf.Max((timeInSeconds - timer) / 60, 0), (int)Mathf.Max((timeInSeconds - timer) % 60, 0)));

            // We ran out of time.
            if (timeInSeconds - timer <= 0)
            {
                if (currentScore >= targetScore)
                {
                    GameWin();
                }
                else
                {
                    GameLose();
                }

                timeOut = true;
            }
        }
    }
}
