using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour
{
    public float startPosition=0;
    public float tempo;
    public float samplesPerBeat;

    public float debugLevel=0.1f;

    void Update()
    {
        float beat = getCurrentBeatPosition();
        if (beat < debugLevel) Debug.Log(beat);
    }

    public void setSamplesPerBeat()
    {
        samplesPerBeat = (tempo / 60f) / gameObject.GetComponent<AudioSource>().clip.frequency;
    }
    
    public void startTrack()
    {
        gameObject.GetComponent<AudioSource>().Play();
    }

    public float getCurrentBeatPosition()
    {
        //Debug.Log((gameObject.GetComponent<AudioSource>().timeSamples % samplesPerBeat) / samplesPerBeat);
        return (gameObject.GetComponent<AudioSource>().timeSamples%samplesPerBeat)/ samplesPerBeat;
    }
}
