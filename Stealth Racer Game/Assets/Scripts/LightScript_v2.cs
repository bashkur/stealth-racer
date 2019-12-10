using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightScript_v2 : MonoBehaviour
{
    public float t_charging = 2;
    public float t_cooldown = 5;
    public float t_on = 5;
    public float t_off = 5;
    public float t_elapsed = 0;

    float minIntensity;
    float dimIntensity;
    float maxIntensity;


    //public bool is_charging;
    //public bool is_inCooldown;

    Light test_light;
    CapsuleCollider hitbox;

    // Start is called before the first frame update
    void Start()
    {
        minIntensity = 0;
        dimIntensity = 5;
        maxIntensity = 25;

        gameObject.tag = "OFF";
        test_light = transform.GetChild(0).GetComponent<Light>();
        hitbox = transform.GetChild(1).GetComponent<CapsuleCollider>();

        //test_light.enabled = false;
        hitbox.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        t_elapsed += Time.deltaTime;
    }
    
    public void Flip()
    {
        StartCoroutine(Charge());
    }

    IEnumerator TurnOn()
    {
        Debug.Log("TURNING ON");
        test_light.gameObject.SetActive(true);


        float counter = 0;
        float lerpTime = 2;

        float currentIntensity = test_light.intensity;

        // gradually increase the light intensity to max
        while (counter < lerpTime)
        {
            counter += Time.deltaTime;
            test_light.intensity = Mathf.Lerp(currentIntensity, maxIntensity, counter / lerpTime);
            yield return null;
        }

        // light is officially on. activate the hitbox
        gameObject.tag = "ON";
        hitbox.gameObject.SetActive(true);

        // keep the light on for t_on seconds
        yield return new WaitForSeconds(t_on);

        Debug.Log("TURNING OFF");

        gameObject.tag = "OFF";
        test_light.gameObject.SetActive(false);
        hitbox.gameObject.SetActive(false);
    }

    IEnumerator Charge()
    {
        Debug.Log("CHARGING");
        gameObject.tag = "CHARGING";
        test_light.gameObject.SetActive(true);

        float counter = 0;
        
        while(counter < t_charging)
        {
            counter += Time.deltaTime;
            test_light.intensity = Mathf.Lerp(minIntensity, dimIntensity, counter / t_charging);
            yield return null;
        }

        while(counter < t_charging + 0.5f)
        {
            counter += Time.deltaTime;
            yield return new WaitForSeconds(0.1f);
            test_light.enabled = !test_light.enabled;
        }

        test_light.enabled = true;
        //yield return new WaitForSeconds(t_charging);
        yield return StartCoroutine(TurnOn());

    }

    IEnumerator Flashing()
    {
        while (true)
        {
            yield return new WaitForSeconds(0.5f);
            test_light.enabled = !test_light.enabled;
        }
    }


}
