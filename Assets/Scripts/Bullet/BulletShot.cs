using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletShot : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground") || other.CompareTag("Enemy"))
        {
            Destroy(gameObject); // Destroy the bullet GameObject if it collides with an object tagged as "Ground"
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
        Debug.Log("Bullet destroyed");
    }
}
