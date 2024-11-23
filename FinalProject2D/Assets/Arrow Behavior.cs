using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
public class ArrowController : MonoBehaviour
{
    public GameObject arrowPrefab; // Assign the arrow prefab in the inspector
    public float arrowSpeed = 10f;

    private GameObject currentArrow;
    private Vector3 arrowDirection = Vector3.right; // Default direction is right

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentArrow == null) // Ensure only one arrow exists at a time
            {
                SpawnArrow();
            }
        }

        // Adjust the arrow direction using Up, Left, and Down keys
        if (currentArrow != null)
        {
            if (Input.GetKey(KeyCode.UpArrow))
            {
                arrowDirection = Vector3.up;
            }
            else if (Input.GetKey(KeyCode.LeftArrow))
            {
                arrowDirection = Vector3.left;
            }
            else if (Input.GetKey(KeyCode.DownArrow))
            {
                arrowDirection = Vector3.down;
            }

            // Move the arrow in the current direction
            currentArrow.transform.position += arrowDirection * arrowSpeed * Time.deltaTime;
        }
    }

    void SpawnArrow()
    {
        // Instantiate the arrow at the position of this GameObject
        currentArrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
        arrowDirection = Vector3.right; // Reset the direction to default
    }
}
