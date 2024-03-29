using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Movement : MonoBehaviour
{
    public float moveSpeed = 5f; // Adjust this to change the speed of movement
    public float jumpForce = 10f; // Adjust this to change the force of the jump

    public Canvas EndCanvas;
    public Canvas CaughtCanvas;

    void Update()
    {
        // Get input from arrow keys
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Calculate movement direction based on input
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Move the object based on input
        transform.Translate(movementDirection * moveSpeed * Time.deltaTime);


        // Check for jump input and if the object is grounded
        if (Input.GetButtonDown("Jump"))
        {
            // Apply jump force
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    void OnDrawGizmosSelected()
    {
        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
    }

    public void Busted()
    {
        CaughtCanvas.enabled = true;
        Invoke(nameof(RestartGame), 5f);
    }

    public void EndGame()
    {
        EndCanvas.enabled = true;
        Invoke(nameof(RestartGame), 5f);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
