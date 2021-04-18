using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateInPlace : MonoBehaviour
{
    public Transform transform;
    float smooth = 5.0f;
    float tiltAngle = 60.0f;
    int _rotationSpeed = 15;
    // Start is called before the first frame update
    void Start()
    {

    }



    void Update()
    {
        transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
    }
}
