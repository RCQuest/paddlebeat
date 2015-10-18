using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

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

	public float CURRENT_SPEED;
	public float timer;
	public List<GameObject> nodes;
	public List<Tuple<MoveType, int>> sequence;
	private int currentNodeStep;
    public GameObject currentNode;
    public int currentStep;
    public BallMovement movement;
    public Controller controller;
    public TextMesh countdown;
    public GraceManager grace;

    // Use this for initialization
    void Start ()
    {
		sequence = new List<Tuple<MoveType, int>>(){
			new Tuple<MoveType, int>(MoveType.DEFAULT,0),
			new Tuple<MoveType, int>(MoveType.DEFAULT,1)
		};

		movement.nodeNext=nodes[sequence[currentNodeStep].Second];
	}
	
	// Update is called once per frame
	void Update () {
		timer=timer+Time.deltaTime;
        if (timer > CURRENT_SPEED / 2 && currentNode!= movement.nodeNext)
        {
            currentStep = sequence[currentNodeStep].Second;
            currentNode = nodes[currentStep];
        }
		if(timer > CURRENT_SPEED)
		{
			Vector3 lastNodePosition = 
                nodes[sequence[currentNodeStep].Second].transform.position;
			timer=0;
			currentNodeStep++;
			if(currentNodeStep==sequence.Count)
				currentNodeStep=0;
			movement.nodeNext=nodes[sequence[currentNodeStep].Second];
			movement.speed=Vector3.Distance(lastNodePosition, 
                nodes[sequence[currentNodeStep].Second].transform.position)/CURRENT_SPEED;
		}
	}

    void OnTriggerExit2D(Collider2D other)
    {
        //Debug.Log("gotcha");
        if(grace.isGraced()) grace.graceCountdown--;
        countdown.text = grace.graceCountdown.ToString();
        Debug.Log(grace.graceCountdown);
        if (other.CompareTag("Respawn")) controller.checkHasPressed();
    }
}
