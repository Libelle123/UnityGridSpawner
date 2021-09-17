using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class GridHandler : MonoBehaviour
{
    [Header("Grid Data")]
    [SerializeField][MinAttribute(0)] int numberOfColumns;
    [SerializeField] [MinAttribute(0)] int numberOfRows;
    
    private Grid grid;

    new BoxCollider2D collider;

    private void Awake()
    {
        grid = new Grid(numberOfRows, numberOfColumns);
        collider = GetComponent<BoxCollider2D>();
    }
   
    public Vector2Int GetTileIndex(Vector2 mousePosition)
    {
        Vector2 bottomLeftCorner = collider.bounds.min;
        Vector2 topRightCorner = collider.bounds.max;
        Vector2 relativeMousePos = mousePosition - bottomLeftCorner;

        // Check if mouse within borders of collider
        if (relativeMousePos.x < 0f || relativeMousePos.x > topRightCorner.x ||
            relativeMousePos.y < 0f || relativeMousePos.y > topRightCorner.y)
        {
            return new Vector2Int(-1, -1);
        }

        Vector2 colliderDimensions = collider.bounds.size;
        Vector2 normalisedMousePos = relativeMousePos / colliderDimensions;

        Vector2 tileIndexFloat = normalisedMousePos * grid.GridDimensions;

        Vector2Int tileIndex = new Vector2Int
        (
            Mathf.FloorToInt(tileIndexFloat.x),
            Mathf.FloorToInt(tileIndexFloat.y)
        );

        return tileIndex;
    }
    public Vector3 GetTilePositionInWorldSpace(Vector2 mousePosition)
    {
        Vector2 gridScaleFactor = collider.size / grid.GridDimensions;

        Vector2Int tileIndex = GetTileIndex(mousePosition);
        Vector2 tileCentreOffset = 0.5f * gridScaleFactor;
        Vector2 tilePosInGrid = tileIndex * gridScaleFactor;

        Vector2 bottomLeftCorner = collider.bounds.min;
        Vector2 tilePosInWorldSpace = bottomLeftCorner + tilePosInGrid + tileCentreOffset;

        return tilePosInWorldSpace;
    }
}