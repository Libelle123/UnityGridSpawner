using UnityEngine;

public class Grid : MonoBehaviour
{
    [Header("Grid Data")]
    [SerializeField][Range(0, 1000)] int numberOfRows;
    [SerializeField][Range(0, 1000)] int numberOfColumns;

    GridData gridData;

    private void Awake()
    {
        gridData = new GridData(numberOfRows, numberOfColumns);
    }
   
    public GridData GetGridData()
    {
        return gridData;
    }
}

public struct GridData
{
    public readonly int NumberOfRows;
    public readonly int NumberOfColumns;

    public GridData(int numberOfRows = 0, int numberOfColums = 0)
    {
        NumberOfRows = (numberOfRows > 0 ? numberOfRows : 0);
        NumberOfColumns = (numberOfColums > 0 ? numberOfColums : 0);
    }
};