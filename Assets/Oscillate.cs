using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillate : MonoBehaviour
{
    public Transform a, b;
    [Range(0, 1)]
    public float speed = 1;

    void Start()
    {

    }

    void Update()
    {
        float pingPong = Mathf.PingPong(Time.time * speed, 1);
        transform.position = Vector3.Lerp(a.position, b.position, pingPong);
    }
}
