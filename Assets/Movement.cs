
using Random = System.Random;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    // public float moveSpeed = 2f;
    public Renderer rend;

    //timers
    private float moveTime = 4.0f;
    private float timer = 0.0f;
    public static float moveSpeed;
    public float rotationSpeed = 100.0f;
    public Vector3 currentEulerAngles;
    public GameObject clone;
    public Rigidbody rb;

    // Start is called before the first frame update
    void Start() {

        randomOrder(PrimaryReactor.speed);
        moveSpeed = (float)PrimaryReactor.speed[0];
        float distanceFromViewer = PrimaryReactor.objectStartPosition.z - PrimaryReactor.viewerPosition.z;
        float collisionTime = distanceFromViewer / moveSpeed;
        PrimaryReactor.actualCollisionTime = collisionTime;
        clone = PrimaryReactor.currentClone;
        rb = GetComponent<Rigidbody>();
               
    }

// Update is called once per frame
void Update()
    {
        timer += Time.deltaTime;
        if (timer > moveTime)
        {
            rend = GetComponent<Renderer>();
            rend.enabled = false;
        }
        transform.Translate(-Vector3.forward * moveSpeed * Time.deltaTime, Space.World);
        transform.Rotate(-(25 * moveSpeed) * Time.deltaTime, 0, 0);
    }

    public void FixedUpdate ()
    {
        //rb.AddForce(-Vector3.forward * moveSpeed * Time.deltaTime, ForceMode.VelocityChange);
    }
    public void randomOrder(ArrayList arrList)
    {
        Random r = new Random();
        for (int cnt = 0; cnt < arrList.Count; cnt++)
        {
            object tmp = arrList[cnt];
            int idx = r.Next(arrList.Count - cnt) + cnt;
            arrList[cnt] = arrList[idx];
            arrList[idx] = tmp;
        }

    }
    

}
