using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCamera : MonoBehaviour
{
    private Vector3 camPos;
    [SerializeField] private Transform Player;


    void Update()
    {
        Vector3 vel = Vector3.zero;
        camPos = new Vector3(Player.transform.position.x, 0, -10);
        transform.position = camPos;

    }

}