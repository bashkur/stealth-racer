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

    public static List<GameObject> all_lights;
    public static List<GameObject> off_lights;

    int index;

    void Start()
    {
        all_lights = new List<GameObject>();
        off_lights = new List<GameObject>();

        // for easy access to all available lights
        foreach (Transform child in transform)
        {
            all_lights.Add(child.gameObject);

            // also keep a separate list of OFF lights
            if (child.gameObject.CompareTag("OFF"))
                off_lights.Add(child.gameObject);
        }

        // pick lights with no duplicates
        for(int i = 0; i < 10; i++)
        {
            index = UnityEngine.Random.Range(0, off_lights.Count - 1);
            //print(index);
            var chosen = off_lights[index];
            while(chosen.CompareTag("Chosen"))
            {
                index = UnityEngine.Random.Range(0, off_lights.Count - 1);
                chosen = off_lights[index];
            }
            chosen.tag = "Chosen";
            //print(chosen.transform);
        }

        var script = off_lights[0].GetComponent<LightScript_v2>();
        script.Flip();
    }

    void Update()
    {
        
    }
}
