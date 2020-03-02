using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingReticule : MonoBehaviour
{
    private Vector2 mousePosition;

    private void Start(){
        transform.position = Input.mousePosition;
        
    }

    private void Update(){
        UpdateReticulePosition();

    }

    private void UpdateReticulePosition(){
        transform.position = Input.mousePosition;
    }

    
}
