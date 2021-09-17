using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class MouseClickSpawner : MonoBehaviour
{
    [SerializeField] GridHandler gridHandler = default;
    [SerializeField] GameObject objectToBeSpawned;

    new Camera camera = default;

    private void Start()
    {
        camera = Camera.main;
    }

    private void OnMouseDown()
    {
        Vector2 mousePosInWU = camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2Int tileIndex = gridHandler.GetTileIndex(mousePosInWU);

        GameObject gameObjectOnTile = gridHandler.GetValueFromTileIndex(tileIndex);

        if (gameObjectOnTile != null)
        {
            Destroy(gameObjectOnTile);
            gridHandler.ClearTile(tileIndex);
            return;
        }

        Vector2 spawnPos = gridHandler.GetTilePositionInWorldSpace(tileIndex);

        if (spawnPos != new Vector2(-1f, -1f))
        {
            GameObject gameObject = Instantiate(objectToBeSpawned, spawnPos, Quaternion.identity);
            gridHandler.AddValueToTile(tileIndex, gameObject);
        }
    }

    bool IsGridTileFree(Vector2Int tileIndex)
    {
        GameObject gameObject = gridHandler.GetValueFromTileIndex(tileIndex);
        return (gameObject == null);
    }
}
