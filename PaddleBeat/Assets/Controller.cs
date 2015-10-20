using UnityEngine;

public class SongInfo
{
    public float secondsTillFirstBeat;
    public float BPM;
}

public class Controller : MonoBehaviour //, AudioProcessor.AudioCallbacks
{
    public BallMovement ball;
    public GraceManager grace;
    public NodeSelector nodeSystem;
    public float distance;
    public float maxDistance;
    public bool playerHasHitThisStep=false;
    public SongInfo currentSong;
    public AudioManager audioManager;
    //public AudioProcessor processor;
    //public int beatsDetected;
    //private int windUpPeriod = 8;


    // Use this for initialization
    void Start ()
    {
        currentSong = new SongInfo();
        currentSong.BPM = 130;
        currentSong.secondsTillFirstBeat = 0.0f;
        nodeSystem.setTempo(currentSong.BPM);
        audioManager.tempo = currentSong.BPM;
        audioManager.setSamplesPerBeat();
        nodeSystem.begin();
        audioManager.startTrack();


        //processor = FindObjectOfType<AudioProcessor>();
        //processor.addAudioCallback(this);
    }
	
	// Update is called once per frame
	void Update ()
    {
	    if(Input.GetKeyDown(KeyCode.Z)&&!grace.isGraced())
        {
            distance = Vector3.Distance(ball.gameObject.transform.position, 
                nodeSystem.currentNode.transform.position);
            Debug.Log(distance);
            playerHasHitThisStep = true;
            if(distance>maxDistance)
            {
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
