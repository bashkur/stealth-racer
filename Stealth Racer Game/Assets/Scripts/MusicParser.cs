using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using NAudio;
using NAudio.Midi;

public class MusicParser
{
    static string path = "Assets/Music/Stealth driver.mid";
    MidiFile mf = new MidiFile(path, true);

    public float ticks;
    public float offset;

    public MusicTester tester = new MusicTester();

    public void Test()
    {
        Debug.Log("Format " + mf.FileFormat +
            ", Tracks " + mf.Tracks +
            " Delta Ticks Per Quarter Note " + mf.DeltaTicksPerQuarterNote);
    }

    public void Start()
    {
        ticks = mf.DeltaTicksPerQuarterNote;
        IList<MidiEvent> light_events = mf.Events[9];   //track 10

        foreach(MidiEvent ev in light_events)
        {
            if(ev.CommandCode == MidiCommandCode.NoteOn)
            {
                NoteOnEvent noteOnEvent = (NoteOnEvent)ev;
                NoteEvent(noteOnEvent);
            }
        }
    }

    public void NoteEvent(NoteOnEvent ev)
    {
        float bpm = 120;    //tempo of the track
        float time = (60 * ev.AbsoluteTime) / bpm * ticks;  //time until start of the note (seconds)
        tester.DoIt(time);
    }

}
