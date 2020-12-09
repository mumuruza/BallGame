using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour
{
    [SerializeField]
    private float distance;
    [SerializeField]
    private Transform startPoint;
    [SerializeField]
    private LayerMask layerMask;

    public bool IsGrounded() 
    {
        return Physics2D.Raycast(startPoint.position, Vector2.down, distance, layerMask.value);
    }    
    
}
