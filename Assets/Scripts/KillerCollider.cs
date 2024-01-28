using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillerCollider : MonoBehaviour
{
    public Player player;
    public Transform transform1;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        player.transform.position = transform1.position;
    }
}
