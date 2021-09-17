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
       Vector2 tileIndex = GetTileIndexInGrid(grid.GetGridData(), collider, mousePosInWU);

        Debug.Log("Tile index: " + tileIndex);
    }

    Vector2 GetTileIndexInGrid(GridData gridData, BoxCollider2D collider, Vector2 mousePosition)
    {
        Vector2 bottomLeftCorner = collider.bounds.min;
        Vector2 relativeMousePos = mousePosition - (Vector2)bottomLeftCorner;
        Vector2 colliderDimensions = collider.bounds.size;

        Vector2 normalisedMousePos = relativeMousePos / colliderDimensions;

        Vector2 gridDimensions = new Vector2(gridData.NumberOfColumns, gridData.NumberOfRows);

        Vector2 tileIndex = normalisedMousePos * gridDimensions;
        tileIndex.x = Mathf.Floor(tileIndex.x);
        tileIndex.y = Mathf.Floor(tileIndex.y);

        return tileIndex;


    }
}
