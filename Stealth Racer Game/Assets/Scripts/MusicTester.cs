using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicTester : MonoBehaviour
{
    public GameObject sphere_prefab;
    MusicParser mp = new MusicParser();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DoIt(float time)
    {
        Vector3 pos = new Vector3(sphere_prefab.transform.position.x + 1, 0, 0);
        GameObject g = Instantiate(sphere_prefab, pos, sphere_prefab.transform.rotation);
    }
}
