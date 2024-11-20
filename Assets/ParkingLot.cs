using UnityEngine;

public class ParkingLot : MonoBehaviour
{
    public Rigidbody2D targetRigidbody; // Reference to the specific Rigidbody2D to detect
    public MainState mainState;

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the collider's Rigidbody2D is the target Rigidbody2D
        if (collider.tag == "ambulance" || collider.tag == "Player")
        {
            foreach (Transform child in collider.transform)
            {
                if (child.tag == "person")
                {
                    Debug.Log(child.gameObject);
                    mainState.PersonSaved(child.gameObject);
                    
                    //Do something
                }
            }
            // Handle entry logic here, like starting an event or updating status
        }
    }
}
