using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class CollisionDetector : MonoBehaviour
{
    public event Action<Collision2D> CollisionDetected;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        CollisionDetected?.Invoke(collision);
    }
}
