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
        Vector2 pointDir =  Vector3.zero -player.transform.position;
        float angle = Mathf.Atan2(pointDir.y,pointDir.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;
    }
    
}
