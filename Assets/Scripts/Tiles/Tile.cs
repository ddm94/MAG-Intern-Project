using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    #region Variables
    public int score = 0;
    // NOTE: This no longer works since we are using the animator controller
    // to modify the tile's scale when it gets deleted.
    // Therefore, I have commented all the lines that refer to changing the scale of a tile.
    //[Tooltip("Change the scale of the tile the mouse is currently on.")]
    //[Range(1.1f, 1.5f)]
    //public float tileScaleMultiplier;

    private int x;
    private int y;

    //private Vector3 tileScale;
    //private Vector3 storeTileScale;

    private BoardManager.TileType tileType;

    private MovableTile movableTileComponent;
    private TileColor tileColorComponent;
    private ClearableTile clearableTileComponent;
    #endregion

    #region Getters & Setters
    public int X { get { return x; } set { if (IsMovable()) x = value; } }
    public int Y { get { return y; } set { if (IsMovable()) y = value; } }

    public BoardManager.TileType GetTileType { get { return tileType; } }

    public MovableTile GetMovableTileComponent { get { return movableTileComponent; } }

    public TileColor GetTileColorComponent { get { return tileColorComponent; } }

    public ClearableTile GetClearableTileComponent { get { return clearableTileComponent; } }

    #endregion

    private void Awake()
    {
        movableTileComponent = GetComponent<MovableTile>();
        tileColorComponent = GetComponent<TileColor>();
        clearableTileComponent = GetComponent<ClearableTile>();
    }

    private void Start()
    {
        //tileScale = transform.localScale;
        //storeTileScale = tileScale;
    }

    public void Init(int _x, int _y, BoardManager _boardManager, BoardManager.TileType _tileType)
    {
        x = _x;
        y = _y;
        BoardManager.Instance = _boardManager;
        tileType = _tileType;
    }

    #region Adjacent Tiles
    // Return the adjacent tiles to this tile
    public Tile Left => x > 0 ? BoardManager.Instance.GetTiles[x - 1, y] : null;
    public Tile Top => y > 0 ? BoardManager.Instance.GetTiles[x, y - 1] : null;
    public Tile Right => x < BoardManager.Instance.GetRows - 1 ? BoardManager.Instance.GetTiles[x + 1, y] : null;
    public Tile Bottom => y < BoardManager.Instance.GetColumns - 1 ? BoardManager.Instance.GetTiles[x, y + 1] : null;

    // We store the adjcent tiles in an array so that we can return them all at once.
    public Tile[] Neighbours => new[]
    {
        Left,
        Top,
        Right,
        Bottom,
    };

    /// <summary>
    /// A recursive method to get the all the adjacent tiles.
    /// </summary>
    /// <param name="exclude">A list to make sure that we never double check a tile that has already been checked before.</param>
    /// <returns>A list of all the connected tiles to this tile</returns>
    public List<Tile> GetConnectedTiles(List<Tile> exclude = null)
    {
        // Initially return itself
        List<Tile> result = new List<Tile>() { this };

        if (exclude == null)
        {
            // exclude = a new list that contains this tile.
            exclude = new List<Tile> { this };
        }
        else
        {
            exclude.Add(this);
        }

        foreach (Tile neighbour in Neighbours)
        {
            // Skip the neighbour
            // We use the keyword continue to break one iteration, if one of the below conditions occurs, and we continue with the next iteration in the loop.
            if (neighbour == null || exclude.Contains(neighbour) || neighbour.tileColorComponent.TileColors != tileColorComponent.TileColors) continue;

            // Recursive 
            result.AddRange(neighbour.GetConnectedTiles(exclude));
        }

        return result;
    }
    #endregion

    #region Mouse Events
    private void OnMouseEnter()
    {
        // Multiply the scale of the tile by tileScaleMultiplier
        //transform.localScale = tileScale * tileScaleMultiplier;
    }

    private void OnMouseExit()
    {
        // Restore the scale to its default value
        //transform.localScale = storeTileScale;
    }

    private void OnMouseDown()
    {
        // Do nothing if the game is over.
        if (LevelManager.Instance != null && LevelManager.Instance.GetGameOver || PauseMenu.pauseIsClicked)
            return;

        BoardManager.Instance.DeleteConnectedTiles(x, y);
    }
    #endregion

    // Returns true if it exists
    public bool IsMovable()
    {
        return movableTileComponent != null;
    }

    // Returns true if it exists
    public bool IsColored()
    {
        return tileColorComponent != null;
    }

    // Returns true if it exists
    public bool IsClearable()
    {
        return clearableTileComponent != null;
    }
}
