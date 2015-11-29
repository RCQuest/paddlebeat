using Rhythmify;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

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
    public NodeSelector nodeSystem;
    public MoveToPositions movement;
    public Text countdown;
    
    public GameObject nodeL;
    public GameObject nodeC;
    public GameObject nodeR;

    public GameObject paddleZ;
    public GameObject paddleX;
    public GameObject paddleC;

    public Vector3 currentNode;
    public GameObject currentNodeObject;
    public Vector3 previousNode;

    public bool playerHasHitThisStep;
    public bool isOnEntry;
    public bool playerTurn;

    public float threshold;

    public PlayerStats stats;


    // Use this for initialization
    void Start ()
    {
        isOnEntry = false;
        playerHasHitThisStep = false;
        playerTurn = true;
        currentNode = paddleX.transform.position;
        currentNodeObject = paddleX;
        previousNode = nodeC.transform.position;
    }
	
	// Update is called once per frame
	void Update ()
    {
        bool x = Input.GetKeyDown(KeyCode.X);
        bool z = Input.GetKeyDown(KeyCode.Z);
        bool c = Input.GetKeyDown(KeyCode.C);
        if (x && currentNodeObject == paddleX)
        {
            paddleX.GetComponent<CentrePaddleAnimation>().startAnimation();
            verifyPress(paddleX.GetComponent<Paddle>());
        }
        else if (z && currentNodeObject == paddleZ)
        {
            paddleZ.GetComponent<SidePaddleAnimation>().startAnimation();
            verifyPress(paddleZ.GetComponent<Paddle>());
        }
        else if (c && currentNodeObject == paddleC)
        {
            paddleC.GetComponent<SidePaddleAnimation>().startAnimation();
            verifyPress(paddleC.GetComponent<Paddle>());
        }
        else if (!((x && paddleX.GetComponent<Paddle>().isTouchingABrick)
             || (z && paddleZ.GetComponent<Paddle>().isTouchingABrick)
             || (c && paddleC.GetComponent<Paddle>().isTouchingABrick))
             && (x || z || c))
            grace.grace();
    }

    private void verifyPress(Paddle paddle)
    {

        if ((playerHasHitThisStep || !isOnEntry) && !paddle.isTouchingABrick)
        {
            grace.grace();
        }
        if (!grace.isGraced() && isOnEntry && playerTurn)
        {
            distance = Vector3.Distance(ball.gameObject.transform.position, currentNode);
            playerHasHitThisStep = true;
            if (distance > maxDistance && !paddle.isTouchingABrick)
            {
                grace.grace();
            }
            else
            {
                stats.incrementScore(Mathf.RoundToInt(1000f*(maxDistance-distance)/maxDistance));
            }

            
        }
    }

    public void requestNextNode()
    {
        isOnEntry = false;
        if (grace.isGraced()) grace.graceCountdown--;
        countdown.text = grace.graceCountdown.ToString();

        if (currentNodeObject.CompareTag("Paddle"))
        {
            playerTurn = false;
        }
        else playerTurn = true;

        checkHasPressed();
        
        previousNode = currentNode;
        currentNodeObject = playerTurn ? getRandomPaddle() : getNextNode();
        currentNode = new Vector3(currentNodeObject.transform.position.x,
                                  currentNodeObject.transform.position.y, 
                                  0.0f);
    }

    private GameObject getNextNode()
    {
        if (Input.GetKey(KeyCode.LeftArrow) && Input.GetKey(KeyCode.RightArrow))
            return nodeC;
        if (Input.GetKey(KeyCode.LeftArrow))
            return nodeL;
        if (Input.GetKey(KeyCode.RightArrow))
            return nodeR;
        return nodeC;
    }

    private GameObject getRandomPaddle()
    {
        float paddle = UnityEngine.Random.value;
        if (paddle > .6f)
            return paddleZ;
        if (paddle > .3f)
            return paddleC;
        return paddleX;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Paddle"))
        {
            isOnEntry = true;
        }
        else if (other.CompareTag("Node"))
        {
            playerHasHitThisStep = true;
        }
    }

    public void checkHasPressed()
    {
        //Debug.Log("checking...");
        if (playerHasHitThisStep)
        {
            playerHasHitThisStep = false;
        }
        else if (!grace.isGraced())
        {
            grace.grace();
        }
        if (grace.graceCountdown <= 0) grace.endGrace();
    }
}
