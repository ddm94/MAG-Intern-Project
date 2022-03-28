using System.Collections.Generic;
using UnityEngine;

public class TileColor : MonoBehaviour
{
    #region Variables
    public enum ColorType
    {
        RED,
        GREEN,
        BLUE,
        YELLOW,
        COUNT
    };

    [System.Serializable]
    public struct ColorSprite
    {
        public ColorType tileColor;
        public Sprite sprite;
    }

    public ColorSprite[] colorSprite;

    private ColorType tileColors;

    private SpriteRenderer tileImage;

    private Dictionary<ColorType, Sprite> colorSpriteDictionary;
    #endregion

    // Getters & Setters
    // NOTE: No need for a region since there are only a couple of accessor properties.
    public ColorType TileColors { get { return tileColors; } set { SetColor(value); } }

    public int GetNumColors { get { return colorSprite.Length; } }

    private void Awake()
    {
        tileImage = GetComponent<SpriteRenderer>();

        InitColorSpriteDictionary();
    }

    /// <summary>
    /// Map colors to sprites
    /// </summary>
    private void InitColorSpriteDictionary()
    {
        colorSpriteDictionary = new Dictionary<ColorType, Sprite>();

        // Loop through all the structs in our colorSprite array.
        for (int i = 0; i < colorSprite.Length; i++)
        {
            // Check that the dict does not already contain a key.
            if (!colorSpriteDictionary.ContainsKey(colorSprite[i].tileColor))
                // Add new key/value pair to our dict.
                colorSpriteDictionary.Add(colorSprite[i].tileColor, colorSprite[i].sprite);
        }
    }

    public void SetColor(ColorType newColor)
    {
        tileColors = newColor;

        if (colorSpriteDictionary.ContainsKey(newColor))
        {
            tileImage.sprite = colorSpriteDictionary[newColor];
            // Uncomment this to activate the color assign
            // NOTE: If you do, make sure to replace the sprites for each tile in the TilePrefab object.
            // Replace the sprites with the "White Tile" sprite; a white square.
            ChangeTileColor(newColor);
        }
    }

    /// <summary>
    /// Change the color of the sprite we have assigned in the inspector.
    /// </summary>
    /// <param name="tileColor">The color of the tile</param>
    public void ChangeTileColor(ColorType tileColor)
    {
        switch (tileColor)
        {
            case ColorType.RED:
                tileImage.color = Color.red;
                break;
            case ColorType.GREEN:
                tileImage.color = Color.green;
                break;
            case ColorType.BLUE:
                tileImage.color = Color.blue;
                break;
            case ColorType.YELLOW:
                tileImage.color = Color.yellow;
                break;
            default:
                break;
        }
    }
}
