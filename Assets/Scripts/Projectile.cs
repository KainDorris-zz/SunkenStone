using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    [SerializeField] private AimingReticule reticule;
    [SerializeField] private float speed;
    private Vector2 targetdirection;

    // Start is called before the first frame update
    void Start()
    {

        
    }

    // Update is called once per frame
    void Update()
    {
        targetdirection = reticule.GetCursorPositionInWorld();
        transform.position = Vector2.Lerp(transform.position, targetdirection, speed * Time.deltaTime);
        Destroy(gameObject, 3.0f);
        
    }
}
