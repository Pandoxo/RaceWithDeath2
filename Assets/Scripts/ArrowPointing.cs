using UnityEngine;

public class ArrowPointing : MonoBehaviour
{
    GameObject player;

    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        rb  = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 PositionCorrectionTerm = new Vector3(0f, -7.2f, 0f);
        // - new Vector3(0f, 7.2f, 0f) because we account for the fact that the arrow is int the upper section of the screen
        GameObject person = GameObject.FindGameObjectWithTag("person");

        // we don't have a person, so we don't have to point an aroow to it;
        if(person == null)
        {
          return;
        }

        Vector2 pointDir =  person.transform.position + PositionCorrectionTerm - player.transform.position;
        float angle = Mathf.Atan2(pointDir.y,pointDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }

}
