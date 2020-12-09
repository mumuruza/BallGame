using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
    [SerializeField]
    private float offset;
    public void Place(Transform i)
    {
        transform.SetParent(i);
        transform.localPosition = Vector3.up * offset;
    }
    
}
