using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    // Singleton Pattern
    public static BoardManager Instance { get; set; }

    [Header("Grid Size")]
    [SerializeField] private int rows = 9;
    [SerializeField] private int columns = 9;
    [Tooltip("The space between each cell that make up the grid." +
             " Default value is set to 1: This makes the grid look like a solid square with no spaces in between.")]
    [Range(1, 1.1f)]
    [SerializeField] private float spacing = 1f;

    [Header("Grid Object")]
    public GameObject cellPrefab; // This is the object used to construct the grid.
    public Transform grid; // Where the cellPrefab will be instantiated.

    #region Tile Object
    // This can be extended to have different types of tiles
    public enum TileType
    {
        DEFAULT, // Just your basic tile type.
        COUNT, // How many different tile types there are
    }

    [System.Serializable]
    public struct TilePrefab
    {
        public TileType type;
        public GameObject prefab;
    }
    #endregion

    [SerializeField] private TilePrefab[] tilePrefabs;

    private Dictionary<TileType, GameObject> tilePrefabDictionary;

    private Tile[,] tiles;

    private void Awake() => Instance = this;

    // Start is called before the first frame update
    void Start()
    {
        InitTileDictonary();
        CreateGrid();
        CreateTiles();
    }

    #region Board Creation
    /// <summary>
    /// Since our tilePrefabDictionary can not be displayed in the Unity inspector,
    /// we copy the values from our tilePrefab array into our dictionary object.
    /// </summary>
    private void InitTileDictonary()
    {
        tilePrefabDictionary = new Dictionary<TileType, GameObject>();

        // Loop through all prefabs in our array.
        for (int i = 0; i < tilePrefabs.Length; i++)
        {
            // Check that the dict does not already contain a key; a tile type.
            if (!tilePrefabDictionary.ContainsKey(tilePrefabs[i].type))
                // Add new key/value pair to our dict.
                tilePrefabDictionary.Add(tilePrefabs[i].type, tilePrefabs[i].prefab);
        }
    }

    void CreateGrid()
    {
        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < columns; y++)
            {
                GameObject cell = Instantiate(cellPrefab, GetWorldPosition(x, y) * spacing, Quaternion.identity);
                cell.transform.SetParent(grid);
            }
        }
    }

    void CreateTiles()
    {
        tiles = new Tile[rows, columns];

        for (int x = 0; x < rows; x++)
        {
            for (int y = 0; y < columns; y++)
            {
                GameObject newTile = Instantiate(tilePrefabDictionary[TileType.DEFAULT], GetWorldPosition(x, y) * spacing, Quaternion.identity);
                newTile.transform.SetParent(grid);

                // Give each tile a name so it is easier to tell which tile is which
                newTile.name = "Tile (" + x + "," + y + ")";

                // We are using a custom Tile class
                tiles[x, y] = newTile.GetComponent<Tile>();
                tiles[x, y].Init(x, y, this, TileType.DEFAULT);
            }
        }
    }

    /// <summary>
    /// Convert a grid coordinate to a world position
    /// </summary>
    Vector2 GetWorldPosition(int x, int y)
    {
        // Get the X and Y position of the grid obj, which is the center of the grid, 
        // and subtract half of the width and height, and add our x and y coordinate.
        // Since our world units are the same spacing as our grid units this gives us the world pos for 
        // our tile pieces. The grid will start at the top left corner.
        return new Vector2(grid.position.x - rows / 2.0f + x, grid.position.y + columns / 2.0f - y);
    }
    #endregion

    // Update is called once per frame
    void Update()
    {

    }
}
