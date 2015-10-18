using UnityEngine;

public class Controller : MonoBehaviour
{
    public BallMovement ball;
    public GraceManager grace;
    public NodeSelector nodeSystem;
    public float distance;
    public float maxDistance;
    public bool playerHasHitThisStep=false;


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
                nodeSystem.currentNode.transform.position);
            Debug.Log(distance);
            playerHasHitThisStep = true;
            if(distance>maxDistance)
            {
                grace.grace();
            }
        }
	}



    public void checkHasPressed()
    {
        Debug.Log("checking...");
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
