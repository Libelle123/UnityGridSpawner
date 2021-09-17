using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    public int NumberOfRows { get; private set; }
    public int NumberOfColumns { get; private set; }
    public Vector2Int GridDimensions { get { return new Vector2Int(NumberOfColumns, NumberOfRows); }}

    private Dictionary<Vector2Int, GameObject> gridContent;

    public Grid(int numberOfRows = 0, int numberOfColums = 0)
    {
        NumberOfRows = (numberOfRows > 0 ? numberOfRows : 0);
        NumberOfColumns = (numberOfColums > 0 ? numberOfColums : 0);

        int capacity = NumberOfRows * NumberOfColumns;
        gridContent = new Dictionary<Vector2Int, GameObject>(capacity);

        for (int i = 0; i < NumberOfColumns; i++)
        {
            for (int j = 0; j < NumberOfRows; j++)
            {
                gridContent.Add(new Vector2Int(i, j), null);
            }
        }
    }

    public GameObject GetValueFromTileIndex (Vector2Int tileIndex)
    {
        if (!gridContent.ContainsKey(tileIndex)) { return null; }
        
        return gridContent[tileIndex];
    }

    public void AddValueToTile(Vector2Int tileIndex, GameObject gameObject)
    {
        if (!gridContent.ContainsKey(tileIndex)) { return; }

        gridContent[tileIndex] = gameObject;
    }

    public void ClearTile(Vector2Int tileIndex)
    {
        if (!gridContent.ContainsKey(tileIndex)) { return; }

        gridContent[tileIndex] = null;
    }
}

//  Visualisation of tile indices in imaginary grid
//  | 0,1 | 0,2 |
//  | 0,0 | 1,0 |
