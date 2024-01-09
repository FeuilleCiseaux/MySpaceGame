using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameBorders : MonoBehaviour
{
    private Renderer spriteRenderer;
    private Camera gameCamera;

    void Start()
    {
        gameCamera = Camera.main;
        spriteRenderer = GetComponent<Renderer>();
    }

    void Update()
    {
        WrapSprite();
    }

    void WrapSprite()
    {
        Vector3 spritePosition = transform.position;
        Vector3 viewportPosition = gameCamera.WorldToViewportPoint(spritePosition);

        if (IsOutsideViewport(viewportPosition))
        {
            // Wrap the sprite to the other side of the screen
            WrapToOppositeSide(viewportPosition);
        }
    }

    bool IsOutsideViewport(Vector3 viewportPosition)
    {
        return (viewportPosition.x < 0 || viewportPosition.x > 1 ||
                viewportPosition.y < 0 || viewportPosition.y > 1);
    }

    void WrapToOppositeSide(Vector3 viewportPosition)
    {
        // Determine which side the sprite exited from and set the new position on the opposite side
        float newX = (viewportPosition.x < 0) ? 1 : 0;
        float newY = (viewportPosition.y < 0) ? 1 : 0;

        // Convert the new viewport position back to world position
        Vector3 newWorldPosition = gameCamera.ViewportToWorldPoint(new Vector3(newX, newY, viewportPosition.z));

        // Set the new position for the sprite
        transform.position = newWorldPosition;
    }
}