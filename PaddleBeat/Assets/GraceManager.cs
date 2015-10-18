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

    //IEnumerator gracePeriod()
    //{
    //    graced = true;
    //    startGrace();
    //    yield return new WaitForSeconds(periodLength);
    //    endGrace();
    //    graced = false;
    //}

    private void startGrace()
    {

        graced = true;
        //Debug.Log("grace started.");
        GetComponent<TrailRenderer>().material.color = deadColor;
    }

    public void endGrace()
    {
        graceCountdown = graceCountdownLength;
        graced = false;
        GetComponent<TrailRenderer>().material.color = aliveColor;
        //Debug.Log("grace end.");
    }

}
