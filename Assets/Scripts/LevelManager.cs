using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    public enum LevelType
    {
        TIMER,
        MOVES,
    };

    protected LevelType levelType;

    public LevelType GetLevelType { get { return levelType; } }

    protected int currentScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void GameWin()
    {

    }

    public virtual void GameLose()
    {

    }

    public virtual void OnPieceCleared(Tile tile)
    {
        currentScore += tile.score;
        Debug.Log("Score: " + currentScore);
    }
}
