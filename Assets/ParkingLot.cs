using UnityEngine;

public class ParkingLot : MonoBehaviour
{
    public Rigidbody2D targetRigidbody; // Reference to the specific Rigidbody2D to detect

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider's Rigidbody2D is the target Rigidbody2D
        if (other.attachedRigidbody == targetRigidbody)
        {
            Debug.Log("Target Rigidbody entered the trigger area.");
            // Handle entry logic here, like starting an event or updating status
        }
    }
}
