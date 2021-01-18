using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeskCamFollow : MonoBehaviour
{
    public Transform target;
    public float smoothSpeed = 0.125f;

    void FixedUpdate()
    {
        transform.position = target.position;
    }

}
