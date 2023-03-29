using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindMillRotation : MonoBehaviour
{
    public float Speed = 30f;
    
        private void Update()
        {
          transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z + Speed * Time.deltaTime);
        }
}
