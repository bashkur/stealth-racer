using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    static int currentCheckpoint = 0;
    public int thisCheckpoint = 1;
    public bool isFinalCheckpoint = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Car") //only trigger on collision with a car
        {
            if (currentCheckpoint == thisCheckpoint-1) //if the current checkpoint is the last checkpoitn
            {
                print("Checkpoint " + thisCheckpoint + " reached");
                currentCheckpoint = thisCheckpoint;
                if (isFinalCheckpoint)
                {
                    print("Game won!");
                }
            }
        }
    }
}
