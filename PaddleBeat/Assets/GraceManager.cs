using UnityEngine;
using System.Collections;

public class GraceManager : MonoBehaviour
{

    private bool graced = false;
    public float periodLength;

    public void grace()
    {
        if(!graced) StartCoroutine(gracePeriod());
    }

    public bool isGraced()
    {
        return graced;
    }

    IEnumerator gracePeriod()
    {
        graced = true;
        startGrace();
        yield return new WaitForSeconds(periodLength);
        endGrace();
        graced = false;
    }

    private void startGrace()
    {
        Debug.Log("grace started.");
    }

    private void endGrace()
    {
        Debug.Log("grace end.");
    }

}
