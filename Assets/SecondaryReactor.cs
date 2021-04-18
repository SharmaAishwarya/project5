using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class SecondaryReactor : MonoBehaviour
{
    public SecondaryButtonWatcher watcher;
    public bool IsPressed = false;

    public GameObject clone;
    private string myFilePath;

    // Start is called before the first frame update
    void Start()
    {
        watcher.secondaryButtonPress.AddListener(onSecondaryButtonEvent);
        myFilePath = "./collision.txt";
        if (File.Exists(myFilePath))
        {
            try
            {
                File.Delete(myFilePath);
            }
            catch (System.Exception e)
            {
                Debug.LogError("File does not exist.");
            }
        }
    }


    public void onSecondaryButtonEvent(bool pressed)
    {
        IsPressed = pressed;
        if (!pressed)
        {
            clone = PrimaryReactor.currentClone;
            if (clone != null)  //if clone is in the environment
            {
                Vector3 clonePosition = clone.transform.position;
                // d/s = t
                float predictedCollisionTime = (PrimaryReactor.objectStartPosition.z - clonePosition.z) / Movement.moveSpeed;
                Debug.Log("Predicted Collision time: " + predictedCollisionTime + " seconds");
                //destroy the clone once the user has made prediction
                Destroy(clone);

                //Write information to file
                WriteToFile("ATC " + PrimaryReactor.actualCollisionTime + "\n");
                WriteToFile("PTC " + predictedCollisionTime + "\n");
                WriteToFile("Speed " + Movement.moveSpeed);
                WriteToFile("\n");
                WriteToFile("\n");

                // write to console 
                Debug.Log("Actual time to contact (seconds): " + PrimaryReactor.actualCollisionTime);
                Debug.Log("Predicted time to contact (seconds): " + predictedCollisionTime);
                Debug.Log("Speed (m/s): " + Movement.moveSpeed);

                // allow objects to be instantiated again
                PrimaryReactor.acceptInput = true;
            }
            else { Debug.Log("no clone found"); }
        }
      

        
    }


    public void WriteToFile(string message)
    {
        try
        {
            StreamWriter fileWriter = new StreamWriter(myFilePath, true);
            fileWriter.Write(message);
            fileWriter.Close();
        }
        catch (System.Exception e)
        {
            Debug.LogError(" Cannot write in the file.");
        }

    }
}
