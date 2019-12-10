using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//every N beats:
//    go through "off" lights
//    randomly pick X amount of them
//    lights.turnOn()

//lights.turnOn():
//    go through charging time
//    turn on
//    cooldown
//    turn off

public class LightManager : MonoBehaviour
{
    public GameObject light_prefab;

    public static List<GameObject> allLights;
    public static List<GameObject> offLights;
    public static List<GameObject> selectedLights;

    int index;

    void Awake()
    {
        allLights = new List<GameObject>();
        offLights = new List<GameObject>();
        selectedLights = new List<GameObject>();

        // for easy access to all light posts in the scene
        foreach (Transform child in transform)
        {
            allLights.Add(child.gameObject);

            // also keep a separate list of OFF lights
            if (child.gameObject.CompareTag("OFF"))
                offLights.Add(child.gameObject);
        }


        // pick lights with no duplicates
        //for(int i = 0; i < 10; i++)
        //{
        //    index = UnityEngine.Random.Range(0, offLights.Count - 1);
        //    //print(index);

        //    var chosen = offLights[index];
        //    while(chosen.CompareTag("Chosen"))
        //    {
        //        index = UnityEngine.Random.Range(0, offLights.Count - 1);
        //        chosen = offLights[index];
        //    }
        //    chosen.tag = "Chosen";
        //    //print(chosen.transform);
        //}
    }

    public void StartTheLights(int numLights)
    {
        int amountAvailable = offLights.Count - numLights;

        // check to see if we have enough lights available
        if (amountAvailable <= 0)
            return;

        if (amountAvailable < numLights)
            numLights = amountAvailable;

        int numSelected = 0;
        // pick random lights with no duplicates
        while (numSelected < numLights)
        {
            int randIdx = UnityEngine.Random.Range(0, offLights.Count);

            // we can only pick the lights that are OFF and not selected currently
            if (!selectedLights.Contains(offLights[randIdx]))
            {
                selectedLights.Add(offLights[randIdx]);
                offLights.RemoveAt(randIdx);
                numSelected++;
            }
        }

        foreach (GameObject lt in selectedLights)
        {
            var script = lt.GetComponent<LightScript_v2>();
            script.Flip();
        }
    }

    void Update()
    {
        
    }
}
