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

public class ArrowCollision : MonoBehaviour
{
    public int score = 0; // Current score of the player

    // This function is called when the arrow enters the trigger collider of another object
    private void OnTriggerEnter(Collider other)
    {
        // Check if the arrow collides with an object tagged "Axe"
        if (other.CompareTag("Axe"))
        {
            // Add points to the score
            score += 10;

            // Optionally, destroy the axe upon collision
            Destroy(other.gameObject);

            // Print the updated score to the console
            Debug.Log("Score: " + score);
        }
    }
}

void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (currentArrow == null) // Ensure only one arrow exists at a time
            {
                SpawnArrowPrefab();
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

            private void OnCollisionEnter(Collision collision)
            {
                // Check if the arrow collides with the floor
                if (collision.gameObject.CompareTag("Floor"))
                {
                    // Get the arrow's rigidbody
                    Rigidbody rb = GetComponent<Rigidbody>();

                    if (rb != null)
                    {
                        // Calculate the bounce direction (away from the floor's normal)
                        Vector3 bounceDirection = Vector3.Reflect(rb.velocity, collision.contacts[0].normal).normalized;

                        // Apply the bounce force
                        rb.velocity = bounceDirection * bounceForce;
                    }
                }
            }
        }



    }
    }

    void SpawnArrow()
    {
        // Instantiate the arrow at the position of this GameObject
        currentArrow = Instantiate(arrowPrefab, transform.position, Quaternion.identity);
        arrowDirection = Vector3.right; // Reset the direction to default
    }
}
