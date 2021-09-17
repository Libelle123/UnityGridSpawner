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
        Vector2 spawnPos = gridHandler.GetTilePositionInWorldSpace(mousePosInWU);

        Instantiate(objectToBeSpawned, spawnPos, Quaternion.identity);
    }
}
