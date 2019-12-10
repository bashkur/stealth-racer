using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTriggerScript : MonoBehaviour
{
    bool isPlayerBusted = false; //whether this light trigger has caught the player this cycle
    public float timePenalty = 5;

    TimerScript timerRef;

    private void Start()
    {
        if (timerRef == null)
            timerRef = GameObject.Find("TimeUI").GetComponent<TimerScript>();
    }

    // When the player hits this trigger zone
    private void OnTriggerEnter(Collider other)
    {
        if (!isPlayerBusted)
        {
            print("Busted!");
            StopAllCoroutines();
            TimerScript.timerRef.AddTimePenalty(timePenalty);
            isPlayerBusted = true;
        }
    }

    //the light can only bust the player once per light cycle, when the light is disabled the busted state is reverted to false
    private void OnDisable()
    {
        isPlayerBusted = false;
    }

}
