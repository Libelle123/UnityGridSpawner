using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    public int NumberOfRows { get; private set; }
    public int NumberOfColumns { get; private set; }
    public Vector2Int GridDimensions { get { return new Vector2Int(NumberOfColumns, NumberOfRows); }}


    public Grid(int numberOfRows = 0, int numberOfColums = 0)
    {
        NumberOfRows = (numberOfRows > 0 ? numberOfRows : 0);
        NumberOfColumns = (numberOfColums > 0 ? numberOfColums : 0);
    }

}

//  Visualisation of tile indices in imaginary grid
//  | 0,1 | 0,2 |
//  | 0,0 | 1,0 |
