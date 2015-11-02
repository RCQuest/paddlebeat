using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using Rhythmify;

public class Tuple<T1, T2>
{
	public T1 First { get; private set; }
	public T2 Second { get; private set; }
	internal Tuple(T1 first, T2 second)
	{
		First = first;
		Second = second;
	}
}

public enum MoveType{
	DEFAULT
};

public class NodeSelector : MonoBehaviour {

	//public float secondsPerBeat;
	//public float timer;
	//public List<GameObject> nodes;
	//public List<Tuple<MoveType, int>> sequence;
	//private int currentNodeStep;
    public int currentStep;
 //   public BallMovement movement;
    public Controller controller;
    public TextMesh countdown;
    public GraceManager grace;
    public MoveToPositions ball;
 //   public bool begun = true;
 //   public AudioManager audioManager;

    // Use this for initialization
    void Start ()
    {
        currentStep = ball.idx;
	}
	
	// Update is called once per frame
	void Update () {
       
	}
    

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Respawn"))
        {
            if (grace.isGraced()) grace.graceCountdown--;
            countdown.text = grace.graceCountdown.ToString();
            controller.checkHasPressed();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Respawn"))
        {
            currentStep=ball.idx;
        }
    }
}
