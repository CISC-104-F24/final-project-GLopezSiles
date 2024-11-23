using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionAxes : MonoBehaviour
{
   

public class ArrowCollision : MonoBehaviour
    {
        public int score = 0; // Current score of the player

        // This function is called when the arrow enters the trigger collider of another object
        private void OnTriggerEnter(Collider other)
        {
            // Check if the arrow collides with an object tagged "AxeHead"
            if (other.CompareTag("AxeHead"))
            {
                score += 10;

           
               
                Debug.Log("Score: " + score);
            }
        }
    }



}

    // Update is called once per frame
  