using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    public int Color; // Integer representing the color of the checkpoint (1 for "GOT IN", 0 for "BUSTED")
    public Movement Movement_Reference; // Reference to the Movement script attached to the player

    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player"))
        {
            switch(Color)
            {
                case 0:
                    Debug.Log("BUSTED");
                    Movement_Reference.moveSpeed = 0; // Set player's movement speed to 0
                    Movement_Reference.Busted(); // UI for Caught
                    break;
                case 1:
                    Debug.Log("GOT IN");
                    Destroy(this.gameObject); // Destroy the green wall
                    Movement_Reference.moveSpeed += 5;
                    break;
                case 2:
                    Debug.Log("GameOver");
                    Movement_Reference.EndGame(); // UI for Win
                    break;
            }
                
        }

        // Other Options to implement
        // if(collider.CompareTag("Player") && Color.Equals(1))
        // {
        //     Debug.Log("GOT IN");
        //     Destroy(this.gameObject);
        //     Movement_Reference.moveSpeed += 2; // Increase player's movement speed by 2 units
        // }

        // if(collider.tag.Equals("Player") && Color.Equals(0))
        // {
        //     Debug.Log("BUSTED");
        //     Movement_Reference.moveSpeed = 0; // Set player's movement speed to 0
        // }

        
    }

}
