// Made possible with the help of countless hours of Googling, 
// then discovering Graham Tattersall's article:
// https://www.gamasutra.com/blogs/GrahamTattersall/20190515/342454/Coding_to_the_Beat__Under_the_Hood_of_a_Rhythm_Game_in_Unity.php
// Audio coding is crazy.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public GameObject lightPost;
    public AudioSource audioSource;

    //the current position of the song (in seconds)
    public float songPosition;
    public float songPositionInBeats;
    public float secPerBeat;

    //how much time (in seconds) has passed since the song started
    public float dspSongTime;
    public float bpm;

    //The offset to the first beat of the song in seconds
    public float firstBeatOffset;

    public float beatsPerLoop;
    public int completedLoops = 0;
    public float loopPositionInBeats;
    //Current relative pos of the song within the loop (0..1)
    public float loopPositionInAnalog;

    // Start is called before the first frame update
    void Start()
    {
        

        audioSource = GetComponent<AudioSource>();
        secPerBeat = 60f / bpm;

        //record the time when the song starts
        dspSongTime = (float)AudioSettings.dspTime;

        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        songPosition = (float)(AudioSettings.dspTime - dspSongTime - firstBeatOffset);  //in seconds
        songPositionInBeats = songPosition / secPerBeat;

        // Update number of loops every time the song restarts
        // Looping must be on for this to work
        if (songPositionInBeats >= (completedLoops + 1) * beatsPerLoop)
            completedLoops++;
        loopPositionInBeats = songPositionInBeats - completedLoops * beatsPerLoop;

        loopPositionInAnalog = loopPositionInBeats / beatsPerLoop;

        //sync lights with the beat
        // songPositionInBeats % beat interval
        if (Mathf.FloorToInt(songPositionInBeats) % 4 == 0)
        {
             
        }
    }
}
