using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class MouseClickSpawner : MonoBehaviour
{
    [SerializeField] Grid grid = default;

    BoxCollider2D collider = default;
    new Camera camera = default;

    private void Start()
    {
        collider = GetComponent<BoxCollider2D>();
        camera = Camera.main;
    }

    private void OnMouseDown()
    {
        //  Visualisation of tile indices in imaginary grid
        //  | 0,1 | 0,2 |
        //  | 0,0 | 1,0 |

        Vector2 mousePosInWU = camera.ScreenToWorldPoint(Input.mousePosition);

        GridData gridData = grid.GetGridData();
        Vector2 gridDimensions = new Vector2(gridData.NumberOfColumns, gridData.NumberOfRows);

        Vector2 tileIndex = GetTileIndexInGrid(gridDimensions, collider, mousePosInWU);
        Vector2 spawnPos = GetTilePositionInWorldSpace(gridDimensions, collider, tileIndex);

        Debug.Log("Spawn pos: " + spawnPos);
    }

    Vector2 GetTileIndexInGrid(Vector2 gridDimensions, BoxCollider2D collider, Vector2 mousePosition)
    {
        Vector2 bottomLeftCorner = collider.bounds.min;
        Vector2 relativeMousePos = mousePosition - (Vector2)bottomLeftCorner;
        Vector2 colliderDimensions = collider.bounds.size;

        Vector2 normalisedMousePos = relativeMousePos / colliderDimensions;

        Vector2 tileIndex = normalisedMousePos * gridDimensions;
        tileIndex.x = Mathf.Floor(tileIndex.x);
        tileIndex.y = Mathf.Floor(tileIndex.y);

        return tileIndex;
    }

    Vector3 GetTilePositionInWorldSpace(Vector2 gridDimensions, BoxCollider2D collider, Vector2 tileIndex)
    {
        Vector2 gridScaleFactor = gridDimensions / collider.size;
        Vector2 tileCentreOffset = 0.5f * gridScaleFactor;
        Vector2 tilePosInGrid = tileIndex * gridScaleFactor;

        Vector2 bottomLeftCorner = collider.bounds.min;
        Vector2 tilePosInWorldSpace = bottomLeftCorner + tilePosInGrid + tileCentreOffset;

        return tilePosInWorldSpace;
    }
}
