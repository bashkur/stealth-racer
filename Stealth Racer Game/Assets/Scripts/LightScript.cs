using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public enum LightState { OFF,ON,CHARGING} //0 is inactive, 1 is active, 2 is charging (partially on so the player knows its about to activate)
    LightState currentLightState = LightState.ON;
    float timeElapsed = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //temporary light switching system
        timeElapsed += Time.deltaTime;
        if (timeElapsed >= 5)
        {
            timeElapsed -= 5;
            if (currentLightState == LightState.ON)
                ChangeLightState(LightState.OFF);
            else
                ChangeLightState(LightState.ON);
        }
    }

    void ChangeLightState(LightState newState)
    {
        currentLightState = newState;
        if (currentLightState == LightState.OFF)
        {
            transform.Find("SpotLight").gameObject.SetActive(false);
            transform.Find("HitBox").gameObject.SetActive(false);
        }
        else if (currentLightState == LightState.ON)
        {
            transform.Find("SpotLight").gameObject.SetActive(true);
            transform.Find("HitBox").gameObject.SetActive(true);
        }
    }
}
