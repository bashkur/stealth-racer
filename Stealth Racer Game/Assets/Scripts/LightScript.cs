using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript : MonoBehaviour
{
    public enum LightState { OFF,ON,CHARGING} //0 is inactive, 1 is active, 2 is charging (partially on so the player knows its about to activate)
    public LightState currentLightState = LightState.OFF;
    public float timeElapsed = 0; //set to non-0 to start the light with an offset in the cycle
    public float onTime = 5; //seconds the light spends on per cycle
    public float offTime = 5; //seconds the light spends off per cycle
    public float chargingTime = 1; //seconds the light is visible charging before becoming active
    // Start is called before the first frame update
    void Start()
    {
        ChangeLightState(currentLightState); //to set the lighting to the default state
    }

    // Update is called once per frame
    void Update()
    {
        //temporary light switching system
        timeElapsed += Time.deltaTime;
        /*
        if (timeElapsed >= 5)
        {
            timeElapsed -= 5;
            if (currentLightState == LightState.ON)
                ChangeLightState(LightState.OFF);
            else
                ChangeLightState(LightState.ON);
        }
        */
        if (currentLightState == LightState.ON)
        {
            if (timeElapsed >= onTime) //light shifts to off state
            {
                ChangeLightState(LightState.OFF);
                timeElapsed -= onTime;
            }
        }
        else
        {
            if (currentLightState == LightState.CHARGING)
            {
                if (timeElapsed >= offTime) //light shifts to on state
                {
                    ChangeLightState(LightState.ON);
                    timeElapsed -= offTime;
                }
            }
            else if (timeElapsed+chargingTime >= offTime) //light shifts to charging
            {
                ChangeLightState(LightState.CHARGING);
            }
        }
        
    }

    void ChangeLightState(LightState newState)
    {
        currentLightState = newState;
        if (currentLightState == LightState.OFF) //light and hitbox are inactive
        {
            transform.Find("SpotLight").gameObject.SetActive(false);
            transform.Find("HitBox").gameObject.SetActive(false);
        }
        else if (currentLightState == LightState.CHARGING) //light is weak but active, hitbox is disabled
        {
            transform.Find("SpotLight").gameObject.SetActive(true);
            transform.Find("SpotLight").GetComponent<Light>().intensity = 5;
            transform.Find("HitBox").gameObject.SetActive(false);
        }
        else if (currentLightState == LightState.ON) //light and hitbox are active
        {
            transform.Find("SpotLight").gameObject.SetActive(true);
            transform.Find("SpotLight").GetComponent<Light>().intensity = 25;
            transform.Find("HitBox").gameObject.SetActive(true);
        }
    }
}
