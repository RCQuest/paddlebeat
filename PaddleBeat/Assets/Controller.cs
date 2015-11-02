using Rhythmify;
using UnityEngine;

public class SongInfo
{
    public float secondsTillFirstBeat;
    public float BPM;
}

public class Controller : MonoBehaviour //, AudioProcessor.AudioCallbacks
{
    public MoveToPositions ball;
    public GraceManager grace;
    public float distance;
    public float maxDistance;
    public bool playerHasHitThisStep=false;
    public NodeSelector nodeSystem;
    public MoveToPositions movement;


    // Use this for initialization
    void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.Z)&&!grace.isGraced())
        {
            distance = Vector3.Distance(ball.gameObject.transform.position, 
                movement.positions[(nodeSystem.currentStep+1) % movement.positions.Length]);
            Debug.Log(distance);
            playerHasHitThisStep = true;
            if(distance>maxDistance)
            {
                Debug.Log("ooops!");
                grace.grace();
            }
        }
	}

    ////this event will be called every time a beat is detected.
    ////Change the threshold parameter in the inspector
    ////to adjust the sensitivity
    //public void onOnbeatDetected()
    //{

    //    if(beatsDetected <= windUpPeriod+1) beatsDetected++;
    //    if (beatsDetected <= windUpPeriod) nodeSystem.tempo = processor.tapTempo();
    //    if (beatsDetected == windUpPeriod)
    //    {
    //        Debug.Log("set!!!");
    //        nodeSystem.setTempo();
    //        nodeSystem.begin();
    //    }
    //    Debug.Log("Beat!!!");
    //}

    ////This event will be called every frame while music is playing
    //public void onSpectrum(float[] spectrum)
    //{
    //    //The spectrum is logarithmically averaged
    //    //to 12 bands

    //    for (int i = 0; i < spectrum.Length; ++i)
    //    {
    //        Vector3 start = new Vector3(i, 0, 0);
    //        Vector3 end = new Vector3(i, spectrum[i], 0);
    //        Debug.DrawLine(start, end);
    //    }
    //}

    public void checkHasPressed()
    {
        //Debug.Log("checking...");
        if(playerHasHitThisStep)
        {
            playerHasHitThisStep = false;
        }
        else if(!grace.isGraced())
        {
            grace.grace();
        }
        if (grace.graceCountdown <= 0) grace.endGrace();
    }
}
