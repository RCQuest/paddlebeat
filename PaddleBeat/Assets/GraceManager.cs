using UnityEngine;
using System.Collections;

public class GraceManager : MonoBehaviour
{

    private bool graced = false;
    public int graceCountdown=0;
    public int graceCountdownLength=3;

    public Color aliveColor;
    public Color deadColor;

    void Start()
    {
        GetComponent<TrailRenderer>().material.color = aliveColor;
        graceCountdown = graceCountdownLength;

    }

    public void grace()
    {
        if (!graced)
        {
            startGrace();
        }
    }

    public bool isGraced()
    {
        return graced;
    }

    private void startGrace()
    {
        tag = "Player";
        graced = true;
        //Debug.Log("grace started.");
        GetComponent<TrailRenderer>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
    }

    public void endGrace()
    {
        tag = "Ball";
        graceCountdown = graceCountdownLength;
        graced = false;
        GetComponent<TrailRenderer>().enabled = true;
        GetComponent<SpriteRenderer>().enabled = true;
        //Debug.Log("grace end.");
    }

}
