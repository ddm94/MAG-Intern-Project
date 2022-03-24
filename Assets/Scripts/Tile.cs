using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tile : MonoBehaviour
{

    private int x;
    private int y;

    private BoardManager.TileType tileType;
    private BoardManager boardManager;

    #region Getters
    public int X { get { return x; } }
    public int Y { get { return y; } }
    public BoardManager.TileType TileType { get { return tileType; } }
    #endregion

    public enum TileColors {none, red, green, blue, yellow};
    public TileColors tileColor = TileColors.none;

    // Start is called before the first frame update
    void Start()
    {
        ChangeTileColorRandom();
    }

    public void Init(int _x, int _y, BoardManager _boardManager, BoardManager.TileType _tileType)
    {
        x = _x;
        y = _y;
        boardManager = _boardManager;
        tileType = _tileType;
    }

    void ChangeTileColorRandom()
    {
        // Get the values of the TileColors Enum
        Array tileColors = Enum.GetValues(typeof(TileColors));

        // Get a random number representing the colours
        int randColor = UnityEngine.Random.Range(1, tileColors.Length);

        TileColors randTileColor = (TileColors)tileColors.GetValue(randColor);

        // Apply that tileColor
        ChangeTileColor(randTileColor);
    }

    void ChangeTileColor(TileColors tileColor)
    {
        SpriteRenderer tileImage = GetComponent<SpriteRenderer>();

        switch (tileColor)
        {
            case TileColors.none:
                break;
            case TileColors.red:
                tileImage.color = Color.red;
                break;
            case TileColors.green:
                tileImage.color = Color.green;
                break;
            case TileColors.blue:
                tileImage.color = Color.blue;
                break;
            case TileColors.yellow:
                tileImage.color = Color.yellow;
                break;
            default:
                break;
        }
    }
}
