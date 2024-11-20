using System.Collections;
using UnityEngine;

public class ParkingLot : MonoBehaviour
{
    public Rigidbody2D targetRigidbody; // Reference to the specific Rigidbody2D to detect
    public MainState mainState;
    private SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer

    // Define the custom color for the box
    public Color flashColor = new Color(1f, 1f, 0f, 0.32f); // Yellow (RGB: 1, 1, 0, Alpha: 1)
    public float flashTime = 1f;

    private void Awake()
    {
        // Get the SpriteRenderer component of the parking lot (assumes it's on the same GameObject)
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (spriteRenderer == null)
        {
            Debug.LogError("SpriteRenderer not found on the ParkingLot GameObject.");
        }
    }

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

                    // Change color for 3 seconds
                    StartCoroutine(FlashColor());
                }
            }
            // Handle entry logic here, like starting an event or updating status
        }
    }

    private IEnumerator FlashColor()
    {
        if (spriteRenderer != null)
        {
            // Save the original color
            Color originalColor = spriteRenderer.color;

            // Change to the custom color
            spriteRenderer.color = flashColor;

            // Wait for 3 seconds
            yield return new WaitForSeconds(flashTime);

            // Revert to the original color
            spriteRenderer.color = originalColor;
        }
    }
}

