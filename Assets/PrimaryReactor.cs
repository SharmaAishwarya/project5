//APPLY TO OBJECT IN SCENE -- IT WILL NOT BE RENDERED

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.PhysicsModule;
using System.IO;
using System;
using UnityEngine.UI;



public class PrimaryReactor : MonoBehaviour
{
    
       

    public PrimaryButtonWatcher watcher;	//empty game object with PrimaryButtonWatcher.cs script
    public bool IsPressed = false;

    public GameObject capsuleClone;	//add an object that will be cloned (don't use the object this script is applied to)
	//Movement.cs will be applied to ^^ this object
	public Transform startPosition;	//empty game object
    public Renderer rend;
    public TextMesh trialsLeft;

    public static bool acceptInput = true;

    // shared
    public static ArrayList speed = new ArrayList();
    public static GameObject currentClone;
    public static Vector3 viewerPosition;
    public static Transform viewerTransform;
    public static Vector3 objectStartPosition;
    public static float actualCollisionTime;
    

    void Start()
    {
        //set viewer position for actual collision time calculation d/s = t
        Camera maincam = GameObject.Find("Main Camera").GetComponent<Camera>();
        viewerTransform = maincam.transform;
        viewerPosition = maincam.transform.position;
        objectStartPosition = startPosition.position;
        //set speed array
        setSpeeds();

        trialsLeft.text = "Trials Remaining: " + speed.Count;

        watcher.primaryButtonPress.AddListener(onPrimaryButtonEvent);
        rend = GetComponent<Renderer>();
        rend.enabled = false;   //don't show the main capsule object

    }

    public void onPrimaryButtonEvent(bool pressed)
    {
        GameObject capsuleInstance;
        IsPressed = pressed;
        if (!pressed)
        {
            //if there is no clone in the environment you can clone an object
            if (acceptInput)
            {
                acceptInput = false;

                //remove speed so it won't be chosed again and instantiate object
                if (PrimaryReactor.speed.Count > 0)
                {
                    PrimaryReactor.speed.RemoveAt(0);
                    incrementText();
                    // create instance
                    capsuleInstance = Instantiate(capsuleClone, startPosition.position, startPosition.rotation) as GameObject;
                    currentClone = capsuleInstance;
                }
                if (PrimaryReactor.speed.Count == 0)
                {
                    trialsLeft.text = "Thanks for playing Team 5's Project 5." + "\n" + "We appreciate your input.";
                }                
            }
            
            
        }
            
    }


    public void incrementText()
    {
        trialsLeft.text = "Trials Remaining: " + speed.Count;
    }
    //set speeds for the array to be randomized
    public void setSpeeds()
    {
        // 10 speed for 2f
        for (int i = 0; i < 10; i++) {
            speed.Add(3f);
            speed.Add(4f);
            speed.Add(5f);
            speed.Add(6f);
        }
    }

   
    

}