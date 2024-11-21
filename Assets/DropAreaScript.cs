using UnityEngine;

public class DropAreaScript : MonoBehaviour
{
    GameObject person;
    Rigidbody2D ambulanceRb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Awake()
    {
    ambulanceRb = transform.parent.GetComponent<Rigidbody2D>();
    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (collision.gameObject.tag == "person" && collision.gameObject.transform.parent.tag != "Player" && ambulanceRb.linearVelocity.magnitude < 1f)
        {
            person = collision.gameObject;
            //sets person parent to ambulance
            person.transform.SetParent(transform.parent);
            person.transform.localPosition = Vector3.zero;
            person.GetComponent<SpriteRenderer>().enabled = false;

        }
    }
}
