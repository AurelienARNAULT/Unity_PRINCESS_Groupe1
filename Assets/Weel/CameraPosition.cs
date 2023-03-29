using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine;

public class CameraPosition : MonoBehaviour
{
    public Vector3 startPosition;

    void Start()
    {
        transform.position = startPosition;
    }
}
