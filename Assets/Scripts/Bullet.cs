using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int life = 3;

    private void Awake() {
        Destroy(gameObject, life);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(other.gameObject);
        Destroy(gameObject); 
    }
}
