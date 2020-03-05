using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private AimingReticule reticule;
    [SerializeField] private float speed = 5f;
    private Vector2 targetdirectionX;
    private Vector2 targetdirectionY;
    private Rigidbody2D rb2;

    // Start is called before the first frame update
    void Start()
    {
        rb2 = GetComponent<Rigidbody2D>();
        rb2.drag = 0;
        rb2.mass = 0.01f;
        Vector2 reticuleposition = reticule.GetCursorPositionInWorld();
        Vector2 gov2 = transform.position;
        //transform.rotation = Quaternion.LookRotation(reticuleposition);
        rb2.velocity = (reticuleposition - gov2 ).normalized * speed;
        
        float angle = Mathf.Atan2(reticuleposition.y, reticuleposition.x) * Mathf.Rad2Deg; 
        transform.rotation = Quaternion.Euler(0, 0, angle);     
        Debug.Log(transform.rotation);  
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
