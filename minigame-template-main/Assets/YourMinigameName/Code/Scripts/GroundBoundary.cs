using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundBoundary : MonoBehaviour
{
    // Reference to the BoxCollider component
    private BoxCollider gameBoundaryCollider;

    private void Start()
    {
        // Get the BoxCollider component attached to the game boundary object
        gameBoundaryCollider = GetComponent<BoxCollider>();
    }

    private void Update()
    {
        // Calculate the bounds of the player's collider
        Bounds playerBounds = GetComponent<Collider>().bounds;

        // Check if the player's bounds are intersecting with the game boundary collider
        if (!IntersectsBoxCollider(playerBounds, gameBoundaryCollider))
        {
            // Calculate the direction to move the player back inside the boundary
            Vector3 moveDirection = gameBoundaryCollider.ClosestPoint(playerBounds.center) - playerBounds.center;
            moveDirection.y = 0f; // Ignore vertical movement

            // Normalize the move direction and adjust movement speed if needed
            moveDirection.Normalize();
            moveDirection *= 0.1f; // Adjust the movement speed as desired

            // Apply the movement to the player's position
            transform.position += moveDirection;
        }
    }

    private bool IntersectsBoxCollider(Bounds bounds, BoxCollider boxCollider)
    {
        // Create a temporary GameObject with a BoxCollider and set its bounds
        GameObject tempObject = new GameObject();
        BoxCollider tempCollider = tempObject.AddComponent<BoxCollider>();
        tempCollider.center = bounds.center;
        tempCollider.size = bounds.size;

        // Check for collision between the temporary collider and the game boundary collider
        bool intersects = Physics.CheckBox(bounds.center, bounds.extents, Quaternion.identity, boxCollider.gameObject.layer);

        // Destroy the temporary GameObject
        Destroy(tempObject);

        return intersects;
    }

}


